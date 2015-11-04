/* Author: Cameron Block
 * File: ExtGregorianCalendar.java
 * Intermediate Java I
 * Purpose: A program that demonstrates extending the GregorianCalendar class 
 * 		with toString() functionality.   
 * */
import java.util.Calendar;
import java.util.GregorianCalendar;

public class ExtGregorianCalendar extends GregorianCalendar {
	
	public static void main(String [] args){
		ExtGregorianCalendar now = new ExtGregorianCalendar();
		System.out.println(now);
	}
	
	public String toString(){
		return this.get(Calendar.HOUR) + ":" + this.get(Calendar.MINUTE) 
				+ " " + (this.get(AM_PM) == 1 ? "PM " : "AM ") 
				+ this.get(Calendar.MONTH) + "/" 
				+ this.get(Calendar.DAY_OF_MONTH) + "/" 
				+ this.get(Calendar.YEAR);
	}//end method
	
}//end class
