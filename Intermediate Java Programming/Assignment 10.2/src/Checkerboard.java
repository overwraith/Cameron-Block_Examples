/*
 * Simple program to create a Black and White Checkerboard
 * Should be an 8 x 8 square with Black and White alternating boxes
 * Starting with a Black box in the top right corner
 */
import java.awt.*;
import javax.swing.*;
import java.awt.Color;

public class Checkerboard extends JFrame {
    private final int Rows = 8;
    private final int Colm = 8;
    private final int Gap = 2;
    private final int Num = Rows * Colm;
    private int x;
   
    private JPanel pane = new JPanel (new GridLayout(Rows, Colm, Gap, Gap));
    //capitalize the p in JPannel x2
   
    private JPanel[] panel = new JPanel[Num];
    //capitalize the p in JPannel x2
   
    private Color color1 = Color.WHITE;
   
    private Color color2 = Color.BLACK;
   
    private Color tempColor;
   
    public Checkerboard() {
        super("Checkerboard");
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);//capitalize the f
        add(pane);
        for (x = 0 ; x < Num ; ++x) {//get rid of the = in <=
            panel[x] = new JPanel();
            pane.add(panel[x]);
            
            if (x % Colm == 0) {//Change Division to Modulus 
                tempColor = color2;
                color2 = color1;
                color1 = tempColor;
            }
            if (x % 2 == 0)//Change Division to Modulus
                panel[x].setBackground(color2);//black
            else
                panel[x].setBackground(color1);//white
        }//end loop
    }//end constructor
    
    public static void main(String[] args) {
        Checkerboard frame = new Checkerboard();
        final int Size = 300;
        frame.setSize(Size, Size);
        frame.setVisible(true);
    }//end main
    
}//end class