/* Author: Cameron Block
 * File: Purchase.java
 * Intermediate Java I
 * Purpose: to create a class that describes a purchase and includes an 
 * 		invoice number, amount of sale, and amount of sales tax with set 
 * 		methods for invoice number and sale amount.   
 * */

import javax.swing.JOptionPane;
import java.util.ArrayList;

public class Purchase {
	private int invoiceNum;
	private double saleAmt, saleTaxAmt;
	
	public static final double SALES_TAX_RATE = .075;//7.5 percent
	//the above was in error with the value .75 which is 75%, not 7.5%
	
	//include set methods for invoice number and sale amount. 
	public void setInvoiceNum(int invoiceNum){
		this.invoiceNum = invoiceNum;
	}
	
	public void setSaleAmt(double saleAmt){
		this.saleAmt = saleAmt;
		saleTaxAmt = this.saleAmt * SALES_TAX_RATE;
	}
	
	//Include a method a display method that displays a purchase's details 
	//in a well formatted output display.
	public String toString(){
		return "Invoice Number: " + invoiceNum + " \n"
				+ "Sale Amount: " + saleAmt + " \n"
				+ "Sale Tax Amount:" + saleTaxAmt + " \n";
	}
	
	public static void main(String [] args){
		ArrayList<Purchase> purchases = new ArrayList<Purchase>();
		double saleAmt = 0.0;
		int invoiceNum = 1;
		//Get some input
			//Use event driven loop would you like to continue y/n GUI
		try{
			do{
				Purchase p = new Purchase();
				
				saleAmt = Integer.parseInt(JOptionPane.showInputDialog(null, 
						"Please enter sale amount: ", "Sale Amount", 
						JOptionPane.QUESTION_MESSAGE));
				
				//set the variables in the Purchase object
				p.setInvoiceNum(invoiceNum);
				p.setSaleAmt(saleAmt);
				
				//add the Purchase object to the array list
				purchases.add(p);
				
				//invoice number determined by iterator
				invoiceNum++;
			}while(JOptionPane.YES_OPTION == JOptionPane.showConfirmDialog(null,  
					"Would you like to continue?", "Continue?", 
					JOptionPane.YES_NO_OPTION));
		}catch(NumberFormatException ex){}
		//eat the exception, is hitting cancel button
		
		//Output the results
		for(Purchase p : purchases)
			System.out.println(p);
		
		//Alternate GUI results 
		JOptionPane.showMessageDialog(null, new javax.swing.JList(
				purchases.toArray()));
	}//end main
	
}//end class
