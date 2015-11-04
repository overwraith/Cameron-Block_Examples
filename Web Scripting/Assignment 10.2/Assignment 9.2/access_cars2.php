<!-- Author: Cameron Block 
     Class: CIS 337 Web Scripting
     File: access_cars2.php
     Purpose: Page for accessing a cars database. 
     -->
	 
<!DOCTYPE html>

<html lang = "en">
	<head>
		<title> Access the cars database with MySQL </title>
		<meta charset = "utf-8" />
	</head>
	
	<body>
		<?php
			$stage = $_POST["stage"];
			if(!IsSet($stage)){
		?>
		<p>
			Please enter your query: 
			<br />
			<form method = "POST" action = "access_cars2.php" >
				<textarea rows = "2" cols = "80" name = "query">
				</textarea>
				<br />
				<br />
				<input type = "hidden" name = "stage" value = "1" />
				<input type = "submit" value = "Submit request" />
			</form>
		</p>
		<?php
				} else { //$stage was set, so process the query
				
				//connect to MySQL
				$db = mysqli_connect("localhost", "root", "1qaz!QAZ", "cars");
				if(mysqli_connect_errno()){
					print "Connect failed: " . mysqli_connect_error();
					exit();
				}
				
				//get the query and clean it up, delete leading and trailing 
				//whitespace and remove backslashes from magic_quotes_gpc
				$query = $_POST['query'];
				trim($query);
				$query = stripslashes($query);
				
				//display the query, after fixing html characters
				$query_html = htmlspecialchars($query);
				print "<p> The query is: " . $query_html . "</p>";
				
				//Execute the query
				$result = mysqli_query($db, $query);
				if(!$result){
					print "Error - the query could not be executed" . 
						mysqli_error();
					exit;
				}
				
				//display the results in a table
				print "<table><caption> <h2> Query Results </h2> </caption>";
				print "<tr align = 'center'>";
				
				//get the number of rows in the result
				$num_rows = mysqli_num_rows($result);
				$num_affected = mysqli_affected_rows($db);
				
				//if there are rows in the result, put them in an HTML table
				if($num_rows > 0){
					$row = mysqli_fetch_assoc($result);
					$num_fields = mysqli_num_fields($result);
					
					//produce the column labels
					$keys = array_keys($row);
					for($index = 0 ; $index < $num_fields ; $index++)
						print "<th>" . $keys[$index] . "</th>";
					
					print "</tr>";
					
					//output the values of the fields in the rows
					for($row_num = 0 ; $row_num < $num_rows ; $row_num++){
						print "<tr>";
						
						$values = array_values($row);
						for($index = 0 ; $index < $num_fields ; $index++){
							$value = htmlspecialchars($values[$index]);
							print "<td>" . $value . "</td>";
						}
						
						print "</tr>";
						$row = mysqli_fetch_assoc($result);
					}//end loop
				}
				elseif($num_affected > 0){
					//print the number of affected rows
					//no real way to select the affected rows after deletion or updating
					
					//print the number of affected rows in the table so
					//caption does not float above the output text. 
					print "<tr><td>Affected Rows " . $num_affected . "</td></tr><br />";
				}
				else {
					print "There were no such rows in the table <br />";
				}
				print "</table>";
			}//end if (stage set)
		?>
	</body>
</html>
