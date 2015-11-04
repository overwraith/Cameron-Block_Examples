//changes expressed in comments
//I think I got em all, it compiles now. 
import javax.swing.JOptionPane;
public class SalaryDialog
{
	public static void main(String[] args)//changing "{}" to "[]"
	{
		String wageString, dependentsString;
		double wage, weeklyPay;
		int dependents;
		final double HOURS_IN_WEEK = 37.5;//added semicolon here
		
		
		wageString = JOptionPane.showInputDialog(null, 
				"Enter employee's hourly wage", "Salary dialog 1", 
				JOptionPane.INFORMATION_MESSAGE);
		
		weeklyPay = Double.parseDouble(wageString) * HOURS_IN_WEEK;
		dependentsString = JOptionPane.showInputDialog(null, 
				"How many dependents?", "Salary Dialog 2", 
				JOptionPane.QUESTION_MESSAGE);
		
		//dependentString cannot be resolved to a variable 
		//changing to "dependentsString"
		dependents = Integer.parseInt(dependentsString);
		
		//Syntax error on token ",", . expected
		//compiler says "syntax error on token "dependents", delete this token"
		//missing double quote, that was tricky. 
		JOptionPane.showMessageDialog(null,"Weekly salary is $" + weeklyPay 
				+ "\nDeductions will be made for " + dependents 
				+ " dependents");
	}
}