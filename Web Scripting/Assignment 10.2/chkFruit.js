/*
Author: Cameron Block 
Class: CIS 337 Web Scripting
File: chkFruit.js
Purpose: A fruit price accumulator. 
 */
 
//The accumulator variable
var total = 0.00;

var SALES_TAX = .05;//5% sales tax

function chkApple() {
	//get DOM address of myForm
	var dom = document.getElementById("myForm");
	
	//determine if the button was checked or unchecked
	if(dom.fruitButton[0].checked == true){
		total += .59;//cents
	}
	else{
		total -= .59;//cents
	}
}//end function

function chkOrange() {
	//get DOM address of myForm
	var dom = document.getElementById("myForm");
	
	//determine if the button was checked or unchecked
	if(dom.fruitButton[1].checked == true){
		total += .49;//cents
	}
	else{
		total -= .49;//cents
	}
}//end function

function chkBanana() {
	//get DOM address of myForm
	var dom = document.getElementById("myForm");
	
	//determine if the button was checked or unchecked
	if(dom.fruitButton[2].checked == true){
		total += .39;//cents
	}
	else{
		total -= .39;//cents
	}
}//end function

function submit() {
	//5% sales tax
	total += total * SALES_TAX;
	
	//round up 2 decimal places
	total = Math.round(total * 100) / 100;
	
	//display the results
	alert("Your total cost is $" + total);
	
	//reset everything
	total = 0.00;
	
	//reset the check boxes
	for(var i = 0, dom = document.getElementById("myForm"); i < dom.fruitButton.length; i++ )
		dom.fruitButton[i].checked = false;
	
	return false;//don't contact the server
}//end function

document.getElementById("myForm").onsubmit = submit;