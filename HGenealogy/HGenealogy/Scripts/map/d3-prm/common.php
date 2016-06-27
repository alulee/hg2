<?php
error_reporting(E_ALL & ~E_NOTICE);
require_once 'markdown/Markdown.inc.php';
use \Michelf\Markdown;

//require_once("DB_config.php");
//require_once("DB_class.php");

//$dataset    = 'default';
$dataset    = 'default';
$dataset_qs = '';
$dataset_name = '';
$searchname = '';
if (isset($_GET['searchname'])) {
    $searchname = $_GET['searchname'];
}

if (isset($_GET['dataset'])) {
    if (!preg_match('@[^a-z0-9-_ ]@i', $_GET['dataset'])) {
        if (is_dir('data/' . $_GET['dataset'])) {
            $dataset    = $_GET['dataset'];
			
			if($searchname && '' != $searchname)			
				$dataset_qs = "?dataset=$dataset&searchname=$searchname";
			else
				$dataset_qs = "?dataset=$dataset";
			$dataset_name = "$dataset";
        }
    }
}

function get_html_docs($obj) {
    global $config, $data, $dataset, $errors, $dataset_name;

    $name = str_replace('/', '_', $obj['name']);
    $filename = "data/$dataset/$name.mkdn";

    $name = str_replace('_', '\_', $obj['name']);
    $type = $obj['type'];
    if ($config['types'][$type]) {
        $type = $config['types'][$type]['long'];
    }
	
	$id_string = 'graph.php?dataset='.$dataset_name.'&selectid='.$obj[nodeid];
	//markdown .= "<a href=\"$id_string\" class=\"$class\" data-name=\"$name\">$name_esc</a>";
    $markdown = "## <a href=\"$id_string\"> $name </a> *$type*\n\n";
	$markdown1 = read_node_document($dataset, $name);
	
    if (file_exists($filename)) {
        $markdown .= "### 資料記錄\n\n";
        $markdown .= file_get_contents($filename);
    } else if($markdown1 != ''){
        $markdown .= $markdown1;
    }else{
        $markdown .= "<div class=\"alert alert-warning\">無相關的資料記錄</div>";
    }
	
	
	
    if ($obj) {
        $markdown .= "\n\n";
        $markdown .= get_depends_markdown('父輩',     $obj['depends']);
        $markdown .= get_depends_markdown('子輩', $obj['dependedOnBy']);
    }

    // Use {{object_id}} to link to an object
    $arr      = explode('{{', $markdown);
    $markdown = $arr[0];
	
    for ($i = 1; $i < count($arr); $i++) {
        $pieces    = explode('}}', $arr[$i], 2);
        $name      = $pieces[0];
        //$id_string = get_id_string($name);
		//$id_string = '';\
		$nodeid = '';
		foreach ($data as &$dependobj) {
			if($dependobj['name'] == $name){
				$nodeid = $dependobj['nodeid'];
				break;
			}
		}		
		$dependid_string = 'graph.php?dataset='.$dataset_name.'&selectid='.$nodeid;
        $name_esc  = str_replace('_', '\_', $name);
        $class     = 'select-object';
        if (!isset($data[$name])) {
            $class .= ' missing';
            $errors[] = "Object '$obj[name]' links to unrecognized object '$name'";
        }
        //$markdown .= "<a href=\"#$id_string\" class=\"$class\" data-name=\"$name\">$name_esc</a>";
		$markdown .= "<a href=\"$dependid_string\" class=\"$class\" data-name=\"$name\">$name_esc</a>";
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
        $markdown .= " *(無)*\n\n";
    }
    return $markdown;
}

function get_id_string($name) {
    // return 'obj-' . preg_replace('@[^a-z0-9]+@i', '-', $name);
	// return 'obj-'.$name;
	// return 'obj-'.$name;
}

function read_config() {
    global $config, $dataset, $dataset_qs, $dataset_name;

    $config = json_decode(file_get_contents("data/$dataset/config.json" ), true);
    $config['jsonUrl'] = "json.php$dataset_qs";
}

function read_data() {
    global $config, $data, $dataset, $errors;
	global $searchname;
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
                //$errors1[] = "Unrecognized dependency: '$obj[name]' depends on '$name'";
				$errors1[] = "無法辦識的相依物件: '$obj[name]' 相依於 '$name'";
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
	global $_DB, $searchname;
	
	$data1   = array();
	$mysqli = new mysqli("localhost", "root", "", "hakka");
	if ($mysqli->connect_errno) {
		echo "Failed to connect to MySQL: (" . $mysqli->connect_errno . ") " . $mysqli->connect_error;
	}
	mysqli_query($mysqli, "SET NAMES utf8");
	//$db = new DB();
    //$db->connect_db($_DB['host'], $_DB['username'], $_DB['password'], $_DB['dbname']);
    $sql = "SELECT * FROM gene_pods_gflist WHERE gfkey='".$dataset."'";
	/* if($searchname && '' != $searchname)
	{
		$sql.= " and host like '%".$searchname."%'";
	} */
	
	
	$result = mysqli_query($mysqli, $sql);
	$i=0;
	if($result){
		while ($row = mysqli_fetch_assoc($result)){
			$i += 1;
			$host = $row["host"]; 				
			$father = $row["father"]; 	
			$generation = 'g'.$row["generation"];
			
			if(!($father == null || $father == '')) {
				$data1[] = array( "type"=>$generation, "name"=> $host, "nodeid" =>$i,
							"depends"=>array($father));
			}else if($host!= "先祖") {			    
				$data1[] = array( "type"=>$generation, "name"=> $host, "nodeid" =>$i,
							"depends"=>array("先祖"));
			}else {			    
				$data1[] = array( "type"=>$generation, "name"=> $host, "nodeid" =>$i,
							"depends"=>array());
			}
		}
	}
	 
	return $data1;
}

function read_node_document($gfkey, $hostname){
	
	$doc = "";
	$mysqli = new mysqli("localhost", "root", "", "hakka");
	if ($mysqli->connect_errno) {
		echo "Failed to connect to MySQL: (" . $mysqli->connect_errno . ") " . $mysqli->connect_error;
	}
	mysqli_query($mysqli, "SET NAMES utf8");
	//$db = new DB();
    //$db->connect_db($_DB['host'], $_DB['username'], $_DB['password'], $_DB['dbname']);
    $sql = 'SELECT * FROM gene_pods_gflist WHERE gfkey="'.$gfkey.'" and host="'.$hostname.'"';

	$result = mysqli_query($mysqli, $sql);
	if($result){
		while ($row = mysqli_fetch_assoc($result)){
			$host = $row["host"]; 				
			$generation = '世代:'.$row["generation"].'<br>';
			$address = '現址:'.$row["address"].'<br>';
			$phone = '電話:'.$row["phone"].'<br>'; 
			$doc .= $generation.$address.$phone;
			break;
		}
	}
	return $doc;
}

?>
