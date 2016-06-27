<?php

class DB 
{
    var $_dbConn = 0;
    var $_queryResource = 0;
    
    function DB()
    {
        //do nothing
    }
    
    function connect_db($host, $user, $pwd, $dbname)
    {
        
		//$dbConn = mysqli_connect($host, $user, $pwd, $dbname);
		$dbConn = new mysqli($host, $user, $pwd, $dbname);
		if (mysqli_connect_errno()) 
			die ("MySQL Connect Error");
		 
		mysqli_query($dbConn, "SET NAMES utf8");
		
		$this->_dbConn = $dbConn;
		return true;
	
	}
    
    function query($sql)
    {
        if ($stmt = mysqli_prepare($this->_dbConn, $sql)) {

			return mysqli_query($this->_dbConn, $query);
		}
	 
    }
    
    /** Get array return by MySQL */
    function fetch_array($sql)
    {
		return mysqli_query($this->_dbConn, $sql);			
		
		// if ($result = mysqli_query($this->_dbConn, $sql)) {
			// /* fetch associative array */
			// while ($row = mysqli_fetch_assoc($result)) {
				
				// $host = $row["host"];
			// }
		// }	
    }
    
    function get_num_rows()
    {
        //return mysql1_num_rows($this->_queryResource);
    }

    /** Get the cuurent id */    
    function get_insert_id()
    {
        //return mysqli_insert_id($this->_dbConn);
    } 
    
}
?>