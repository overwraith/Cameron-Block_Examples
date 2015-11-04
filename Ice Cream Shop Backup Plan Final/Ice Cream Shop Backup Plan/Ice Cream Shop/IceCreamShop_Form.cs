/*
 * Author: Cameron Block
 * Class: CIS 353 Intermediate C# Programming
 * Group Project - Ice Cream Shop
 * Purpose: To create an ice cream shop program that will store data about ice cream cones and customers. 
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Ice_Cream_Shop {
    public partial class IceCreamShop_Form : Form {

        ArrayList customers = new ArrayList();
        ArrayList orders = new ArrayList();
        
        const String ORDER_FILE = "Orders.txt";
        const String CUSTOMER_FILE = "Customers.txt";

        public IceCreamShop_Form() {
            InitializeComponent();

            this.txtOrderHistory.TabStop = false;
            this.txtOrderInfo.TabStop = false;
            this.txtCustomers.TabStop = false;


            customers = Customer.readCustomersFromFile("Customers.txt");
            orders = new ArrayList();

            //read the order file
            try {
                while (true) {
                    Order or = new Order();
                    or.readFromFile(ORDER_FILE, customers);
                    orders.Add(or);
                    //Console.WriteLine(or);
                }
            }
            catch (Exception ex) { }
        }

        private void btnExit1_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e) {

            //set the accept and cancel buttons when tabs are changed
            if (tabControl1.SelectedIndex == 0) {
                this.AcceptButton = this.btnEnterCust;
                this.CancelButton = this.btnExit1;
            }
            else if (tabControl1.SelectedIndex == 1) {
                this.AcceptButton = this.btnAddCone;
                this.CancelButton = this.btnExit2;
            }
            else {
                this.AcceptButton = this.btnShowHistory;
                this.CancelButton = this.btnExit3;
            }

            //clear all the text boxes
            ClearAllTextBoxes(this);

        }//end handler

        private void ClearAllTextBoxes(Control parent) {
            foreach (Control C in parent.Controls) {
                if (C.GetType() == typeof(TextBox)) {
                    ( C as TextBox ).Clear();
                }
                else if (C.GetType() == typeof(MaskedTextBox)) {
                    ( C as MaskedTextBox ).Clear();
                }
                else {
                    ClearAllTextBoxes(C);
                }
            }
        }//end method

        private void btnShowHistory_Click(object sender, EventArgs e) {
            txtOrderHistory.Clear();

            const int SEPERATOR_LENGTH = 100;

            orders = new ArrayList();

            //read the orders from the file
            try {
                while (true) {
                    Order or = new Order();
                    or.readFromFile(ORDER_FILE, customers);
                    orders.Add(or);
                    //Console.WriteLine(or);
                }
            }
            catch (Exception ex) { }

            int count = orders.Count;

            //print the orders
            //apparently windows text boxes need \r\n, not \n, completely didn't know
            foreach (Order or in orders) {
                txtOrderHistory.Text += ( or.ToString() + "\n" ).Replace("\n", "\r\n");
                
                //print a seperator between the orders, don't print the last sperator
                if(count != 1)
                    for (int i = 0; i < SEPERATOR_LENGTH; i++)
                        txtOrderHistory.Text += "-" + ( i == SEPERATOR_LENGTH - 1 ? "\r\n" : "" );

                count--;
            }//end loop
        }//end handler

        private void btnEnterCust_Click(object sender, EventArgs e) {
            Customer cust;
            int custID;

            try{
                custID = Convert.ToInt32(maskCustID.Text);

                //check for duplicate ID's 
                foreach(Customer customer in customers)
                    if (custID == customer.ID) {
                        MessageBox.Show("Customer ID already found. ", "Error! ");
                        return;
                    }

                cust = new Customer(custID, txtFname.Text, txtLname.Text);

            }catch(FormatException){
                //use the auto numbering scheme
                cust = new Customer(txtFname.Text, txtLname.Text);
            }

            cust.writeToFile(CUSTOMER_FILE);
        }//end handler

        Order ctOrder = null;

        int custID = 0;

        private void btnAddCone_Click(object sender, EventArgs e) {
            Cone cone;
            int scoops = 0;
            //int custID = 0;

            try {
                if (Convert.ToInt32(maskCustID2.Text) != custID) {
                    custID = Convert.ToInt32(maskCustID2.Text);

                    foreach (Customer cust in customers)
                        if (cust.ID == custID) {
                            //ctOrder.Cust = cust;
                            ctOrder = new Order(cust);
                            break;
                        }
                }
            }
            catch (FormatException) {
                MessageBox.Show("Please input customer ID. ", "Error! ");
                return;
            }

            if (radioIceCream.Checked == true)
                cone = new IceCream();
            else if (radioYogurt.Checked == true)
                cone = new Yogurt();
            else {
                MessageBox.Show("Check either Ice Cream or Yogurt. ", "Error! ");
                return;
            }

            try{
                scoops = Convert.ToInt32(maskScoops.Text);
            }catch(FormatException){
                MessageBox.Show("Number of scoops must be entered. ", "Error! ");
                return;
            }

            if (scoops == 0) {
                MessageBox.Show("Number of scoops must be a non zero number. ", "Error! ");
                return;
            }

            cone.NumScoops = scoops;

            if (listFlavor.SelectedIndex == -1 ){
                MessageBox.Show("Please select a flavor. ", "Error! ");
                return;
            }

            cone.ConeFlavor = listFlavor.SelectedItem.ToString();

            try {
                ctOrder += cone;
            }
            catch (ArgumentException ex) {
                MessageBox.Show(ex.Message, "Error! ");
                return;
            }

            txtOrderInfo.Text = ctOrder.ToString().Replace("\n", "\r\n");
        }//end handler

        private void btnEnterOrder_Click(object sender, EventArgs e) {
            if (ctOrder == null) {
                MessageBox.Show("Enter order information first. ", "Error! ");
                return;
            }

            ctOrder.writeToFile(ORDER_FILE);

            //clear the order
            ctOrder = null;

            //clear all the text boxes
            ClearAllTextBoxes(this);
        }//end handler

        private void btnReadCustomers_Click(object sender, EventArgs e) {
            customers = Customer.readCustomersFromFile("Customers.txt");

            txtCustomers.Clear();
            foreach (Customer cust in customers)
                txtCustomers.Text += cust.ToString() + "\r\n";
        }

        private void Form_Load(object sender, EventArgs e) {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.maskCustID, "This field optional. ");
        }
    }//end class
}//end namespace
