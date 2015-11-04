<!DOCTYPE html>

<!-- Author: Cameron Block 
     Class: CIS 337 Web Scripting
     File: Assignment_7_2.html
     Purpose: To use PHP and Ajax, Exercises 9.10 - 10.3
     -->

<html lang = "en">
  <head>
    <title> Assignment 6.2 </title>
  	<meta charset = "utf-8" />
		<!--<?php
			//Exercise 9.9
			//Exercise 9.10
			//Exercise 10.2
			//Exercise 10.3
		?>-->
	</head>
	
	<body>
		<h1>Assignment 7.2</h1>
		
		<!-- From here out am using sub folders for subsequent assignments. 
				Should have started this a little earlier, but I was busy. 
				.. works for previous directory, and looks like you can insert
				spaces in anchor file paths. 
				-->
		<img src = "../Images/Master.jpg" height = "145" alt = "Picture of me. " />
		
		<?php
			//Exercise 9.10
			print "<h2>Exercise 9.9/9.10</h2>";
			$SALES_TAX = .062;//6.2 percent sales tax
			
			$bulbLabels = array("Four 25-watt light bulbs", 
								"Eight 25-watt light bulbs", 
								"Four 25-watt long-life light bulbs", 
								"Eight 25-watt long life light bulbs");
			// $bulbCost = array($_POST["chkBulbs1"], 
							  // $_POST["chkBulbs2"], 
							  // $_POST["chkBulbs3"], 
							  // $_POST["chkBulbs4"]);
								
			$total = 0.00;
			$userName = $_POST["txtUserName"];
			$payment = $_POST["payment"];
			
			//Found something online where the previous page could return an array
			//by changing name = "chkSomething" to name = "chkSomething[]", doesn't
			//seem to work very well in practice. 
			
			print "<table>";
			// for($i = 0 ; $i < count($bulbLabels) ; $i++){
				// //Don't put assignments in the parameters of if statements like other langs
				// if(isset($bulbCost[$i])){
					// //print the table
					// print "<tr><td>" . $bulbLabels[$i] . "</td><td>" . $bulbCost[$i] . "</td></tr>";
					// //accumulate the total
					// $total += (float)$bulbCost[$i] + (float)$bulbCost[$i] * $SALES_TAX;
				// }
			// }//end loop
			
			if(isset($userName) && isset($payment)){
				//display userName type
				print "<h3>User Name: " . (string)$userName . "</h3>";
				
				$bulbCost = $_POST["chkBulbs1"];
				if(isset($bulbCost)){
					print "<tr><td>" . $bulbLabels[0] . "</td><td>" . $bulbCost . "</td></tr>";
					$total += (float)$bulbCost + (float)$bulbCost * $SALES_TAX;
				}
				$bulbCost = $_POST["chkBulbs2"];
				if(isset($bulbCost)){
					print "<tr><td>" . $bulbLabels[1] . "</td><td>" . $bulbCost . "</td></tr>";
					$total += (float)$bulbCost + (float)$bulbCost * $SALES_TAX;
				}
				$bulbCost = $_POST["chkBulbs3"];
				if(isset($bulbCost)){
					print "<tr><td>" . $bulbLabels[2] . "</td><td>" . $bulbCost . "</td></tr>";
					$total += (float)$bulbCost + (float)$bulbCost * $SALES_TAX;
				}
				$bulbCost = $_POST["chkBulbs4"];
				if(isset($bulbCost)){
					print "<tr><td>" . $bulbLabels[3] . "</td><td>" . $bulbCost . "</td></tr>";
					$total += (float)$bulbCost + (float)$bulbCost * $SALES_TAX;
				}
				print "</table>\n";
				
				//display the total
				print "<h3>Total: " . (string)round($total, 2) . "</h3>";
				//display payment type
				print "<h3>Payment Type: " . (string)$payment . "</h3>";
			}
			else {//username and payment not set
				print "<h3>Please fill out form correctly...</h3>";
			}
			
			//Exercise 10.2
			print "<h2>Exercise 10.2</h2>";
			print "<p>The callback function is written as an anonymous function in the request phase function to allow access to the XHR object, and to prevent multiple requests from overwriting the XHR object through the creation of another instance. </p>";
			//Exercise 10.3
			print "<h2>Exercise 10.3</h2>";
			print "<a href = \"popcornA.html\">popcornA.html</a>";
		?>
	</body>
</html>