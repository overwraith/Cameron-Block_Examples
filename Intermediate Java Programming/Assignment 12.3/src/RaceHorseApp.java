/* Author: Cameron Block
 * File: RaceHorseApp.java
 * Intermediate Java I
 * Purpose: to create an application that uses threading.   
 * */

import javax.swing.*;
import java.awt.*;
import java.awt.event.*;
import java.util.LinkedList;

public class RaceHorseApp extends JFrame implements ActionListener{
	
	private final static int NUM_HORSES = 5;
	
	static JTextArea textAreas[] = new JTextArea[NUM_HORSES];
	JButton start = new JButton("Start");
	JButton clear = new JButton("Clear");
	JPanel panel1 = new JPanel(new FlowLayout());
	JPanel panel2 = new JPanel(new FlowLayout());
	
	public static void main(String[] args) {
		new RaceHorseApp();
	}
	
	public RaceHorseApp(){
		super("Race Horse App");
		getContentPane().setLayout(new BoxLayout(getContentPane(), 
				BoxLayout.Y_AXIS));
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		
		//initialize the JTextAreas
		for(int i = 0 ; i < NUM_HORSES ; i++){
			textAreas[i] = new JTextArea();
			textAreas[i].setAlignmentX(CENTER_ALIGNMENT);
			//must give the dimension to the JScrollPane or will have  
			//problems with the JScrollPane not scrolling correctly
			//textAreas[i].setPreferredSize(new Dimension(150, 200));
			
			JScrollPane scroll = new JScrollPane(textAreas[i], 
					ScrollPaneConstants.VERTICAL_SCROLLBAR_ALWAYS, 
					ScrollPaneConstants.HORIZONTAL_SCROLLBAR_AS_NEEDED);
			
			scroll.setPreferredSize(new Dimension(150, 200));
			
			panel1.add(scroll);
		}//end loop
		
		start.setAlignmentX(CENTER_ALIGNMENT);
		
		//add action listener to two buttons
		start.addActionListener(this);
		clear.addActionListener(this);
		
		//panel1 holds all the JTextAreas
		this.add(panel1);
		
		//panel2 holds the two buttons 
		panel2.add(start);
		panel2.add(clear);
		this.add(panel2);
		
		//Set this at the bottom or will have an error with 
		//the components not displaying right at runtime.  
		setVisible(true);
		//Must also be at end. 
		pack();
		//Must also be at end. 
		setLocationRelativeTo(null);
	}//end constructor
	
	public static class RaceHorse implements Runnable {
		
		private String name = "";
		private int textAreaNum = 0;
		private static LinkedList<String> order = new LinkedList<String>();
		
		public RaceHorse(String name, int textAreaNum){
			this.name = name; 
			this.textAreaNum = textAreaNum;
		}
		
		public void run() {
			for(int i = 0 ; i < 50 ; i++){
				textAreas[textAreaNum].append(name + '\n');
			}
			
			finishOrder(this.name);
		}
		
		public static void resetRace(){
			order.clear();
		}
		
		public static synchronized void finishOrder(String name){
			order.add(name);
		}
		
		public static LinkedList<String> getFinishOrder(){
			return order;
		}
		
	}//end inner class

	public void actionPerformed(ActionEvent arg) {
		Object src = arg.getSource();
		if(src == start){
			//clear the output again just in case
			for(int i = 0 ; i < NUM_HORSES ; i++)
				textAreas[i].setText("");
			RaceHorse.resetRace();
			
			//could make the program prompt for a number of horses
			//names could be in a file or array, would be a max 
			//number of horses. 
			Thread threads[] = new Thread[NUM_HORSES];
			threads[0] = new Thread(new RaceHorse("Stan", 0));
			threads[1] = new Thread(new RaceHorse("Tom", 1));
			threads[2] = new Thread(new RaceHorse("Harry", 2));
			threads[3] = new Thread(new RaceHorse("Finn", 3));
			threads[4] = new Thread(new RaceHorse("Sawyer", 4));
			
			for(int i = 0 ; i < threads.length ; i++)
				threads[i].start();
			
			for(int i = 0; i < threads.length; i++)
				try {
					threads[i].join();
				} catch (InterruptedException e) {
					e.printStackTrace();
				}
			
			LinkedList<String> order = RaceHorse.getFinishOrder();
			JOptionPane.showMessageDialog(null, 
					"The horses finished in the following order: " 
					+ order.get(0) + ", " + order.get(1) + ", " + order.get(2) 
					+ ", " + order.get(3) + ", " + order.get(4) + ". ", 
					"Finish Order", 
					JOptionPane.INFORMATION_MESSAGE);
		}
		else if(src == clear){
			for(int i = 0 ; i < NUM_HORSES ; i++)
				textAreas[i].setText("");
			RaceHorse.resetRace();
		}
	}
    
}//end class
