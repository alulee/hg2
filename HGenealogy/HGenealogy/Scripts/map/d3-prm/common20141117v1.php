<?php
error_reporting(E_ALL & ~E_NOTICE);
require_once 'markdown/Markdown.inc.php';
use \Michelf\Markdown;

require_once("DB_config.php");
require_once("DB_class.php");

$dataset    = 'default';
$dataset_qs = '';
if (isset($_GET['dataset'])) {
    if (!preg_match('@[^a-z0-9-_ ]@i', $_GET['dataset'])) {
        if (is_dir('data/' . $_GET['dataset'])) {
            $dataset    = $_GET['dataset'];
            $dataset_qs = "?dataset=$dataset";
        }
    }
}

function get_html_docs($obj) {
    global $config, $data, $dataset, $errors;

    $name = str_replace('/', '_', $obj['name']);
    $filename = "data/$dataset/$name.mkdn";

    $name = str_replace('_', '\_', $obj['name']);
    $type = $obj['type'];
    if ($config['types'][$type]) {
        $type = $config['types'][$type]['long'];
    }

    $markdown = "## $name *$type*\n\n";

    if (file_exists($filename)) {
        $markdown .= "### Documentation\n\n";
        $markdown .= file_get_contents($filename);
    } else {
        $markdown .= "<div class=\"alert alert-warning\">No documentation for this object</div>";
    }

    if ($obj) {
        $markdown .= "\n\n";
        $markdown .= get_depends_markdown('Depends on',     $obj['depends']);
        $markdown .= get_depends_markdown('Depended on by', $obj['dependedOnBy']);
    }

    // Use {{object_id}} to link to an object
    $arr      = explode('{{', $markdown);
    $markdown = $arr[0];
    for ($i = 1; $i < count($arr); $i++) {
        $pieces    = explode('}}', $arr[$i], 2);
        $name      = $pieces[0];
        $id_string = get_id_string($name);
        $name_esc  = str_replace('_', '\_', $name);
        $class     = 'select-object';
        if (!isset($data[$name])) {
            $class .= ' missing';
            $errors[] = "Object '$obj[name]' links to unrecognized object '$name'";
        }
        $markdown .= "<a href=\"#$id_string\" class=\"$class\" data-name=\"$name\">$name_esc</a>";
        $markdown .= $pieces[1];
    }

    $html = Markdown::defaultTransform($markdown);
    // IE can't handle <pre><code> (it eats all the line breaks)
    $html = str_replace('<pre><code>'  , '<pre>' , $html);
    $html = str_replace('</code></pre>', '</pre>', $html);
    return $html;
}

function get_depends_markdown($header, $arr) {
    $markdown = "### $header";
    if (count($arr)) {
        $markdown .= "\n\n";
        foreach ($arr as $name) {
            $markdown .= "* {{" . $name . "}}\n";
        }
        $markdown .= "\n";
    } else {
        $markdown .= " *(none)*\n\n";
    }
    return $markdown;
}

function get_id_string($name) {
    return 'obj-' . preg_replace('@[^a-z0-9]+@i', '-', $name);
}

function read_config() {
    global $config, $dataset, $dataset_qs;

    $config = json_decode(file_get_contents("data/$dataset/config.json" ), true);
    $config['jsonUrl'] = "json.php$dataset_qs";
}

function read_data() {
    global $config, $data, $dataset, $errors;

    if (!$config) read_config();

	$json  = read_data_from_gflist();
    $json1   = json_decode(file_get_contents("data/$dataset/objects.json"), true);
    $data   = array();
    $errors = array();
	$errors1 = array();

    foreach ($json as $obj) {
        $data[$obj['name']] = $obj;
    }

    foreach ($data as &$obj) {
        $obj['dependedOnBy'] = array();
    }
    unset($obj);
    foreach ($data as &$obj) {
        foreach ($obj['depends'] as $name) {
            if ($data[$name] && $name != '') {
                $data[$name]['dependedOnBy'][] = $obj['name'];
            } else {
				unset($obj['depends']);
                $errors1[] = "Unrecognized dependency: '$obj[name]' depends on '$name'";
            }
        }
    }
    unset($obj);
    foreach ($data as &$obj) {
        $obj['docs'] = get_html_docs($obj);
    }
    unset($obj);
}


function read_data_from_gflist(){
	global $config, $data, $dataset, $errors;
	global $_DB;
	
	$data1   = array();
	
	$db = new DB();
    $db->connect_db($_DB['host'], $_DB['username'], $_DB['password'], $_DB['dbname']);
    $sql = "SELECT * FROM gene_pods_gflist";
	$result = $db->fetch_array($sql);
	if($result){
		while ($row = mysqli_fetch_assoc($result)){
			$host = $row["host"]; 				
			$father = $row["father"]; 	
			$generation = 'g'.$row["generation"];
			
			if(!($father == null || $father == '')) {
				$data1[] = array( "type"=>$generation, "name"=> $host, 
							"depends"=>array($father));
			}else{
				$data1[] = array( "type"=>$generation, "name"=> $host, 
							"depends"=>array());
			}
		}
	}
	 
	return $data1;
}

?>
