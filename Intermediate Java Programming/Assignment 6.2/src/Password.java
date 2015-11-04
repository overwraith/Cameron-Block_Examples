/* Author: Cameron Block
 * File: Password.java
 * Intermediate Java I
 * Purpose: to create a class that accepts a users password from an input 
 * 		dialog.   
 * */
import javax.swing.JOptionPane;

public class Password {
	
	public static void main(String[] args) {
		String password = getPassword();
		
		login(password);
		//the boolean returned could be used as a flag for the rest of 
		//the program to initiate login procedures. 
		
	}//end main
	
	public static boolean login(String password){
		String password2 = null;
		
		while(!password.equals(password2)){
			password2 = JOptionPane.showInputDialog(null, 
					"Please reenter password: ", "Password", 
					JOptionPane.QUESTION_MESSAGE);
			if(password2 == null){
				System.exit(0);
			}
		}//end loop
		
		JOptionPane.showMessageDialog(null, 
				"Login successful. ", 
				"Success", JOptionPane.INFORMATION_MESSAGE);
		
		return true;
	}
	
	public static String getPassword(){
		String password = null;
		try{
			do{
			password = JOptionPane.showInputDialog(null, 
					"Please enter password: ", "Password", 
					JOptionPane.QUESTION_MESSAGE);

			if(password.length() < 6)
				JOptionPane.showMessageDialog(null, 
						"Error, must be greater than 6. ", "Error", 
						JOptionPane.ERROR_MESSAGE);
			else if(password.length() > 10)
				JOptionPane.showMessageDialog(null, 
						"Error, must be less than 10", "Error", 
						JOptionPane.ERROR_MESSAGE);
			else if(!hasLetter(password))
				JOptionPane.showMessageDialog(null, 
						"Error, must contain an alphabetic character. ", 
						"Error", JOptionPane.ERROR_MESSAGE);
			else if(!hasDigit(password))
				JOptionPane.showMessageDialog(null, 
						"Error, must contain a numeric character. ", 
						"Error", JOptionPane.ERROR_MESSAGE);
			}while(password.length() < 6 || password.length() > 10 || 
					!hasLetter(password) || !hasDigit(password));
			
		}catch(NullPointerException ex){System.exit(0);};
		
		JOptionPane.showMessageDialog(null, 
				"Password has been successfully set. ", 
				"Success", JOptionPane.INFORMATION_MESSAGE);
		
		return password;
	}//end method
	
	public static boolean hasLetter(String password){
		
		for(int i = 0 ; i < password.length() ; i++)
			if(Character.isAlphabetic(password.charAt(i)))
				return true;
			
		return false;
	}
	
	public static boolean hasDigit(String password){
		
		for(int i = 0 ; i < password.length() ; i++)
			if(Character.isDigit(password.charAt(i)))
				return true;
			
		return false;
	}
	
}//end class
