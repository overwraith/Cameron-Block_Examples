//Travis Richardson
//04/04/2013
//Prompt the user to guess and match a randomly generated number between 0 and 10
import java.util.*;

public class DebugExercise{
	public static void main(String[] args){
		//Declare variables
		Scanner input = new Scanner(System.in);
		int randomgen = (int) (Math.random() * 10);
		
		//Prompt the user to guess a number between 1 and 10
		System.out.print("Enter a number between 0 and 10: ");
		int guess = input.nextInt();
		
		//Prompt the user for different input if the guess doesn't match the random generated number
		while(guess > randomgen || guess < randomgen){
			//Show message if the value is higher than the generated number
			if(guess > randomgen){
				System.out.println("Too High!");
				//Show message if the value is higher than 10
				if(guess > 10){
					System.out.println();
					System.out.println("Your number can't be higher than 10.");
				}
			}
			else if(guess < randomgen){
				//Show message if the value is less than the generated number
				System.out.println("Too Low!");
				//Show message if the value is less than 0
				if(guess < 0){
					System.out.println();
					System.out.println("Your number can't be lower than 0.");
				}
			}//else if
			
			//Prompt user for a new guess
			System.out.print("Try again!: ");
			guess = input.nextInt();
		}//end loop
		//Show the user that their guess was correct
		System.out.print("Congratulations! " + guess + " is the correct match!");
	}//end main
	  
}//end class DebugExercise