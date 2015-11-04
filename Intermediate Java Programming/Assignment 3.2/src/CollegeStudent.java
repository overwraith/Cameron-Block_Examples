/* Author: Cameron Block
 * File: CollegeStudent.java
 * Intermediate Java I
 * Purpose: A class for holding college student information. 
 * */
import java.util.Calendar;
import java.util.GregorianCalendar;

public class CollegeStudent {
	String firstName, lastName; 
	GregorianCalendar enrollmentDate, graduationDate;
	
	public CollegeStudent(String firstName, String lastName, 
			GregorianCalendar enrollmentDate){
		this.firstName = firstName; 
		this.lastName = lastName;
		this.enrollmentDate = enrollmentDate;
		graduationDate = (GregorianCalendar)this.enrollmentDate.clone();
		graduationDate.add(Calendar.YEAR, 4);
	}
	
	public String getFirstName(){
		return firstName;
	}
	
	public void setFirstName(String firstName){
		this.firstName = firstName; 
	}
	
	public String getLastName(){
		return lastName;
	}
	
	public void setLastName(String lastName){
		this.lastName = lastName;
	}
	
	public GregorianCalendar getEnrollmentDate(){
		return enrollmentDate; 
	}
	
	public void setEnrollmentDate(GregorianCalendar enrollmentDate){
		this.enrollmentDate = enrollmentDate;
	}
	
	public GregorianCalendar getGraduationDate(){
		return graduationDate;
	}
	
	public void setGraduationDate(GregorianCalendar graduationDate){
		this.graduationDate = graduationDate;
	}
	
	public String toString(){
		return firstName + " " + lastName + " Enrollment Date: " + 
				+ enrollmentDate.get(Calendar.MONTH) + "/" 
				+ enrollmentDate.get(Calendar.DAY_OF_MONTH) + "/" 
				+ enrollmentDate.get(Calendar.YEAR) + " Graduation Date: " + 
				+ graduationDate.get(Calendar.MONTH) + "/" 
				+ graduationDate.get(Calendar.DAY_OF_MONTH) + "/" 
				+ graduationDate.get(Calendar.YEAR);
	}
}//end class
