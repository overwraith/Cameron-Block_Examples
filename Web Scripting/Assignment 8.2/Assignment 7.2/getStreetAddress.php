<?php
//getStreetAddress.php
//	Gets the addresses of 'previous' visitors. 

//Our scripts are not executed with the ability to create files. 

//I am interpreting this problem to mean that I should implement
//the functionality to return states based on a customer name of 
//repeat customers, and not that I have to implement the behaviour that 
//actually records the repeat customers. If I am wrong, and I should
//have implemented more, then the book should be rewritten, or should 
//specify how we are to record the data. There are only a few ways to 
//persist data for repeat customers, files, cookies, etc, and none 
//are available to us at this point in time (except maybe cookies). 

//So basically we are pretending to return data from a database here. 

$addresses = array("James" => "5555 Harrison St. ", 
				   "John" => "5555 Emiline St. ", 
				   "Robert" => "5555 Gertrude St.", 
				   "Michael" => "5555 Josephine St. ", 
				   "William" => "5555 Olive St. ", 
				   "David" => "5555 Lillian St. ", 
				   "Richard" => "5555 Margo St. ",  
				   "Charles" => "5555 Josephine St. ", 
				   "Joseph" => "5555 Olive St. ", 
				   "Thomas" => "5555 Drexel St. ", 
				   "Christopher" => "5555 Madison St. ");
header("Content-Type: text/plain");
$name = $_GET["name"];
if(array_key_exists($name, $addresses))
	print $addresses[$name];
else
	print "";

?>