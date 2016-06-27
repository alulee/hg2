<?php
require_once 'common.php';
read_data();
?>
<!DOCTYPE html>
<!--[if lt IE 7]>      <html class="lt-ie9 lt-ie8 lt-ie7"> <![endif]-->
<!--[if IE 7]>         <html class="lt-ie9 lt-ie8"> <![endif]-->
<!--[if IE 8]>         <html class="lt-ie9"> <![endif]-->
<!--[if gt IE 8]><!--> <html> <!--<![endif]-->
    <head>
        <meta http-equiv="X-UA-Compatible" content="IE=Edge">
        <meta charset="utf-8">
        <title><?php echo $config['title']; ?></title>
        <link rel="stylesheet" href="bootstrap.css">
        <link rel="stylesheet" href="style.css">
        <link rel="stylesheet" href="print.css">
    </head>
    <body>
        <a class="btn btn-default nav-button" id="nav-graph" href="graph.php<?php echo $dataset_qs; ?>">
            檢視世系圖
        </a>
        <div id="docs-list">
<?php
$searchname = '';
 
if (isset($_GET['searchname'])) {
    $searchname = $_GET['searchname'];
}

foreach ($data as $obj) {
	if($searchname && '' != $searchname){
		$pos = strpos($obj['name'], $searchname);
		$pos1 = strpos(implode(" ",$obj['depends']), $searchname);
		if($pos !== false ){
			$id = get_id_string($obj['name']);
			echo "<div class=\"docs\" id=\"$id\">$obj[docs]</div>\n";
		}
		
	}else{
		$id = get_id_string($obj['name']);
		echo "<div class=\"docs\" id=\"$id\">$obj[docs]</div>\n";
	}
}
?>
        </div>
    </body>
</html>
