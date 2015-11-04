import javax.swing.JButton;
import javax.swing.JFrame;
import java.awt.EventQueue;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class FrameWithButtonExample {

  public static void main( String[] args ) {
    EventQueue.invokeLater( new Runnable() {
      @Override
      public void run() {
        JFrame frame = new JFrame( "TestFrame" );

        final JButton testButton = new JButton( "TestButton" );
        testButton.addActionListener( new ActionListener() {
          @Override
          public void actionPerformed( ActionEvent aActionEvent ) {
            //if check to match the code from the question, but not really needed
            if ( aActionEvent.getSource() == testButton ){
              System.out.println("TestButton pressed");
            }
          }
        } );
        frame.add( testButton );
        frame.pack();
        frame.setDefaultCloseOperation( JFrame.EXIT_ON_CLOSE );
        frame.setVisible( true );
      }
    } );
  }
}