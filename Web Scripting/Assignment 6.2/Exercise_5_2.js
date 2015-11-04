 /* Author: Cameron Block 
	Class: CIS 337 Web Scripting
	File: Exercise_5_2.js
	Purpose: creates radio buttons that control color choice. 
 */

//	The event handler for a radio button collection
function colorChoice() {
	var color;
	// Put the DOM address of the elements array in a local variable
	var dom = document.getElementById("myForm");
	
	// Determine which button was pressed
	for(var i = 0; i < dom.colorButton.length; i++){
		if(dom.colorButton[i].checked){
			//obtain color from value property
			color = dom.colorButton[i].value;
			break;
		}
	}//end loop
	
	if(typeof color === "string"){
		var str = "Color choice: " + color;
		alert(str);
	}
}//end function

//register the handlers for the color buttons
for(var i = 0, dom = document.getElementById("myForm"); i < dom.colorButton.length; i++){
	dom.colorButton[i].onclick = colorChoice;
}//end loop