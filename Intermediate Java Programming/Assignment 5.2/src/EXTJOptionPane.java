import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.JTextField;
import java.awt.Component;
import java.awt.GridLayout;

public class EXTJOptionPane extends JOptionPane {
	
	public static void main(String[] args) {
		   String messages[] = {"str1", "str2", "str3", "str4", "str5"};
		   
		   showInputDialog(null, messages);
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
