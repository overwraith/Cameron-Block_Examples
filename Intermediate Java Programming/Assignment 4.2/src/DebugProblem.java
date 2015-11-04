/* Author: Cameron Block
 * File: DebugProblem.java
 * Intermediate Java I
 * Purpose: to create a brain teaser for the class. 
 * */
public class DebugProblem {

	public static void main(String[] args) {
		String str = "";
		int myArr[] = new int[10];
		
		//initialize the array to numbers 1-10
		for(int i = 0 ; i < myArr.length ; i++)
			myArr[i] = i;
		
		//make output look like 1, 2, 3, 4, 5, 6, 7, 8, 9, 10
		for(int i = 0 ; i < myArr.length ; i++)
			str = myArr[i] + (i == myArr.length - 1 ? ", " : "");
		
		System.out.println(str);
		
	}

}//end class

/*SOLUTION
 * public class DebugProblem {

	public static void main(String[] args) {
		String str = "";
		int myArr[] = new int[10];
		
		//initialize the array to numbers 1-10
		for(int i = 0 ; i < myArr.length ; i++)
			myArr[i] = i + 1;//removed the +1 here
		
		//make output look like 1, 2, 3, 4, 5, 6, 7, 8, 9, 10
		for(int i = 0 ; i < myArr.length ; i++)
			str += myArr[i] + (i == myArr.length - 1 ? "" : ", ");//the arguments here were swapped logical error
			//should be 'str +=', not '=' logical error
		
		System.out.println(str);
	}

}//end class
*/