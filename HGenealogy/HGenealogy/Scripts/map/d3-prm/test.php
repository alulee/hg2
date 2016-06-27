<?php
	
	require_once("DB_config.php");
	require_once("DB_class.php");

	$data1 = array();
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

	var_dump($data1);
?>