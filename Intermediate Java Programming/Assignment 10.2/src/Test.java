import java.awt.BorderLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JTextField;


public class Test extends JFrame implements ActionListener{
  
 
 //Initialize the JButtons
    private JButton team1 = new JButton("Zerg");//video game sarcraft
   
   
    //private JButton team1;
    private JLabel label;

    public static void main(String[] args) {
        new Test();
    }//end main
   
    public Test(){
        super("Favorite Teams");

        setSize(300, 300);
        setLocationRelativeTo(null);//center the frame
        getContentPane().setLayout(new BorderLayout());
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
       

 
       
        //initialize the JLabel
        label = new JLabel("Please select a team. ");
        label.setHorizontalAlignment(JLabel.CENTER);
       
        //add the JButtons to the frame
        getContentPane().add(team1, BorderLayout.LINE_START);
       
        //add JLabel to the frame
        getContentPane().add(label, BorderLayout.CENTER);
       
        //add ActionListeners to the buttons
        team1.addActionListener(this);
        setVisible(true);
    }

    public void actionPerformed(ActionEvent e) {
 
        if(e.getSource() == team1)//Zerg
            label.setText("Ok, if you like critters. ");
    }//end method

}//end class