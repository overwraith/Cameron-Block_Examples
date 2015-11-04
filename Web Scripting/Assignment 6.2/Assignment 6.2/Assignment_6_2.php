<!DOCTYPE html>

<!-- Author: Cameron Block 
     Class: CIS 337 Web Scripting
     File: Assignment_6_2.html
     Purpose: To use PHP, Exercises 9.1 - 9.7
     -->

<html lang = "en">
  <head>
  	<title> Assignment 6.2 </title>
		<meta charset = "utf-8" />
		<?php
			//Exercise 9.1
			function uniqueVals($strArr){
				//check if value is an array
				if(!is_array($strArr))
					return NULL;
				
				//return unique values, AKA eliminate duplicates
				
				//sort the array, this sort method sorts strings too
				sort($strArr);
				
				for($i = 0; $i < sizeof($strArr); $i++){
					//don't allow garbage input
					if(gettype($strArr[$i]) != "string")
						return NULL;
					//if previous value equals current delete current
					
					//because everything automatically passed by value
					//don't have to worry about the original array being 
					//modified. 
					if($strArr[$i - 1] == $strArr[$i])
						unset($strArr[$i]);
				}//end loop
				
				return $strArr;
			}//end function
			
			//Exercise 9.2
			function avg_and_median($numArr, &$avg, &$median){
				$avg = array_sum($numArr) / count($numArr);
				
				sort($numArr);
				
				if((count($numArr) % 2) > 0)//odd number of values
					$median = ceil($numArr[count($numArr) / 2]);
				else//even number of values
					$median = ($numArr[floor(count($numArr) / 2) - 1] + $numArr[floor(count($numArr) / 2)]) / 2;
						//have to subtract one in the first index due to arrays starting at 0
			}//end function
			
			class Entity{
				private $key;
				private $value;
					
				//setters
				public function setKey($key){
				  if(is_string($key))
							  $this->key = $key;
				  else
					throw new InvalidArgumentException("This function only supports string arguments...");
				}
					
				public function setValue($value){
				  if(is_int($value))
					$this->value = $value;
				  else
					throw new InvalidArgumentException("value should be an integer...");
				}
					
				//getters
				public function getKey(){
					return $this->key;
				}
				
				public function getValue(){
					return $this->value;
				}
					
				public function __construct($key, $value) {
				  if(is_string($key))
					$this->key = $key;
				  else
					throw new InvalidArgumentException("key should be a string...");
				  
				  if(is_int($value))
					$this->value = $value;
				  else
					throw new InvalidArgumentException("value should be an integer...");
				}
			}//end class
			  
			function compareTo($obj1, $obj2){
			
			  if($obj1->getValue() == $obj2->getValue())
				return 0;
			
			  return $obj2->getValue() - $obj1->getValue();
			}//end function
					
			//Exercise 9.3
			function mostCommonWords($strArr){
				//check if value is an array
				if(!is_array($strArr))
					return NULL;
							
				//***Count the number of entrys for each word***
				  
				//first value automatically in the list to prevent pushing values to a null array
				for($i = 1, $dictionary = array(new Entity($strArr[0], 1)); $i < count($strArr) ; $i++){
					//print("{$strArr[$i]}, <br />");
				  
					//don't allow garbage input
					if(gettype($strArr[$i]) != "string")
						return NULL;
					
					$j = 0;
					for(; $j < count($dictionary) ; $j++){
						//print("Counting...{$j}<br />");
						//Don't use == in php for strings. Ouch...
						if(strcmp($strArr[$i] , $dictionary[$j]->getKey()) == 0 ){//traverse dictionary, if there's a match, increment
							//print("Match found: {$strArr[$i]}<br />");
							$dictionary[$j]->setValue($dictionary[$j]->getValue() + 1);
							break;
						}
					}//end inner loop
							
					if(($j == count($dictionary)) ){//if end of dictionary list, create new entry
						//print("Creating new entry: {$strArr[$i]}<br />");
						array_push($dictionary, new Entity($strArr[$i], 1));
					}
				}//end loop
				
				/*try{
				for($i = 0 ; $i < count($dictionary) - 1; $i++){
				  print("" . $dictionary[$i]->getKey() . $dictionary[$i]->getValue(). "<br />");
				  if($i != count($dictionary))
					print("Compare Result: " . compareTo($dictionary[$i], $dictionary[$i + 1]) . "<br />"); 
				}
				}catch(Exception $ex){
				  //swallow the exception
				  //apparently exceptions don't work as well in php
				}*/
				
				//sort the most used words at the top, maintain index association
				uasort($dictionary, "compareTo");
				
				//put the 3 values in an array
				$arr = array($dictionary[0]->getKey(), $dictionary[1]->getKey(), $dictionary[2]->getKey());
				
				//return the array
				return $arr;
						
			}//end function
			
			//Exercise 9.4
			function array_Split($values, &$posValues, &$negValues){
			
				//put a dummy value on front to prevent pushing to non existent value
				array_push($posValues, 1);
				array_push($negValues, -1);
				
				//loop through and separate the values
				for($i = 0 ; $i < count($values) ; $i++){
					if($values[$i] > 0)
						array_push($posValues, $values[$i]);
					if($values[$i] < 0)
						array_push($negValues, $values[$i]);
				}//end loop
				
				unset($posValues[0]);
				unset($negValues[0]);
				
				return;
			}//end function
      
			//Exercise 9.5
			function firstNum($input){
				//make sure data is a string
				if(!is_string($input))
				  return NULL;


				$str = strtok($input, " ");

				while($str !== false){
				  if(preg_match("/\d{4}/", $str))
					return intval($str);
					
				  $str = strtok(" ");
				}//end loop

				return false;
			}//end function
      
			//Exercise 9.6
			function mostCommonWords_MK2($str){
				//make sure data is a string
				if(!is_string($str))
				  return NULL;

				//replace all delimiters with a space
				$str = str_replace(array(",", ".", "?", ";", ":", "\""), " ", $str);

				//convert input string into an array delimited by punctuation and whitespace
				$strArr = explode(" ", $str);

				//eliminate words less than 3 chars
				foreach($strArr as $word){
					if(strlen($word) <= 3)
						unset($word);
				}//end loop

				return mostCommonWords($strArr);
			}//end function
		?>
	</head>
	
	<body>
		<h1>Assignment 6.2</h1>
		
		<!-- From here out am using sub folders for subsequent assignments. 
				Should have started this a little earlier, but I was busy. 
				.. works for previous directory, and looks like you can insert
				spaces in anchor file paths. 
				-->
		<img src = "../Images/Master.jpg" height = "145" alt = "Picture of me. " />
		
		<?php
			//Exercise 9.1
			print("<h2>Exercise 9.1</h2> <br />");
			
			print("Array Original values: <br />");
			print_r(array("b", "a", "b", "d", "c"));
			print("<br />");
			
			print("Array Unique values: <br />");
			print_r(uniqueVals(array("b", "a", "b", "d", "c")));
			print("<br />");
			
			//Exercise 9.2
			print("<h2>Exercise 9.2</h2> <br />");
			
			$arr = array(3, 5, 7, 12, 13, 14, 21, 23, 23, 23, 23, 29, 39, 40, 56);
			print("Array input values: <br />");
			print_r($arr);
			print("<br />");
			
			$avg = 0;
			$median = 0;
			avg_and_median($arr, $avg, $median);
			print("The average is {$avg}, and the median is {$median}<br /><br />");
			
			
			$arr = array(3, 13, 7, 5, 21, 23, 23, 40, 23, 14, 12, 56, 23, 29);
			print("Array input values: <br />");
			print_r($arr);
			print("<br />");
			
			$avg = 0;
			$median = 0;
			avg_and_median($arr, $avg, $median);
			print("The average is {$avg}, and the median is {$median}<br /><br />");
			
			//Exercise 9.3
			print("<h2>Exercise 9.3</h2> <br />");
			$arr = array("Pineapple", "Raspberry", "Pineapple", "Banana", "Kumquat", "Pineapple");
			print("The input array is: <br />");
			print_r($arr);
			print("<br />");
			print("The most common words are: <br />");
			print_r(mostCommonWords($arr));
			print("<br />");
			
			//Exercise 9.4
			print("<h2>Exercise 9.4</h2> <br />");
			$arr = array(-1, -2, -3, 1, 2, 3, 4);
			$posValues = array();
			$negValues = array();
			array_Split($arr, $posValues, $negValues);
			print("Array values: <br />");
			print_r($arr);
			print("<br />");
			print("Positive Array: <br />");
			print_r($posValues);
			print("<br />");
			print("Negative Array: <br />");
			print_r($negValues);
	
			//Exercise 9.5
			print("<h2>Exercise 9.5</h2> <br />");
			$input = "100 200 4000";
			print("Input string is:" . $input ." <br />");
			print("First 4 digit num is: " . firstNum($input));
			print("<br />");
			
			//Exercise 9.6
			print("<h2>Exercise 9.6</h2> <br />");
			$str = "Pineapple Raspberry,Pineapple.Banana?Kumquat:Pineapple;Raspberry the the the the the";
			print("Input string is:" . $str ." <br />");
			print("Most common words are: <br />");
			print_r(mostCommonWords_MK2($str));
			print("<br />");
			
			//Exercise 9.7
			print("<h2>Exercise 9.7</h2> <br />");
			
			include 'word_table.php';
			
		?>
	</body>
</html>