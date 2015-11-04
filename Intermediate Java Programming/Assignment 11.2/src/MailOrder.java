/* Author: Cameron Block
 * File: MailOrder.java
 * Intermediate Java I
 * Purpose: to create a data entry program that saves input to a file. 
 * */

//Using the omni flag at the end really cuts down 
//on the amount of code used to import.
import javax.swing.*; 
import java.awt.*;
import java.awt.Dimension;
import java.awt.event.*;
import java.io.*;
import java.util.LinkedList;

public class MailOrder extends JFrame implements ActionListener{
	
	private static JList itemList;
	private static JTextField itemNum;
	private static JTextField itemQty;
	private static JButton enter, exit;

	public static void main(String[] args) throws IOException{
		new MailOrder();
	}//end main
	
	public MailOrder() throws IOException{
		super("Mail Order App");
		setLayout(new GridBagLayout());
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		centerWindow(this);//center the frame
		
		//initialize all components  
		itemList = new JList(getAvailableItems().toArray());
		itemNum = new JTextField(15);
		itemQty = new JTextField(15);
		enter = new JButton("Enter");
		exit = new JButton("Exit");
		
		itemList.addMouseListener(new MouseListener());
		
		//set tool tips
		itemList.setToolTipText("Can select items, can double click items, " 
				+ "can mix text box input with double click selection. ");
		itemNum.setToolTipText("Input the item number you wish to order. ");
		itemQty.setToolTipText("Input the number of that item you wish to" 
				+ " order. ");
		enter.setToolTipText("This button also accessible using the enter" 
				+ " key. ");
		exit.setToolTipText("This button also accessible using ALT+X. ");
		
		
		//add all the components to the JFrame
		add(itemList, getConstraints(0, 0, 2, 1, GridBagConstraints.CENTER));
		add(new JLabel("Item Number: "), 
				getConstraints(0, 1, 1, 1, GridBagConstraints.CENTER));
		add(itemNum, 
				getConstraints(1, 1, 3, 1, GridBagConstraints.LINE_START));
		add(new JLabel("Quantity: "), 
				getConstraints(0, 2, 1, 1, GridBagConstraints.CENTER));
		add(itemQty, 
				getConstraints(1, 2, 3, 1, GridBagConstraints.LINE_START));
		add(enter, getConstraints(0, 3, 1, 1, GridBagConstraints.CENTER));
		add(exit, getConstraints(1, 3, 1, 1, GridBagConstraints.CENTER));
		
		//add ActionListeners
		enter.addActionListener(this);
		exit.addActionListener(this);
		
		//make the buttons respond to key strokes
		getRootPane().setDefaultButton(enter);
		exit.setMnemonic('x');
		
		//Set this at the bottom or will have an error with 
		//the components not displaying right at runtime.  
		setVisible(true);
		//Must also be at end. 
		pack();
		//Must also be at end. 
		itemNum.requestFocus();
	}

	public void actionPerformed(ActionEvent arg){
		Object source = arg.getSource();
		
		if(source == enter){
			//write to file	
			try {
				if(itemList.isSelectionEmpty()){//is anything in the JList selected?
					appendMailOrder(Integer.parseInt(itemNum.getText()),  
							Integer.parseInt(itemQty.getText()));
					
					//clear the text in both text boxes
					itemNum.setText("");
					itemQty.setText("");
					
					//set focus back to first text box
					itemNum.requestFocus();
					
					JOptionPane.showMessageDialog(null, "Mail Order has been " 
							+ "appended to the Que. ", "Item Ordered", 
							JOptionPane.INFORMATION_MESSAGE);
				}else if(itemNum.getText().equals("")){//if text field is empty. 
					appendMailOrder(itemList.getSelectedIndex() + 1,  
							Integer.parseInt(itemQty.getText()));
					
					//clear all selections
					itemList.clearSelection();
					itemQty.setText("");
					
					//set focus back to first text box
					itemNum.requestFocus();
					
					JOptionPane.showMessageDialog(null, "Mail Order has been " 
							+ "appended to the Que. ", "Item Ordered", 
							JOptionPane.INFORMATION_MESSAGE);
				}
			}catch (NumberFormatException e) {
				JOptionPane.showMessageDialog(null, "Error, please fix the " 
						+ "input. ", "Error", JOptionPane.ERROR_MESSAGE);
			}
		}
		else if(source == exit)
			System.exit(0);
	}//end method
	
    private void centerWindow(Window w){
        Toolkit tk = Toolkit.getDefaultToolkit();
        Dimension d = tk.getScreenSize();
        setLocation((d.width-w.getWidth())/2, (d.height-w.getHeight())/2);
    }//end method
	
    //a  method for setting grid bag constraints
    private GridBagConstraints getConstraints(int gridx, int gridy,
    										  int gridwidth, int gridheight, 
    										  int anchor){
        GridBagConstraints c = new GridBagConstraints();
        c.insets = new Insets(5, 5, 5, 5);
        c.ipadx = 0;
        c.ipady = 0;
        c.gridx = gridx;
        c.gridy = gridy;
        c.gridwidth = gridwidth;
        c.gridheight = gridheight;
        c.anchor = anchor;
        return c;
    }
    
    public static class Item{
    	private int itemNum;
    	private String itemName;
    	
    	public Item(int itemNum, String itemName){
    		this.itemNum = itemNum; 
    		this.itemName = itemName;
    	}
    	
    	public String getName(){
    		return itemName;
    	}
    	
    	public String toString(){
    		return itemNum + ". " + itemName + "\t\t" + itemNum;
    	}
    }//end inner class
    
    public static LinkedList<Item> getAvailableItems() throws IOException{
    	LinkedList<Item> list = new LinkedList<Item>();
    	int lineNum = 1;
    	BufferedReader fin = null;
    	
    	try{
	    	fin = new BufferedReader(
	    			new FileReader("AvailableItems.txt"));
	    	String line = null;
	    	String tokens[];
	    	
	    	while((line = fin.readLine()) != null){
	    		tokens = line.split("\t");
	    		list.add(new Item(Integer.parseInt(tokens[0]), tokens[1]));
	    		
	    		lineNum++;
	    	}//end loop
	    	
    	}catch(FileNotFoundException ex){
    		JOptionPane.showMessageDialog(null, "File not found!!!", "Error", 
    				JOptionPane.ERROR_MESSAGE);
    		System.exit(1);
    	}catch(Exception ex){
    		JOptionPane.showMessageDialog(null, "Error line " 
    				+ lineNum + ". ", "Error", JOptionPane.ERROR_MESSAGE);
    		System.exit(1);
    	}finally{
    		fin.close();
    	}
    	
    	return list;
    }//end method
    
    public static void appendMailOrder(int itemNum, 
    		int itemQty){
    	
    	try{
	    	//determine if the file exists
	    	File file = new File("MailOrders.txt"); 
	    	if(!file.exists())//if file doesn't exist, create it
	    		file.createNewFile();//throws IOException, and SecurityException
	    	
	    	//write data to the file
	    	BufferedWriter fout = 
	    			new BufferedWriter(new FileWriter(file, true));
	    	
	    	//had to look online for a way to make BufferedWriter
	    	//print newline characters correctly
	    	fout.write(itemNum + "\t" + itemQty 
	    			+ System.getProperty("line.separator"));
	    	
	    	//First column ItemNum, Second column ItemQty 
	    	//when parsing output file will need this info. 
	    	
	    	//close the output stream
	    	fout.close();
    	}catch(IOException ex){
    		JOptionPane.showMessageDialog(null, "IOException we cannot " 
    				+ "write to the file. ", "Error", 
    				JOptionPane.ERROR_MESSAGE);
    	}catch(SecurityException ex){
    		JOptionPane.showMessageDialog(null, "Security exception, make " 
    				+ "sure you have adequate privilages to use this file. ", 
    				"Error", JOptionPane.ERROR_MESSAGE);
    	}
    }//end method
    
    private static class MouseListener extends MouseAdapter{
    	public void mouseClicked(MouseEvent e){
    		Object src = e.getSource();
    		if(src == itemList)
    			if(e.getClickCount() == 2){//double click
    				if(!itemQty.getText().equals(""))
    					appendMailOrder(itemList.getSelectedIndex() + 1,  
    							Integer.parseInt(itemQty.getText()));
    				else
    					appendMailOrder(itemList.getSelectedIndex() + 1,  1);
    				
					//clear all selections
    				itemNum.setText("");
					itemList.clearSelection();
					itemQty.setText("");
					
					//set focus back to first text box
					itemNum.requestFocus();
					
					JOptionPane.showMessageDialog(null, "Mail Order has been " 
							+ "appended to the Que. ", "Item Ordered", 
							JOptionPane.INFORMATION_MESSAGE);
    			}
    	}//end method
    }//end inner class
    
}//end class
