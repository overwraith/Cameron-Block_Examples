//function getPlace
//	parameter: zip code
//	action: create the XMLHttpRequest object, register the 
//			handler for onreadystatechange, prepare to send 
//			the request (with open), and send the request, 
//			along with the zip code, to the server. 
//	includes: the anonymous handler for onreadystatechange, 
//			which is the receiver function, which gets the 
//			response text, splits it into city and state, 
//			and puts them into the document. 

function getPlace(zip){
	var xhr = new XMLHttpRequest();
	xhr.onreadystatechange = function () {
		if(xhr.readyState == 4 && xhr.status == 200){
			var result = xhr.responseText; 
			var place = result.split(', ');
			if(document.getElementById("city").value == "")
				document.getElementById("city").value = place[0];
			if(document.getElementById("state").value == "")
				document.getElementById("state").value = place[1];
		}
	}//end anonymous function
	xhr.open("GET", "getCityState.php?zip=" + zip, true);
	xhr.send(null);
}//end function

//Exercise 10.3
//get the street address based on a given name of repeat customers
function getAddress(name){
	var xhr = new XMLHttpRequest();
	xhr.onreadystatechange = function () {
		if(xhr.readyState == 4 && xhr.status == 200){
			var address = xhr.responseText;
			
			//get the return address
			if(document.getElementById("address").value == "")
				document.getElementById("address").value = address;
		}
	}//end anonymous function
	xhr.open("GET", "getStreetAddress.php?name=" + name, true);
	xhr.send(null);
}//end function