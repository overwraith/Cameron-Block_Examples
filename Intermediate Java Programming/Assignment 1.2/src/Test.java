import javax.swing.*;

public class Test{

  public static void main(String [] args){

    double dblInput = 0.0;
    int intInput = 0;
    String rawInput;

    rawInput = JOptionPane.showInputDialog(null, "Please enter a double value. Example: 33.44");
    dblInput = Double.parseDouble(rawInput);
    System.out.println("The value entered is: " + dblInput);

    rawInput = JOptionPane.showInputDialog(null, "Please enter an int value. Example 231");
    intInput = Integer.parseInt(rawInput);
    System.out.println("The value entered is: " + intInput);

    System.exit(0);
  }
}