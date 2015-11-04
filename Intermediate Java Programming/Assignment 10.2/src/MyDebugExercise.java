import java.awt.FlowLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import javax.swing.JButton;
import javax.swing.Jframe;
//No longer capitalized, part of debug activity. 
import javax.swing.JTextBox;
//Naming JTextField something else plausible to throw em off 

public class MyDebugExercise {

	public static void main(String[] args) {
		Calculator calc;//= new Calculator();
		//Removing this as part of debug activity.
		
		//This is just the beginnings of a calculator, 
		//dont get hung up on the fact that it doesn't calculate yet.  
	}//end main
	
	public static class NumberButton extends JButton{
		//make the button hold on to the value that it represents
		private double value = 0;
		
		public double getValue(){
			return value; 
		}
		
		public void setValue(double value){
			this.value = value;
		}
		
		public NumberButton(String text, double value){
			super(text);
			this.value = value; 
		}
	}//end class
	
	public static class Calculator extends Jframe{
		//No longer capitalized, part of debug activity. 
		
		JTextBox input = new JTextBox(10);
		//Naming JTextField something else plausible to throw em off 
		
		NumberButton buttons[] = new NumberButton[10];//10 numerals
		
		public Calculator(){
			super("Activity");
			//this.setVisible(true);//removing this as part of debug activity.  
			this.setLayout(new FlowLayout());
			this.setSize(170, 200);
			this.setResizable(false);
			this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
			
			input.setHorizontalAlignment(JTextBox.RIGHT);
			//Naming JTextField something else plausible to throw em off 
			
			this.add(input);
			
			for(int i = 9 ; i >= 0 ; i--){
				buttons[i] = new NumberButton("" + i, i);
				
				this.add(buttons[i]);
				
				//showing it is possible to give each button it's 
				//own Action Listener
				buttons[i].addActionListener(new ActionListener(){
					public void actionPerformed(ActionEvent arg) {
						input.setText("pressed button: " 
								+ ((NumberButton)arg.getSource()).getValue());
						//Have made another program that uses the JButton's 
						//getText method instead of having the button keep
						//track of its own value. 
					}
				});
				
			}//end loop
		}//end constructor
		
	}//end class
	
}//end class
