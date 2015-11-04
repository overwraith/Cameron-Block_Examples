/* Author: Cameron Block
 * File: Numbers.java
 * Intermediate Java I
 * Purpose: To create a program that sums and differences two numbers and 
 * demonstrates the use of methods and other learned java features. 
 * */
import java.util.Scanner;

public class Numbers {
	private static int arg1 = 0, arg2 = 0;
	
	public static void main (String [] args){
		
		Scanner sc = new Scanner(System.in);
		
		//The following loop and try/catch prompts user to enter correct 
		//data infinitely until the user follows the prompts instructions. 
		while(true){
			try{
				System.out.print("Please Enter two integers seperated by a " 
						+ "space or newline: ");
				arg1 = sc.nextInt();
				arg2 = sc.nextInt();
				break;
			}catch(Exception ex){
				System.out.println("Input error, please try again. ");
				sc.nextLine();
			}
		}//end loop
		
		System.out.println("The sum of the two numbers is: " 
				+ sum(arg1, arg2));
		System.out.println("The difference of the two numbers is" 
				+ difference(arg1, arg2));
	}//end method
	
	public static int sum(int arg1, int arg2){
		return arg1 + arg2;
	}//end method
	
	public static int difference(int arg1, int arg2){
		return arg1 - arg2; 
	}//end method
}//end class
