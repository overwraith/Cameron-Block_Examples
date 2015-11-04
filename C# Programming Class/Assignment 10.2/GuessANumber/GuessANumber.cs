/* Author: Cameron Block
 * Class: CIS 353 Intermediate C# Programming
 * Assignment 10.2
 * Purpose: to create a number guessing game. 
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GuessANumber {
    public partial class GuessANumber : Form {
        int[] array;

        const int ARRAY_SIZE = 100;

        public GuessANumber() {
            InitializeComponent();

            array = randArray(ARRAY_SIZE, 0, 100);
        }


        static Random rand = new Random();//using a class level random is better than using a local one
        public int[] randArray(int length, int min, int max) {
            int[] array = new int[length];

            for (int i = 0; i < length; i++)
                array[i] = rand.Next(min, max);

            return array;

        }

        private void btnExit_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        int ctGuess = 0;
        int numCorrect = 0;
        int numIncorrect = 0;

        private void btnGuess_Click(object sender, EventArgs e) {
            String text = txtGuess.Text;
            int guess;

            if ( text == "") {
                MessageBox.Show("Please type something into the guess box. ", "Guess");
                return;//exit this handler
            }

            try {
                guess = Convert.ToInt32(text);
            }
            catch (FormatException) {
                MessageBox.Show("Please type a valid integer guess. ", "Guess");
                txtGuess.Text = "";//reset the text box
                return;//exit this handler
            }

            if (array[ctGuess] == guess) {
                //win
                lblOutput.Text = "You Win!!!";
                numCorrect++;
            }
            else{
                //loose
                lblOutput.Text = "Sorry, but the answer was " + array[ctGuess] + ". ";
                numIncorrect++;
            }

            lblCorrect.Text = "Correct: " + numCorrect;
            lblIncorrect.Text = "Incorrect: " + numIncorrect;

            lblGuess.Enabled = false;//should be 'lblHint' 

            ctGuess++;

            btnGuess.Enabled = false;//turn the guess button off
            btnNext.Enabled = true;

        }//end method

        private void btnNext_Click(object sender, EventArgs e) {
            lblOutput.Text = "";//reset the output label
            txtGuess.Text = "";//reset the text box
            lblHint.Text = "";//reset the hint label
            lblGuess.Enabled = true;//should be 'lblHint' 

            if (ctGuess == ARRAY_SIZE) {//if at end of array, reset the array
                array = randArray(ARRAY_SIZE, 0, 100);
                ctGuess = 0;
            }

            btnGuess.Enabled = true;//reset the enabled button
            btnNext.Enabled = false;//finally, turn off our button
        }

        private void lblGuess_MouseHover(object sender, EventArgs e) {
            String hint;

            if (array[ctGuess] > 3 && array[ctGuess] < 96)
                hint = "It's not " + (array[ctGuess] + 3);
            else
                hint = "It's not " + (array[ctGuess] - 1);

            if(btnNext.Enabled != true)
                lblHint.Text = hint;//should be labeled something else
        }//end method

    }//end class
}//end namespace
