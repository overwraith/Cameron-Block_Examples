import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;//import ActionEvent
import java.awt.event.ActionListener;//import ActionListener


public class HelloFrame extends JFrame implements ActionListener{

    JLabel question = new JLabel ("What is your name?");
    Font bigFont = new Font ("Arial", Font.BOLD, 16);
    //make 'Aial' a string, Capitalize 'Bold'
    JTextField answer = new JTextField (3);
    JButton pressMe = new JButton ("Press Me");
    JLabel greeting = new JLabel ("");
    final int WIDTH = 175;
    final int HEIGHT = 225;
    
    public HelloFrame()
    {
      super ("Hello Frame");
      setSize (WIDTH, HEIGHT);
      setLayout (new FlowLayout());
      question.setFont (bigFont);
      greeting.setFont (bigFont);
      add(question);
      add (answer);
      add (pressMe);
      add (greeting);
        setDefaultCloseOperation (JFrame.EXIT_ON_CLOSE);
        pressMe.addActionListener(this);
    
    }
    
    public void actionPerformed(ActionEvent e)
    {
        String name = answer.getText();
        String greet = "Hello, " + name;
        greeting.setText(greet);
    }
    public static void main(String[] args) {
        // TODO code application logic here
        HelloFrame frame = new HelloFrame();
        frame.setVisible(true);//give this method the parameter 'true'
    }
}
