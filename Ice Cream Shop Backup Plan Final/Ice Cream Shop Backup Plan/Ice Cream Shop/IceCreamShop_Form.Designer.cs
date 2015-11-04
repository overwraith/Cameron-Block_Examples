/*
 * Author: Cameron Block
 * Class: CIS 353 Intermediate C# Programming
 * Group Project - Ice Cream Shop
 * Purpose: To create an ice cream shop program that will store data about ice cream cones and customers. 
 */

namespace Ice_Cream_Shop {
    partial class IceCreamShop_Form {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && ( components != null )) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabCustomer = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.btnReadCustomers = new System.Windows.Forms.Button();
            this.txtCustomers = new System.Windows.Forms.TextBox();
            this.btnExit1 = new System.Windows.Forms.Button();
            this.btnEnterCust = new System.Windows.Forms.Button();
            this.txtLname = new System.Windows.Forms.TextBox();
            this.txtFname = new System.Windows.Forms.TextBox();
            this.maskCustID = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabOrders = new System.Windows.Forms.TabPage();
            this.btnEnterOrder = new System.Windows.Forms.Button();
            this.maskCustID2 = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.maskScoops = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.radioYogurt = new System.Windows.Forms.RadioButton();
            this.radioIceCream = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOrderInfo = new System.Windows.Forms.TextBox();
            this.btnExit2 = new System.Windows.Forms.Button();
            this.btnAddCone = new System.Windows.Forms.Button();
            this.tabOrderHist = new System.Windows.Forms.TabPage();
            this.btnExit3 = new System.Windows.Forms.Button();
            this.btnShowHistory = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtOrderHistory = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.listFlavor = new System.Windows.Forms.ListBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tabControl1.SuspendLayout();
            this.tabCustomer.SuspendLayout();
            this.tabOrders.SuspendLayout();
            this.tabOrderHist.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabCustomer);
            this.tabControl1.Controls.Add(this.tabOrders);
            this.tabControl1.Controls.Add(this.tabOrderHist);
            this.tabControl1.Location = new System.Drawing.Point(13, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(371, 360);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabCustomer
            // 
            this.tabCustomer.Controls.Add(this.label8);
            this.tabCustomer.Controls.Add(this.btnReadCustomers);
            this.tabCustomer.Controls.Add(this.txtCustomers);
            this.tabCustomer.Controls.Add(this.btnExit1);
            this.tabCustomer.Controls.Add(this.btnEnterCust);
            this.tabCustomer.Controls.Add(this.txtLname);
            this.tabCustomer.Controls.Add(this.txtFname);
            this.tabCustomer.Controls.Add(this.maskCustID);
            this.tabCustomer.Controls.Add(this.label3);
            this.tabCustomer.Controls.Add(this.label2);
            this.tabCustomer.Controls.Add(this.label1);
            this.tabCustomer.Location = new System.Drawing.Point(4, 22);
            this.tabCustomer.Name = "tabCustomer";
            this.tabCustomer.Padding = new System.Windows.Forms.Padding(3);
            this.tabCustomer.Size = new System.Drawing.Size(363, 334);
            this.tabCustomer.TabIndex = 0;
            this.tabCustomer.Text = "Add Customers";
            this.tabCustomer.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Customers: ";
            // 
            // btnReadCustomers
            // 
            this.btnReadCustomers.Location = new System.Drawing.Point(136, 295);
            this.btnReadCustomers.Name = "btnReadCustomers";
            this.btnReadCustomers.Size = new System.Drawing.Size(93, 33);
            this.btnReadCustomers.TabIndex = 6;
            this.btnReadCustomers.Text = "Read Customers";
            this.btnReadCustomers.UseVisualStyleBackColor = true;
            this.btnReadCustomers.Click += new System.EventHandler(this.btnReadCustomers_Click);
            // 
            // txtCustomers
            // 
            this.txtCustomers.Location = new System.Drawing.Point(13, 29);
            this.txtCustomers.Multiline = true;
            this.txtCustomers.Name = "txtCustomers";
            this.txtCustomers.ReadOnly = true;
            this.txtCustomers.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtCustomers.Size = new System.Drawing.Size(344, 166);
            this.txtCustomers.TabIndex = 5;
            // 
            // btnExit1
            // 
            this.btnExit1.Location = new System.Drawing.Point(235, 295);
            this.btnExit1.Name = "btnExit1";
            this.btnExit1.Size = new System.Drawing.Size(93, 33);
            this.btnExit1.TabIndex = 4;
            this.btnExit1.Text = "Exit";
            this.btnExit1.UseVisualStyleBackColor = true;
            this.btnExit1.Click += new System.EventHandler(this.btnExit1_Click);
            // 
            // btnEnterCust
            // 
            this.btnEnterCust.Location = new System.Drawing.Point(37, 295);
            this.btnEnterCust.Name = "btnEnterCust";
            this.btnEnterCust.Size = new System.Drawing.Size(93, 33);
            this.btnEnterCust.TabIndex = 3;
            this.btnEnterCust.Text = "Enter Customer";
            this.btnEnterCust.UseVisualStyleBackColor = true;
            this.btnEnterCust.Click += new System.EventHandler(this.btnEnterCust_Click);
            // 
            // txtLname
            // 
            this.txtLname.Location = new System.Drawing.Point(87, 253);
            this.txtLname.Name = "txtLname";
            this.txtLname.Size = new System.Drawing.Size(100, 20);
            this.txtLname.TabIndex = 2;
            // 
            // txtFname
            // 
            this.txtFname.Location = new System.Drawing.Point(87, 227);
            this.txtFname.Name = "txtFname";
            this.txtFname.Size = new System.Drawing.Size(100, 20);
            this.txtFname.TabIndex = 1;
            // 
            // maskCustID
            // 
            this.maskCustID.Location = new System.Drawing.Point(87, 201);
            this.maskCustID.Mask = "00000";
            this.maskCustID.Name = "maskCustID";
            this.maskCustID.Size = new System.Drawing.Size(100, 20);
            this.maskCustID.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 256);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Last Name: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 230);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "First Name: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 204);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Customer ID: ";
            // 
            // tabOrders
            // 
            this.tabOrders.Controls.Add(this.listFlavor);
            this.tabOrders.Controls.Add(this.label9);
            this.tabOrders.Controls.Add(this.btnEnterOrder);
            this.tabOrders.Controls.Add(this.maskCustID2);
            this.tabOrders.Controls.Add(this.label7);
            this.tabOrders.Controls.Add(this.maskScoops);
            this.tabOrders.Controls.Add(this.label5);
            this.tabOrders.Controls.Add(this.radioYogurt);
            this.tabOrders.Controls.Add(this.radioIceCream);
            this.tabOrders.Controls.Add(this.label4);
            this.tabOrders.Controls.Add(this.txtOrderInfo);
            this.tabOrders.Controls.Add(this.btnExit2);
            this.tabOrders.Controls.Add(this.btnAddCone);
            this.tabOrders.Location = new System.Drawing.Point(4, 22);
            this.tabOrders.Name = "tabOrders";
            this.tabOrders.Padding = new System.Windows.Forms.Padding(3);
            this.tabOrders.Size = new System.Drawing.Size(363, 334);
            this.tabOrders.TabIndex = 1;
            this.tabOrders.Text = "Place Order";
            this.tabOrders.UseVisualStyleBackColor = true;
            // 
            // btnEnterOrder
            // 
            this.btnEnterOrder.Location = new System.Drawing.Point(121, 295);
            this.btnEnterOrder.Name = "btnEnterOrder";
            this.btnEnterOrder.Size = new System.Drawing.Size(93, 33);
            this.btnEnterOrder.TabIndex = 11;
            this.btnEnterOrder.Text = "Enter Order";
            this.btnEnterOrder.UseVisualStyleBackColor = true;
            this.btnEnterOrder.Click += new System.EventHandler(this.btnEnterOrder_Click);
            // 
            // maskCustID2
            // 
            this.maskCustID2.Location = new System.Drawing.Point(114, 156);
            this.maskCustID2.Mask = "00000";
            this.maskCustID2.Name = "maskCustID2";
            this.maskCustID2.Size = new System.Drawing.Size(100, 20);
            this.maskCustID2.TabIndex = 10;
            this.maskCustID2.ValidatingType = typeof(int);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 156);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Customer Number: ";
            // 
            // maskScoops
            // 
            this.maskScoops.Location = new System.Drawing.Point(114, 218);
            this.maskScoops.Mask = "0";
            this.maskScoops.Name = "maskScoops";
            this.maskScoops.Size = new System.Drawing.Size(100, 20);
            this.maskScoops.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 225);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Scoops: ";
            // 
            // radioYogurt
            // 
            this.radioYogurt.AutoSize = true;
            this.radioYogurt.Location = new System.Drawing.Point(10, 201);
            this.radioYogurt.Name = "radioYogurt";
            this.radioYogurt.Size = new System.Drawing.Size(56, 17);
            this.radioYogurt.TabIndex = 1;
            this.radioYogurt.Text = "Yogurt";
            this.radioYogurt.UseVisualStyleBackColor = true;
            // 
            // radioIceCream
            // 
            this.radioIceCream.AutoSize = true;
            this.radioIceCream.Checked = true;
            this.radioIceCream.Location = new System.Drawing.Point(10, 175);
            this.radioIceCream.Name = "radioIceCream";
            this.radioIceCream.Size = new System.Drawing.Size(73, 17);
            this.radioIceCream.TabIndex = 0;
            this.radioIceCream.TabStop = true;
            this.radioIceCream.Text = "Ice Cream\r\n";
            this.radioIceCream.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Order Information";
            // 
            // txtOrderInfo
            // 
            this.txtOrderInfo.Location = new System.Drawing.Point(6, 23);
            this.txtOrderInfo.Multiline = true;
            this.txtOrderInfo.Name = "txtOrderInfo";
            this.txtOrderInfo.ReadOnly = true;
            this.txtOrderInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOrderInfo.Size = new System.Drawing.Size(351, 113);
            this.txtOrderInfo.TabIndex = 2;
            this.txtOrderInfo.TabStop = false;
            // 
            // btnExit2
            // 
            this.btnExit2.Location = new System.Drawing.Point(220, 295);
            this.btnExit2.Name = "btnExit2";
            this.btnExit2.Size = new System.Drawing.Size(93, 33);
            this.btnExit2.TabIndex = 4;
            this.btnExit2.Text = "Exit";
            this.btnExit2.UseVisualStyleBackColor = true;
            this.btnExit2.Click += new System.EventHandler(this.btnExit1_Click);
            // 
            // btnAddCone
            // 
            this.btnAddCone.Location = new System.Drawing.Point(22, 295);
            this.btnAddCone.Name = "btnAddCone";
            this.btnAddCone.Size = new System.Drawing.Size(93, 33);
            this.btnAddCone.TabIndex = 3;
            this.btnAddCone.Text = "Add Cone";
            this.btnAddCone.UseVisualStyleBackColor = true;
            this.btnAddCone.Click += new System.EventHandler(this.btnAddCone_Click);
            // 
            // tabOrderHist
            // 
            this.tabOrderHist.Controls.Add(this.btnExit3);
            this.tabOrderHist.Controls.Add(this.btnShowHistory);
            this.tabOrderHist.Controls.Add(this.label6);
            this.tabOrderHist.Controls.Add(this.txtOrderHistory);
            this.tabOrderHist.Location = new System.Drawing.Point(4, 22);
            this.tabOrderHist.Name = "tabOrderHist";
            this.tabOrderHist.Size = new System.Drawing.Size(363, 334);
            this.tabOrderHist.TabIndex = 2;
            this.tabOrderHist.Text = "Order History";
            this.tabOrderHist.UseVisualStyleBackColor = true;
            // 
            // btnExit3
            // 
            this.btnExit3.Location = new System.Drawing.Point(170, 298);
            this.btnExit3.Name = "btnExit3";
            this.btnExit3.Size = new System.Drawing.Size(93, 33);
            this.btnExit3.TabIndex = 1;
            this.btnExit3.Text = "Exit";
            this.btnExit3.UseVisualStyleBackColor = true;
            this.btnExit3.Click += new System.EventHandler(this.btnExit1_Click);
            // 
            // btnShowHistory
            // 
            this.btnShowHistory.Location = new System.Drawing.Point(71, 298);
            this.btnShowHistory.Name = "btnShowHistory";
            this.btnShowHistory.Size = new System.Drawing.Size(93, 33);
            this.btnShowHistory.TabIndex = 0;
            this.btnShowHistory.Text = "Show History";
            this.btnShowHistory.UseVisualStyleBackColor = true;
            this.btnShowHistory.Click += new System.EventHandler(this.btnShowHistory_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Order History: ";
            // 
            // txtOrderHistory
            // 
            this.txtOrderHistory.Location = new System.Drawing.Point(6, 26);
            this.txtOrderHistory.Multiline = true;
            this.txtOrderHistory.Name = "txtOrderHistory";
            this.txtOrderHistory.ReadOnly = true;
            this.txtOrderHistory.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOrderHistory.Size = new System.Drawing.Size(351, 266);
            this.txtOrderHistory.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 257);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Cone Flavor: ";
            // 
            // listFlavor
            // 
            this.listFlavor.FormattingEnabled = true;
            this.listFlavor.Items.AddRange(new object[] {
            "Pickle",
            "Tangarine",
            "Nectarine",
            "Orange",
            "Chocolate",
            "Fudge",
            "Vanilla",
            "Strawberry",
            "Spumoni"});
            this.listFlavor.Location = new System.Drawing.Point(114, 253);
            this.listFlavor.Name = "listFlavor";
            this.listFlavor.Size = new System.Drawing.Size(120, 30);
            this.listFlavor.TabIndex = 13;
            // 
            // IceCreamShop_Form
            // 
            this.AcceptButton = this.btnEnterCust;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit1;
            this.ClientSize = new System.Drawing.Size(396, 385);
            this.Controls.Add(this.tabControl1);
            this.Name = "IceCreamShop_Form";
            this.Text = "IceCreamShop_Form";
            this.Load += new System.EventHandler(this.Form_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabCustomer.ResumeLayout(false);
            this.tabCustomer.PerformLayout();
            this.tabOrders.ResumeLayout(false);
            this.tabOrders.PerformLayout();
            this.tabOrderHist.ResumeLayout(false);
            this.tabOrderHist.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabCustomer;
        private System.Windows.Forms.TabPage tabOrders;
        private System.Windows.Forms.TabPage tabOrderHist;
        private System.Windows.Forms.MaskedTextBox maskCustID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExit1;
        private System.Windows.Forms.Button btnEnterCust;
        private System.Windows.Forms.TextBox txtLname;
        private System.Windows.Forms.TextBox txtFname;
        private System.Windows.Forms.Button btnExit2;
        private System.Windows.Forms.Button btnAddCone;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtOrderInfo;
        private System.Windows.Forms.RadioButton radioYogurt;
        private System.Windows.Forms.RadioButton radioIceCream;
        private System.Windows.Forms.MaskedTextBox maskScoops;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnExit3;
        private System.Windows.Forms.Button btnShowHistory;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtOrderHistory;
        private System.Windows.Forms.MaskedTextBox maskCustID2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnEnterOrder;
        private System.Windows.Forms.TextBox txtCustomers;
        private System.Windows.Forms.Button btnReadCustomers;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox listFlavor;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}