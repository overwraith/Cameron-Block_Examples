/* Author: Cameron Block
 * File: Account.java
 * Intermediate Java I
 * Purpose:  to create an abstract class that can be used in processing 
 * 				account information.  
 * */

import java.util.Scanner;

public abstract class Account {
	protected int acctNum; 
	protected double acctBal;
	
	protected static int i = 1;
	//Account number iterator for input methods in Checking and Savings. 
	
	public Account(int acctNum){
		this.acctNum = acctNum; 
		acctBal = 0.0; 
	}
	
	public void setBalance(double acctBal){
		this.acctBal = acctBal;
	}
	
	public abstract int getAcctNum();
	//Instructions flawed, using this as a traditional getter method.
	
	public abstract double getBalance();
	//Instructions flawed, using this as a traditional getter method. 
	
	//toString() will act as our display method.
	
	public static double readDouble(Scanner sc, String prompt, String errorMsg){
		while(true){
			try{
				System.out.print(prompt);
				return sc.nextDouble();
			}catch(Exception ex){
				System.out.println(errorMsg);
				sc.nextLine();
			}//end catch
			
		}//end loop
		
	}//end method
	
}//end class
