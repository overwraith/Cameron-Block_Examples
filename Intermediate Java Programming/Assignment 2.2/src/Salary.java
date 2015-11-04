/*Author: Cameron Block
 * File: Salary.java
 * Intermediate Java I
 * Purpose: To create a program that calculates an employees wages using 
 * specific input variables. 
 * */
import java.text.NumberFormat;
import javax.swing.JOptionPane;

public class Salary {
	   public static void main(String[] args)
	   {
		   //Earns $25 an hour
		   //Works 40 regular hours.
		   //Works 13 overtime hours. 
		   
		   NumberFormat currency = NumberFormat.getCurrencyInstance();
		   final double HOURLY_WAGE = 25.00;
		   final int REGULAR_HOURS = 40;
		   final int OVERTIME_HOURS = 13;
		   
		   System.out.println("Hourly Wage: " + currency.format(HOURLY_WAGE));
		   System.out.println("Regular Hours: " + REGULAR_HOURS);
		   System.out.println("Overtime Hours: " + OVERTIME_HOURS);
		   System.out.println("Weekly Pay: " + currency.format(
				   calcSalary(HOURLY_WAGE, REGULAR_HOURS, OVERTIME_HOURS)));
		   
	   }//end method
	
	   //Create a separate method to do the calculation and return the
	   //result to the main method to be displayed. 
	   public static double calcSalary(double HOURLY_WAGE, int REGULAR_HOURS, 
			   int OVERTIME_HOURS){
		   //Wage * 1.5 for overtime hours worked.
		   //return weekly pay. 
		   return HOURLY_WAGE * REGULAR_HOURS 
				   + HOURLY_WAGE * 1.5 * OVERTIME_HOURS; 
		}//end method
	
}//end class

