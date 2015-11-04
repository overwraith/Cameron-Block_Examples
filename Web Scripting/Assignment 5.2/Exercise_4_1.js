/*
Author: Cameron Block 
Class: CIS 337 Web Scripting
File: Exercise_4_1.js
Purpose: Lots of requirements, no general purpose. 
 */
function formatTable(table, start, end){
//This function makes a string representation of the array table. 
//would format the table like this if the browser software didn't
//mess up the display string. 
//  5   6   7   8   9   10   11   12   13   14   15
// 25  36  49  64  81  100  121  144  169  196  225
//125 216 343 512 729 1000 1331 1728 2197 2744 3375
var str = '';
var delim = ' ';//delimits the columns

	for(var j = 0 ; j < 3 ; j++){
		for(var i = start; i < end + 1; i++){
			//determine the max delimiter number the column should have
			var biggest_len = biggestValue(table, i, 3).toString().length;
			
			if(i == start){//start column needs one less length
				biggest_len--;
			}
			str += String(strDelims(biggest_len, delim) + table[i][j]).slice(-(biggest_len + 1));
		}
		str += '\n';
	}
	return str;
}//end function

function strDelims(size, delim){
//returns a string of the specified length
	var str = '';
	for(var i = 0 ; i < size ; i++){
		str += delim;
	}
	return str;
}//end function

function biggestValue(table, column, column_size){
	//determines the biggest member of a column
	var biggest = 0;
	for(var i = 0 ; i < column_size ; i++){
		if(table[column][i] > biggest){
			biggest = table[column][i];
			}
	}
	return biggest;
}//end function

//Exercise 4.1
document.write('</br>');
document.write('Exercise 4.1</br>');

var start = 5;
var end = 15;

//initialize array to length required
var table = new Array(end);

//make the array 2d, uninitialized array values don't take up space
for(var i = start ; i < end + 1 ; i++){
	table[i] = new Array(3);
	
	//set top value to index
	table[i][0] = i;			
	
	//calculate the square
	table[i][1] = Math.pow(table[i][0], 2);
	
	//calculate the cube
	table[i][2] = Math.pow(table[i][0], 3);
}

//Had to tweak the padding in order to get this in a semi acceptable format
//Unfortunately depending on which browser you use the size of the alert box
//changes. If you copy and paiste into notepad, the tables line up exactly
//For some reason toward the end of the table though the formatting doesn't work.
//Not really my fault, is the way the browser displays the data. 
alert(formatTable(table, start, end));
//var str = '';
//for(var j = 0 ; j < 3 ; j++){
//	for(var i = start; i < end + 1; i++){
//		if(i == start){//start column only needs column length of 3
//			str += String("   " + table[i][j]).slice(-3);
//		}
//		else {//subsequent columns need at least 5
//			str += String("     " + table[i][j]).slice(-5);
//		}
//	}
//	str += '\n';
//}
//display the alert
//alert(str);