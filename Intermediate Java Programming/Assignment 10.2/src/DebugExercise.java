//Assignment 10 Debug exercise
//Create a user interface with 3 buttons: multiply, divide, and exit
//The multiply and divide buttons will multiply or divide the numbers 36 and 24
//The exit button will quit the application

import javax.swing.*;
import java.awt.*;
import java.awt.event.*;

public class DebugExercise{

      public static void main(String[] args){
    	  //Initialize the UI
    	  UserInterface ui = new UserInterface();
    	  //instantiate the UserInterface
      }//end main
}//end wrapper class

 

class UserInterface extends JFrame implements ActionListener{
      
	final int WIDTH = 500;
    final int HEIGHT = 400;
    double x = 36;
    int y = 24;

    JButton multiply = new JButton("Multiply");
    JButton divide = new JButton("Divide");
    JButton exit = new JButton("Exit");

    JLabel result = new JLabel("Add or multiply 36 by 24");

      public UserInterface(){
    	  //Set up the JFrame
    	  setVisible(true);
    	  setSize(WIDTH, HEIGHT);
    	  setTitle("Week 10 Debug Practice");
    	  setDefaultCloseOperation(EXIT_ON_CLOSE);
    	  
    	  //Center the text of the result label
    	  result.setHorizontalAlignment(JLabel.CENTER);
    	  //change CENTER to JLabel.CENTER
    	  
    	  //Set the layout to BorderLayout
    	  setLayout(new BorderLayout());
    	  
    	  //Add the three buttons and the label to the JFrame
    	  add(multiply, BorderLayout.PAGE_START);//add each to a seperate area
    	  add(divide, BorderLayout.LINE_START);//add each to a seperate area
    	  add(exit, BorderLayout.PAGE_END);//add each to a seperate area
    	  add(result, BorderLayout.CENTER);//add each to a seperate area
    	  
    	  //Add an ActionListener to the buttons
    	  multiply.addActionListener(this);//add parameter this JFrame
    	  divide.addActionListener(this);//add parameter this JFrame
    	  exit.addActionListener(this);//add parameter this JFrame
      }//end UserInterface constructor
      
      public void actionPerformed(ActionEvent e){
    	  //change EventAction to ActionEvent
    	  Object src = e.getSource();//change setSource to getSource
    	  double res = 0;
    	  
    	  if(src == multiply)
    		  res = x * y;
    	  else if(src == exit)
    		  System.exit(0);
    	  else res = x / y;
    	  
    	  result.setText("" + res);//make the parameter a string
      }//end actionPerformed

   }//end class UserInterface