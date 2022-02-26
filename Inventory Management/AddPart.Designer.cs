namespace Inventory_Management
{
    partial class AddPart
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.radio_inhouse = new System.Windows.Forms.RadioButton();
            this.radio_outsourced = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtpart_id = new System.Windows.Forms.TextBox();
            this.txtpart_name = new System.Windows.Forms.TextBox();
            this.txtpart_inventory = new System.Windows.Forms.TextBox();
            this.txtpart_price = new System.Windows.Forms.TextBox();
            this.txtpart_min = new System.Windows.Forms.TextBox();
            this.txtpart_max = new System.Windows.Forms.TextBox();
            this.txtpart_mach_comp = new System.Windows.Forms.TextBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.lblInv_error = new System.Windows.Forms.Label();
            this.lblPrice_error = new System.Windows.Forms.Label();
            this.lblMinMax_error = new System.Windows.Forms.Label();
            this.lblMachineID_error = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Add Part";
            // 
            // radio_inhouse
            // 
            this.radio_inhouse.AutoSize = true;
            this.radio_inhouse.Location = new System.Drawing.Point(109, 14);
            this.radio_inhouse.Name = "radio_inhouse";
            this.radio_inhouse.Size = new System.Drawing.Size(68, 17);
            this.radio_inhouse.TabIndex = 1;
            this.radio_inhouse.TabStop = true;
            this.radio_inhouse.Text = "In-House";
            this.radio_inhouse.UseVisualStyleBackColor = true;
            this.radio_inhouse.CheckedChanged += new System.EventHandler(this.radio_inhouse_CheckedChanged);
            // 
            // radio_outsourced
            // 
            this.radio_outsourced.AutoSize = true;
            this.radio_outsourced.Location = new System.Drawing.Point(217, 14);
            this.radio_outsourced.Name = "radio_outsourced";
            this.radio_outsourced.Size = new System.Drawing.Size(80, 17);
            this.radio_outsourced.TabIndex = 2;
            this.radio_outsourced.TabStop = true;
            this.radio_outsourced.Text = "Outsourced";
            this.radio_outsourced.UseVisualStyleBackColor = true;
            this.radio_outsourced.CheckedChanged += new System.EventHandler(this.radio_outsourced_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(106, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(89, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(73, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Inventory";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(90, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Price";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(97, 217);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Min";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(216, 217);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Max";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(45, 257);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(117, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Mach ID / Comp Name";
            // 
            // txtpart_id
            // 
            this.txtpart_id.Location = new System.Drawing.Point(131, 49);
            this.txtpart_id.Name = "txtpart_id";
            this.txtpart_id.Size = new System.Drawing.Size(100, 20);
            this.txtpart_id.TabIndex = 10;
            // 
            // txtpart_name
            // 
            this.txtpart_name.Location = new System.Drawing.Point(131, 90);
            this.txtpart_name.Name = "txtpart_name";
            this.txtpart_name.Size = new System.Drawing.Size(100, 20);
            this.txtpart_name.TabIndex = 11;
            this.txtpart_name.TextChanged += new System.EventHandler(this.txtpart_name_TextChanged);
            // 
            // txtpart_inventory
            // 
            this.txtpart_inventory.Location = new System.Drawing.Point(131, 131);
            this.txtpart_inventory.Name = "txtpart_inventory";
            this.txtpart_inventory.Size = new System.Drawing.Size(100, 20);
            this.txtpart_inventory.TabIndex = 12;
            this.txtpart_inventory.TextChanged += new System.EventHandler(this.txtpart_inventory_TextChanged);
            // 
            // txtpart_price
            // 
            this.txtpart_price.Location = new System.Drawing.Point(131, 172);
            this.txtpart_price.Name = "txtpart_price";
            this.txtpart_price.Size = new System.Drawing.Size(100, 20);
            this.txtpart_price.TabIndex = 13;
            this.txtpart_price.TextChanged += new System.EventHandler(this.txtpart_price_TextChanged);
            // 
            // txtpart_min
            // 
            this.txtpart_min.Location = new System.Drawing.Point(131, 213);
            this.txtpart_min.Name = "txtpart_min";
            this.txtpart_min.Size = new System.Drawing.Size(68, 20);
            this.txtpart_min.TabIndex = 14;
            this.txtpart_min.TextChanged += new System.EventHandler(this.txtpart_min_TextChanged);
            // 
            // txtpart_max
            // 
            this.txtpart_max.Location = new System.Drawing.Point(246, 213);
            this.txtpart_max.Name = "txtpart_max";
            this.txtpart_max.Size = new System.Drawing.Size(79, 20);
            this.txtpart_max.TabIndex = 15;
            this.txtpart_max.TextChanged += new System.EventHandler(this.txtpart_max_TextChanged);
            // 
            // txtpart_mach_comp
            // 
            this.txtpart_mach_comp.Location = new System.Drawing.Point(131, 254);
            this.txtpart_mach_comp.Name = "txtpart_mach_comp";
            this.txtpart_mach_comp.Size = new System.Drawing.Size(100, 20);
            this.txtpart_mach_comp.TabIndex = 16;
            this.txtpart_mach_comp.TextChanged += new System.EventHandler(this.txtpart_mach_comp_TextChanged);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(168, 297);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 17;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(250, 297);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 18;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // lblInv_error
            // 
            this.lblInv_error.AutoSize = true;
            this.lblInv_error.ForeColor = System.Drawing.Color.Red;
            this.lblInv_error.Location = new System.Drawing.Point(131, 153);
            this.lblInv_error.Name = "lblInv_error";
            this.lblInv_error.Size = new System.Drawing.Size(116, 13);
            this.lblInv_error.TabIndex = 19;
            this.lblInv_error.Text = "Please enter a number.";
            this.lblInv_error.UseWaitCursor = true;
            // 
            // lblPrice_error
            // 
            this.lblPrice_error.AutoSize = true;
            this.lblPrice_error.ForeColor = System.Drawing.Color.Red;
            this.lblPrice_error.Location = new System.Drawing.Point(131, 195);
            this.lblPrice_error.Name = "lblPrice_error";
            this.lblPrice_error.Size = new System.Drawing.Size(200, 13);
            this.lblPrice_error.TabIndex = 20;
            this.lblPrice_error.Text = "Please enter a valid price (without the \'$\')";
            this.lblPrice_error.UseWaitCursor = true;
            // 
            // lblMinMax_error
            // 
            this.lblMinMax_error.AutoSize = true;
            this.lblMinMax_error.ForeColor = System.Drawing.Color.Red;
            this.lblMinMax_error.Location = new System.Drawing.Point(131, 236);
            this.lblMinMax_error.Name = "lblMinMax_error";
            this.lblMinMax_error.Size = new System.Drawing.Size(116, 13);
            this.lblMinMax_error.TabIndex = 21;
            this.lblMinMax_error.Text = "Please enter a number.";
            this.lblMinMax_error.UseWaitCursor = true;
            // 
            // lblMachineID_error
            // 
            this.lblMachineID_error.AutoSize = true;
            this.lblMachineID_error.ForeColor = System.Drawing.Color.Red;
            this.lblMachineID_error.Location = new System.Drawing.Point(131, 277);
            this.lblMachineID_error.Name = "lblMachineID_error";
            this.lblMachineID_error.Size = new System.Drawing.Size(116, 13);
            this.lblMachineID_error.TabIndex = 22;
            this.lblMachineID_error.Text = "Please enter a number.";
            this.lblMachineID_error.UseWaitCursor = true;
            // 
            // AddPart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 331);
            this.Controls.Add(this.lblMachineID_error);
            this.Controls.Add(this.lblMinMax_error);
            this.Controls.Add(this.lblPrice_error);
            this.Controls.Add(this.lblInv_error);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.txtpart_mach_comp);
            this.Controls.Add(this.txtpart_max);
            this.Controls.Add(this.txtpart_min);
            this.Controls.Add(this.txtpart_price);
            this.Controls.Add(this.txtpart_inventory);
            this.Controls.Add(this.txtpart_name);
            this.Controls.Add(this.txtpart_id);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.radio_outsourced);
            this.Controls.Add(this.radio_inhouse);
            this.Controls.Add(this.label1);
            this.Name = "AddPart";
            this.Text = "AddPart";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radio_inhouse;
        private System.Windows.Forms.RadioButton radio_outsourced;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtpart_id;
        private System.Windows.Forms.TextBox txtpart_name;
        private System.Windows.Forms.TextBox txtpart_inventory;
        private System.Windows.Forms.TextBox txtpart_price;
        private System.Windows.Forms.TextBox txtpart_min;
        private System.Windows.Forms.TextBox txtpart_max;
        private System.Windows.Forms.TextBox txtpart_mach_comp;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Label lblInv_error;
        private System.Windows.Forms.Label lblPrice_error;
        private System.Windows.Forms.Label lblMinMax_error;
        private System.Windows.Forms.Label lblMachineID_error;
    }
}