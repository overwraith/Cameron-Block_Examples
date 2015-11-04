/* Author: Cameron Block
 * File: Savings.java
 * Intermediate Java I
 * Purpose: to create a savings class that extends the abstract class Account. 
 * */

import java.util.Scanner;

public class Savings extends Account{
	private double interestRate;
	
	public Savings(int acctNum, double interestRate) {
		super(acctNum);
		this.interestRate = interestRate;
	}
	
	public void setInterestRate(double interestRate){
		this.interestRate = interestRate;
	}

	public int getAcctNum() {
		return this.acctNum;
	}

	public double getBalance() {
		return this.acctBal;
	}

	public double getInterestRate(){
		return this.interestRate;
	}
	
	public String toString(){
		
		StringBuilder str = 
				new StringBuilder("Savings Account Information\n");
		
		str.append("Account number: ").append(this.acctNum).append("\n");
		str.append("Account Interest Rate: ").append(this.interestRate)
			.append("\n");
		str.append("Account balance: ").append(this.acctBal).append("\n");
		
		
		return str.toString();
	}
	
	public static Savings readSavingsAcct(){
		Scanner sc = new Scanner(System.in);
		
		System.out.println("Please Input Checking Account Information: ");
		System.out.print("Account Number: " + i + "\n");
		
		
		
		double interestRate = readDouble(sc, "Account Interest Rate: ", 
				"Input a valid floating point number. . . \n");
		
		double balance = readDouble(sc, "Account Balance: ", 
				"Input a valid floating point number. . . \n");
		
		Savings acct = new Savings(i, interestRate);
		acct.setBalance(balance);
		
		System.out.println();
		
		i++;
		
		return acct;
	}
	
}//end class
