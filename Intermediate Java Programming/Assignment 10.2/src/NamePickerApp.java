import java.awt.BorderLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import javax.swing.JButton;
import javax.swing.JComboBox;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPanel;

public class NamePickerApp
{
	public static void main(String[] args)
	{
		new NamePickerApp();
	}

	public NamePickerApp()
	{
		JFrame guiFrame = new JFrame();
		guiFrame.setTitle("Name Picker");
		guiFrame.setSize(275, 200);
		guiFrame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		guiFrame.setLocationRelativeTo(null); // center the frame

		final JPanel femalePanel = getPanel(femaleNames, femaleLable);
		final JPanel malePanel = getPanel(maleNames, maleLable);
		
		JButton button = new JButton("Male or Female");

		/**
		 * anonymous inner class ActionListener
		 */
		button.addActionListener(new ActionListener()
		{
			public void actionPerformed(ActionEvent event)
			{
				/**
				 * Flip-flop visible property
				 */
				malePanel.setVisible(!malePanel.isVisible());
				femalePanel.setVisible(!femalePanel.isVisible());

			}
		});

		guiFrame.add(femalePanel, BorderLayout.NORTH);
		guiFrame.add(malePanel, BorderLayout.NORTH);
		guiFrame.add(button, BorderLayout.SOUTH);

		guiFrame.setVisible(true);
	}

	private JPanel getPanel(String[] names, String labelTxt)
	{
		JPanel panel = new JPanel();
		JLabel label = new JLabel(labelTxt);
		JComboBox comboBox = new JComboBox(names);

		panel.add(label);
		panel.add(comboBox);

		return panel;
	}

	private final String femaleLable = "Female Names:";
	private final String[] femaleNames = { "Abby", "Avis", "Celeste", "Diann", "Faye", "Irma", "Julie", "Lee", "Mai",
			"Minnie", "Randi", "Shirley", "Veronica" };

	private final String maleLable = "Male Names:";
	private final String[] maleNames = { "Aaron", "Bernardo", "Clifford", "Donnie", "Fernando", "Hubert", "Jordan",
			"Luciano", "Nicolas", "Rocco", "Stevie", "Winston" };
}