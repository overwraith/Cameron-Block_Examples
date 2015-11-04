/* Author: Cameron Block
 * File: TestCollegeStudent.java
 * Intermediate Java I
 * Purpose: Tests the class CollegeStudent.java. 
 * */
import java.util.Scanner;
import java.util.GregorianCalendar;

public class TestCollegeStudent {
	final static int ARRAY_LENGTH = 2;//get two students

	public static void main(String[] args) {
		//interactive application
		//prompts for two CollegeStudent objects
		CollegeStudent students[] = new CollegeStudent[ARRAY_LENGTH];
		
		for(int i = 0 ; i < ARRAY_LENGTH ; i++){
			students[i] = getStudent();
		}//end loop
		
		for(int i = 0 ; i < ARRAY_LENGTH ; i++){
			System.out.println(students[i].toString());
		}//end loop
	}//end main
	
	public static CollegeStudent getStudent(){
		Scanner sc = new Scanner(System.in);
		//Tokenize this
		String word[] = getString(sc, "Please enter the student's first" 
				+ " and last name: ").split(" ");
		
		GregorianCalendar enrollmentDate = getGregorian(sc, 
				"Please enter the enrollment date in the format mm dd yyyy: ");
		
		System.out.println();
		
		return new CollegeStudent(word[0], word[1], enrollmentDate);
	}//end method
	
	public static String getString(Scanner sc, String prompt){
		//The following loop and try/catch prompts user to enter correct 
		//data infinitely until the user follows the prompts instructions. 
		while(true){
			try{
				System.out.print(prompt);
				return sc.nextLine();
			}catch(Exception ex){
				System.out.println("\nInput error, please try again. ");
				sc.nextLine();
			}
		}//end loop
	}//end method
	
	public static GregorianCalendar getGregorian(Scanner sc, String prompt){
		
		//The following loop and try/catch prompts user to enter correct 
		//data infinitely until the user follows the prompts instructions. 
		while(true){
			try{
				System.out.print(prompt);
				int month = sc.nextInt();
				int day = sc.nextInt();
				int year = sc.nextInt();
				return new GregorianCalendar(year, month, day);
			}catch(Exception ex){
				System.out.println("\nInput error, please try again. ");
				sc.nextLine();
			}
		}//end loop
	}//end method
	
}//end class
