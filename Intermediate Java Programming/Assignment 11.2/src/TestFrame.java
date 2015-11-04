import java.awt.*;
import java.awt.event.*;

import javax.swing.*;
import javax.swing.border.*;

public final class TestFrame extends JFrame {
	public static void main(String [] args){
		JFrame frame = new TestFrame();
        frame.setVisible(true);
	}
    public TestFrame() {
        this.addComponentListener(new ComponentAdapter() {
            public void componentResized(ComponentEvent e) {
                // This is only called when the user releases the mouse button.
                System.out.println("componentResized: " + "" 
                		+ getSize().getHeight() +", " + getSize().getWidth());
            }
        });
    }

    // These methods do not appear to be called at all when a JFrame
    // is being resized.
    @Override
    public void setSize(int width, int height) {
        System.out.println("setSize");
    }

    @Override
    public void setBounds(Rectangle r) {
        System.out.println("setBounds A");
    }

    @Override
    public void setBounds(int x, int y, int width, int height) {
        System.out.println("setBounds B");
    }
}