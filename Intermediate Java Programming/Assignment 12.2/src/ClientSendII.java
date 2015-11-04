import java.net.*;
import java.io.*;

import javax.swing.JFrame;
import javax.swing.JOptionPane;

public class ClientSendII extends Thread{
	
	String message = "";
	
	public ClientSendII(){
	    message = JOptionPane.showInputDialog(null, 
	    		"Please Enter a message to send. ", "Message Content", 
	    		JOptionPane.QUESTION_MESSAGE);
	}
	
	public ClientSendII(JFrame frame){
	    message = JOptionPane.showInputDialog(frame, 
	    		"Please Enter a message to send. ", "Message Content", 
	    		JOptionPane.QUESTION_MESSAGE);
	}
	
	public ClientSendII(String message){
		this.message = message;
	}
	
	 public void run(){

		    try {

		      // Make change here
		      // Example:
		      // Socket connectToServer = new Socket("192.168.1.1", 8000);
		      // Change here
		      Socket connectToServer = new Socket("127.0.0.1", 8000);

		      PrintWriter write = new PrintWriter(connectToServer
		    		  .getOutputStream(), true);

		      write.println(message);
		    }
		    catch (IOException e) {

		      e.printStackTrace();
		    }
		  }//end method
}//end class
