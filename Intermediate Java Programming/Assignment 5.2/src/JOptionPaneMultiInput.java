import java.awt.GridLayout;
import java.awt.Component;
import javax.swing.*;

public class JOptionPaneMultiInput {
   public static void main(String[] args) {
	   String messages[] = {"str1", "str2", "str3", "str4", "str5"};
	   
	   showInputDialog(null, messages);
	   
      /*JTextField xField = new JTextField(5);
      JTextField yField = new JTextField(5);

      JPanel myPanel = new JPanel();
      myPanel.add(new JLabel("x:"));
      myPanel.add(xField);
      myPanel.add(Box.createHorizontalStrut(15)); // a spacer
      myPanel.add(new JLabel("y:"));
      myPanel.add(yField);

      int result = JOptionPane.showConfirmDialog(null, myPanel, 
               "Please Enter X and Y Values", JOptionPane.OK_CANCEL_OPTION);
      if (result == JOptionPane.OK_OPTION) {
         System.out.println("x value: " + xField.getText());
         System.out.println("y value: " + yField.getText());
      }*/

   }//end main
   
   public static String[] showInputDialog(Component parentComponent, String messages[]){
	   JTextField textFields[] = new JTextField[messages.length];
	   JPanel panel = new JPanel();
	   String input[] = new String[messages.length];
	   
	   panel.setLayout(new GridLayout(messages.length, 2, 0, 0));
	   
	   for(int i = 0 ; i < messages.length ; i++){
		   panel.add(new JLabel(messages[i]));
		   textFields[i] = new JTextField();
		   panel.add(textFields[i]);
	   }
	   
	   JOptionPane.showConfirmDialog(parentComponent, panel, 
			   "Input", JOptionPane.OK_CANCEL_OPTION);
	   
	   for(int i = 0 ; i < messages.length ; i++)
		   input[i] = textFields[i].getText();
	   
	   return input;
   }//end method
   
}//end class