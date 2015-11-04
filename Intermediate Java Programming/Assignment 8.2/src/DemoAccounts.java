/* Author: Cameron Block
 * File: DemoAccounts.java
 * Intermediate Java I
 * Purpose:  To demonstrate how to use Checking and Savings accounts 
 * 				extended from the abstract class Account. 
 * */

import java.io.IOException;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Scanner;

public class DemoAccounts {
	
	public static void main(String [] args){
		ArrayList<Account> list = new ArrayList<Account>();
		Scanner sc = new Scanner(System.in);
		
		
		while(true){
			
			String str = readString(sc, "Would you like a [Checking] account or a " 
					+ "[Savings] account: ", 
					"Please input the word [Checking] or [Savings]. . . \n", 
					new String[]{"Checking", "Savings"});
			
			System.out.println();
			
			if(str.equalsIgnoreCase("Checking"))
				list.add(Checking.readCheckingAcct());
			else if(str.equalsIgnoreCase("Savings"))
				list.add(Savings.readSavingsAcct());
			
			String decision = readDecision(sc, "Would you like to continue? ", 
					"Please input a yes/no answer. . . \n\n");
			
			System.out.println();
			
			if(decision.equalsIgnoreCase("Yes") 
					|| decision.equalsIgnoreCase("Y")){
				continue;
			}
			else if(decision.equalsIgnoreCase("No") 
					|| decision.equalsIgnoreCase("N"))
				break;
			
		}//end loop
		
		
		for(Account acct : list){
			System.out.println(acct.toString());
		}//end loop
		
	}//end main
	
	public static String readString(Scanner sc, String prompt, String errorMsg, 
			String options[]){
		while(true){
			try{
				System.out.print(prompt);
				String input = sc.next();
				for(String str : options)
					if(str.equalsIgnoreCase(input))
						return input;
				throw new Exception();
			}catch(Exception ex){
				System.out.println(errorMsg);
				sc.nextLine();
			}//end catch
			
		}//end loop
		
	}//end method
	
	public static String readDecision(Scanner sc, String prompt, 
			String errorMsg){//Reads a yes/no statement. 
		while(true){
			try{
				System.out.print(prompt);
				String str = sc.next();
				if(str.equalsIgnoreCase("Yes") || str.equalsIgnoreCase("No") 
						|| str.equalsIgnoreCase("Y") 
						|| str.equalsIgnoreCase("N"))
					return str;
				else
					throw new Exception();
			}catch(Exception ex){
				System.out.println(errorMsg);
				sc.nextLine();
			}//end catch
		}//end loop		
	}//end method

}//end class
