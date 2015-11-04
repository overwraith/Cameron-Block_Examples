import java.awt.FlowLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JTextField;

public class DebugProblem {

	public static void main(String[] args) {
		Calculator calc = new Calculator();
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
	
	public static class Calculator extends JFrame{
		
		JTextField input = new JTextField(10);
		
		NumberButton buttons[] = new NumberButton[10];//10 numerals
		
		public Calculator(){
			super("Activity");
			this.setVisible(true);
			this.setLayout(new FlowLayout());
			this.setSize(170, 200);
			this.setResizable(false);
			this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
			
			input.setHorizontalAlignment(JTextField.RIGHT);
			
			this.add(input);
			
			for(int i = 9 ; i >= 0 ; i--){
				buttons[i] = new NumberButton("" + i, i);
				
				this.add(buttons[i]);
				
				buttons[i].addActionListener(new ActionListener(){
					public void actionPerformed(ActionEvent arg) {
						//input.setText("pressed button: " 
						//		+ ((NumberButton)arg.getSource()).getValue());
						input.setText("pressed button: " 
								+ ((NumberButton)arg.getSource()).getText());
						//input.setText("" + (Integer.parseInt((input.getText())) 
						//		+ ((NumberButton)arg.getSource()).getValue()));
					}
				});
				
			}//end loop
		}//end constructor
		
	}//end class
	
	public static void makeJFrame(String title){
		JFrame frame = new JFrame(title);
		frame.setVisible(true);
		
	}
	
}//end class
