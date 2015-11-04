/* Author: Cameron Block
 * Class: CIS 353 Intermediate C# Programming
 * Assignment 11.2
 * Purpose: to create a 'friends' list program. 
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Assignment_11._2 {
    public partial class Friends : Form {

        Friend friend = new Friend();
        StreamReader reader = new StreamReader(new FileStream("Friends.txt", FileMode.OpenOrCreate, FileAccess.Read, FileShare.ReadWrite));
        StreamWriter writer = new StreamWriter(new FileStream("Friends.txt", FileMode.Append, FileAccess.Write, FileShare.ReadWrite));

        public Friends() {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e) {
            writer.Flush();
            writer.Close();
            reader.Close();

            Application.Exit();
        }//end event handler

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e) {
            //change the accept and cancel buttons if the tab changes

            if (tabControl1.SelectedIndex == 0) {
                this.AcceptButton = this.btnEnterFriend;
                this.CancelButton = this.btnExit;
            }
            else if (tabControl1.SelectedIndex == 1) {
                this.AcceptButton = this.btnRead;
                this.CancelButton = this.btnExit2;
            }
            else{
                this.AcceptButton = this.btnReminder;
                this.CancelButton = this.btnExit3;
            }

            //clear all the text boxes
            txtFirstName.Clear();
            txtLastName.Clear();
            txtBirthMonth.Clear();
            txtBirthDay.Clear();
            maskPhoneNum.Clear();

            //clear the text areas
            listRead.Items.Clear();
            listReminder.Items.Clear();

            txtBirthMonth2.Clear();
        }//end event handler

        private void btnRead_Click(object sender, EventArgs e) {
            String record;

            //reset the list
            listRead.Items.Clear();

            //read the file
            try {
                while (( record = reader.ReadLine() ) != null) {
                    String[] fields = record.Split(',');

                    //replace commas with spaces
                    String str = "";
                    for (int i = 0; i < fields.Length; i++)
                        str += fields[i] + ( i != fields.Length - 1 ? ( i == 3 ? "/" : " " ) : "" );
                    //only place spaces between fields, not the last field
                    //place a '/' between the third and fourth fields
                    //that's right, nested ternary's 

                    //place the text in the list box
                    listRead.Items.Add(str);
                }
            }
            catch (IOException) {
                MessageBox.Show("The file seems to not exist, or is locked by another process. ", "Error!");
            }

            //reset the stream position
            reader.BaseStream.Seek(0, SeekOrigin.Begin);
            reader.DiscardBufferedData();
        }//end event handler

        private void btnEnterFriend_Click(object sender, EventArgs e) {
            if (txtFirstName.Text == "") {
                MessageBox.Show("Please input something into the first name text box. ", "Error!");
                return;
            }
            else if (txtLastName.Text == "") {
                MessageBox.Show("Please input something into the last name text box. ", "Error!");
                return;
            }
            else if (txtBirthMonth.Text == "") {
                MessageBox.Show("Please input something into the birth month text box. ", "Error!");
                return;
            }
            else if (txtBirthDay.Text == "") {
                MessageBox.Show("Please input something into the birth day text box. ", "Error!");
                return;
            }
            else if (maskPhoneNum.Text == "   -") {
                MessageBox.Show("Please input something into the phone number text box. ", "Error!");
                return;
            }
            
            friend.Fname = txtFirstName.Text;
            friend.Lname = txtLastName.Text;

            try {
                friend.Month = Convert.ToInt32(txtBirthMonth.Text);
                friend.Day = Convert.ToInt32(txtBirthDay.Text);

                friend.PhoneNum = maskPhoneNum.Text;

                writer.WriteLine(friend.ToString());

                writer.Flush();

                MessageBox.Show(friend.ToString(), "Success!");
            }
            catch (FormatException) {
                MessageBox.Show("Please input valid information into the text box month, or birth day. ", "Error!");
                return;
            }
            catch(IOException){
                MessageBox.Show("The file seems to not exist, or is locked by another process. ", "Error!");
                return;
            }

            //clear all the text boxes
            txtFirstName.Clear();
            txtLastName.Clear();
            txtBirthMonth.Clear();
            txtBirthDay.Clear();
            maskPhoneNum.Clear();

        }//end event handler

        private void btnReminder_Click(object sender, EventArgs e) {
            int searchMonth = 999;//there is no month 999, if is 999 do not print anything

            try {
                searchMonth = Convert.ToInt32(txtBirthMonth2.Text);
            }
            catch (FormatException) {
                MessageBox.Show("Please input something into the birth month text box. ", "Error!");
            }

            String record;

            //reset the list
            listReminder.Items.Clear();

            //read the file
            try {
                while (( record = reader.ReadLine() ) != null) {
                    String[] fields = record.Split(',');

                    if (Convert.ToInt32(fields[3]) == searchMonth && searchMonth != 999) {//if month matches, then display it

                        //replace commas with spaces
                        String str = "";
                        for (int i = 0; i < fields.Length; i++)
                            str += fields[i] + ( i != fields.Length - 1 ? (i == 3 ? "/" : " ") : "" );
                        //only place spaces between fields, not the last field
                        //place a '/' between the third and fourth fields
                        //that's right, nested ternary's 

                        //place the text in the list box
                        listReminder.Items.Add(str);
                    }
                }
            }
            catch(FormatException){//error in the format of the input file
                MessageBox.Show("The file seems to not be in the correct format. ", "Error!");
            }
            catch (IOException) {
                MessageBox.Show("The file seems to not exist, or is locked by another process. ", "Error!");
            }

            //reset the stream position
            reader.BaseStream.Seek(0, SeekOrigin.Begin);
            reader.DiscardBufferedData();

            //clear the text box
            txtBirthMonth2.Clear();

        }//end event handler
    }//end form
}//end namespace
