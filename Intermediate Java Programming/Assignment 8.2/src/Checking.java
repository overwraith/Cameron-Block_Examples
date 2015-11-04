/* Author: Cameron Block
 * File: Checking.java
 * Intermediate Java I
 * Purpose: to create a checking class that extends the abstract class Account. 
 * */

import java.util.Scanner;

public class Checking extends Account{

	public Checking(int acctNum) {
		super(acctNum);
	}

	public int getAcctNum() {
		
		return acctNum;
	}

	public double getBalance() {
		
		return acctBal;
	}
	
	public String toString(){
		
		StringBuilder str = 
				new StringBuilder("Checking Account Information\n");
		
		str.append("Account number: ").append(this.acctNum).append("\n");
		str.append("Account balance: ").append(this.acctBal).append("\n");
		
		return str.toString();
	}
	
	public static Checking readCheckingAcct(){
		Scanner sc = new Scanner(System.in);
		
		
		System.out.println("Please Input Checking Account Information: ");
		System.out.print("Account Number: " + i + "\n");
		
		Checking acct = new Checking(i);
		
		acct.setBalance(readDouble(sc, "Account Balance: ", 
				"Input a valid floating point number. . . \n"));
		
		System.out.println();
		
		i++;
		
		return acct;
	}
	
}//end class
