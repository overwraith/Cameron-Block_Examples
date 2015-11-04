import java.awt.FlowLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import javax.swing.JButton;
import javax.swing.JFrame; //changed Jframe to JFrame
import javax.swing.JTextField;  //changed JTextBox to JTextField

public class MyDebugExercise2 {

    public static void main(String[] args) {
        Calculator calc = new Calculator();  // added = new Calculator();
      
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
  
    public static class Calculator extends JFrame{  // changed Jframe to JFrame
      
        JTextField input = new JTextField(10);
      
        NumberButton buttons[] = new NumberButton[10];//10 numerals
      
        public Calculator(){
            super("Activity");
            this.setVisible(true); // added this line
            this.setLayout(new FlowLayout());
            this.setSize(170, 200);
            this.setResizable(false);
            this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
          
            input.setHorizontalAlignment(JTextField.RIGHT); //changed JTextBox to JTextField
          
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