/*Author: Cameron Block
 * Intermediate Java I
 * Purpose: To create a program that uses dialog boxes and breaks up monetary 
 * 			values into 100s, 50s, 20s, 10s, 5s, and 1s. 
 * */
import javax.swing.JOptionPane;

public class Dollars {
	public static void main(String [] args){
		 
		double dblInput = Double.parseDouble( 
				JOptionPane.showInputDialog(null, "Please enter a money " 
						+ "value. "));
		
		//break up monetary value into 100s, 50s, 20s, 10s, 5s, and 1s
		double dblHundreds = dblInput / 100 - dblInput / 100 % 1;
		dblInput -= dblHundreds * 100;
		double dblFifties = dblInput / 50 - dblInput / 50 % 1;
		dblInput -= dblFifties * 50;
		double dblTwenties = dblInput / 20 - dblInput / 20 % 1;
		dblInput -= dblTwenties * 20;
		double dblTens = dblInput / 10 - dblInput / 10 % 1;
		dblInput -= dblTens * 10;
		double dblFives = dblInput / 5 - dblInput / 5 % 1;
		dblInput -= dblFives * 5;
		double dblOnes = dblInput / 1 - dblInput / 1 % 1;
		
		JOptionPane.showMessageDialog(null, "There are " 
				+ dblHundreds + " hundreds,  "
				+ dblFifties + " fifties,  "
				+ dblTwenties + " twenties,  "
				+ dblTens + " tens,  "
				+ dblFives + " fives,  "
				+ dblOnes + " ones,  ");
		
		System.exit(0);
	}//end main
}//end class
