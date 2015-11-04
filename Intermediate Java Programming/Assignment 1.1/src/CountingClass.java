/* Author: Cameron Block
 * Intermediate Java I 
 * Purpose: make an error generating brain teaser for classmates. 
 * */
import javax.swing.JOptionPane;

public class CountingClass {
	public static void main(String [] args){
		
		int num= Integer.parseInt( 
				JOptionPane.showInputDialog(null, "How many classes do you " 
						+ "want?"));
		
		for(int i = 0 ; i < num ; i++){
			Counter count = new Counter(); 
		}//end loop
		
	}//end method
	private class Counter{
		private static int counter = 0; 
		public counter(){
			++counter;
			/*
			System.out.println("There are " + counter 
					+ " classes instantiated. ");
		}//end method
	} //end class
}//end class

/* THE WORKING VERSION...
import javax.swing.JOptionPane;

public class CountingClass {
	public static void main(String [] args){
		
		int num= Integer.parseInt( 
				JOptionPane.showInputDialog(null, "How many classes do you " 
						+ "want?"));
		
		for(int i = 0 ; i < num ; i++){
			Counter count = new Counter(); 
		}//end loop
		
	}//end method
	private static class Counter{
		private static int counter = 0; 
		public Counter(){
			++counter;
			System.out.println("There are " + counter 
					+ " classes instantiated. ");
		}//end method
	} //end class
}//end class
*/