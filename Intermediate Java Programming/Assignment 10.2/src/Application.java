import java.awt.BorderLayout;
import java.awt.Button;
import java.awt.GridLayout;
import java.awt.Panel;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import javax.swing.JFrame;
import javax.swing.JLabel;

public class Application {

	public static void main(String[] args) {
	    JFrame frame = new JFrame("JLabel test");
	    frame.setVisible(true);
	    frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
	
	
	    Panel p = new Panel();
	    p.setLayout(new GridLayout());
	
	    Button button = new Button("Change");
	    final JLabel label = new JLabel(Long.toString(Long.MAX_VALUE));
	
	    button.addActionListener(new ActionListener(){
	        public void actionPerformed(ActionEvent e){
	            label.setText(Long.toString(e.getWhen()));
	        }//end method
	    });
	
	    p.add(button);
	    p.add(label);
	    frame.add(p, BorderLayout.NORTH);
	    frame.pack();
	
	}//end main
}//end class