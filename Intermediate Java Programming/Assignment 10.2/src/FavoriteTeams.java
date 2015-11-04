/* Author: Cameron Block
 * File: FavoriteTeams.java
 * Intermediate Java I
 * Purpose: to create a class that displays a Java GUI for picking teams. 
 * */

import java.awt.BorderLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JTextField;

public class FavoriteTeams {

	public static void main(String[] args) {
		new FavoriteTeamsUI();
	}//end method
	
	static class FavoriteTeamsUI extends JFrame implements ActionListener{
		
		private JButton team1, team2, team3, team4;
		private JLabel label;
		
		public FavoriteTeamsUI(){
			super("Favorite Teams");
			this.setVisible(true);
			this.setSize(375, 350);
			this.setLocationRelativeTo(null);//center the frame 
			this.setLayout(new BorderLayout());
			this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
			
			//Initialize the JButtons
			team1 = new JButton("Zerg");//video game sarcraft
			team2 = new JButton("Terran");
			team3 = new JButton("Protoss");
			team4 = new JButton("Xel Naga");
			
			//initialize the JLabel
			label = new JLabel("Please select a team. ");
			label.setHorizontalAlignment(JLabel.CENTER);
			this.repaint();
			
			//add the JButtons to the frame
			this.add(team1, BorderLayout.LINE_START);
			this.add(team2, BorderLayout.PAGE_START);
			this.add(team3, BorderLayout.LINE_END);
			this.add(team4, BorderLayout.PAGE_END);
			
			//add JLabel to the frame
			this.add(label, BorderLayout.CENTER);
			
			//add ActionListeners to the buttons
			team1.addActionListener(this);
			team2.addActionListener(this);
			team3.addActionListener(this);
			team4.addActionListener(this);
		}//end constructor

		public void actionPerformed(ActionEvent arg) {
			if(arg.getSource() == team1)//Zerg
				label.setText("Zerg");
			else if(arg.getSource() == team2)//Terran
				label.setText("Terran");
			else if(arg.getSource() == team3)//Protoss
				label.setText("Protoss");
			else if(arg.getSource() == team4)//Xel Naga
				label.setText("Xel Naga");
			
			label.setHorizontalAlignment(JLabel.CENTER);
		}
	}//end inner class

}//end class
