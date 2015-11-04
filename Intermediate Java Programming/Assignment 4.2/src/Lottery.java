/* Author: Cameron Block
 * File: Lottery.java
 * Intermediate Java I
 * Purpose: to create a class that uses random numbers for a lottery game.  
 * */
import java.util.Random;
import javax.swing.JOptionPane;

public class Lottery {
	private final int RAND_LENGTH;
	private int randNums[];
	private int userGuesses[];
	private final int NUM_GUESSES;
	private int matches;
	private int score;
	private boolean ordered = false;

	public static void main(String[] args) {

		//defaults to 4 random numbers, and 4 guesses
		Lottery lot = new Lottery();
		
		lot.setLottery();
		
		lot.getGuesses();
		
		//The instructions were a little vague as to whether the index of the 
		//random numbers and user guesses should be compared or whether 
		//the indexes should all be compared to each other. Instructor can
		//easily un-comment one of the following commands below and comment 
		//the other to change the funcitonality of the program. 
		
		//unorderedScore() assumes the order of the numbers does 
		//not matter, and loops through both arrays comparing values. 
		//lot.unorderedScore();
		
		//orderedScore() assumes that the order of numbers does matter, and 
		//the guesses and random numbers must match index positions. 
		lot.orderedScore();
		
		System.out.println(lot);
		
	}//end main
	
	public Lottery(){
		RAND_LENGTH = 4;
		randNums = new int[RAND_LENGTH];
		NUM_GUESSES = RAND_LENGTH;
		userGuesses = new int[NUM_GUESSES];
		matches = 0;
		score = 0;
	}
	
	public Lottery(int lotteryLen){
		RAND_LENGTH = lotteryLen;
		randNums = new int[RAND_LENGTH];
		NUM_GUESSES = RAND_LENGTH;
		userGuesses = new int[NUM_GUESSES];
		matches = 0;
		score = 0;
	}
	
	public Lottery(int lotteryLen, int numGuesses){
		RAND_LENGTH = lotteryLen;
		randNums = new int[RAND_LENGTH];
		NUM_GUESSES = numGuesses;
		userGuesses = new int[NUM_GUESSES];
		matches = 0;
		score = 0;
	}
	
	public void setLottery(){
		//Set the random numbers in an array. 
		for(int i = 0 ; i < RAND_LENGTH ; i++)
			randNums[i] = (int)(Math.random()*10);
	}
	
	public void getGuesses(){
		for(int i = 0 ; i < NUM_GUESSES ; i++)
			userGuesses[i] = getInput();
	}
	
	public int unorderedScore(){
		ordered = false;
		matches = 0;
		
		//search for matches
		for(int guess : userGuesses)
			for(int rand : randNums)
				if(guess == rand)
					matches++;

		//return the score
		if(matches == 0)
			return score = 0;
		else if(matches == 1)
			return score = 5;
		else if(matches == 2)
			return score = 100;
		else if(matches == 3)
			return score = 2000;
		else
			return score = 1000000;
	}//end method
	
	public int orderedScore(){
		ordered = true;
		matches = 0;
		
		//search for matches
		for(int i = 0 ; i < NUM_GUESSES ; i++)
			if(userGuesses[i] == randNums[i])
				matches++;

		//return the score
		if(matches == 0)
			return score = 0;
		else if(matches == 1)
			return score = 5;
		else if(matches == 2)
			return score = 100;
		else if(matches == 3)
			return score = 2000;
		else
			return score = 1000000;
	}//end method
	
	public String toString(){
		//make sure to call ordered, or unordered 
		//score first to make calculations. 
		
		String str = "\t" + (ordered ? "Order Based" : "Unordered") 
				+ " Lottery Game\nThe random Numbers were: ";
		
		for(int i = 0 ; i < RAND_LENGTH ; i++)
			str += randNums[i] + (i == RAND_LENGTH - 1 ? "" : ", ");
		
		str += "\nThe Guessed Numbers were: ";
		
		for(int i = 0 ; i < RAND_LENGTH ; i++)
			str += userGuesses[i] + (i == NUM_GUESSES - 1 ? "" : ", ");
		
		str += "\nThe number of matches was: " + matches;
		
		str += "\nThe score was: " + score;
		
		return str;
	}//end method
	
	public static int getInput(){
		while(true){
			try{
				return Integer.parseInt( 
						JOptionPane.showInputDialog(null, 
								"Please make a lottery" 
								+ " entry [whole number 0-9]: ", 
								"Lottery Game", 
								JOptionPane.INFORMATION_MESSAGE));
			}catch(Exception ex){
				JOptionPane.showMessageDialog(null, "Please retry. ", "Error", 
						JOptionPane.ERROR_MESSAGE); 
			}
		}//end loop
	}//end method
}//end class
