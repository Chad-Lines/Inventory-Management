namespace Inventory_Management
{
    partial class ModifyPart
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
            this.lblMachineID_error = new System.Windows.Forms.Label();
            this.lblMinMax_error = new System.Windows.Forms.Label();
            this.lblPrice_error = new System.Windows.Forms.Label();
            this.lblInv_error = new System.Windows.Forms.Label();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.txtpart_mach_comp = new System.Windows.Forms.TextBox();
            this.txtpart_max = new System.Windows.Forms.TextBox();
            this.txtpart_min = new System.Windows.Forms.TextBox();
            this.txtpart_price = new System.Windows.Forms.TextBox();
            this.txtpart_inventory = new System.Windows.Forms.TextBox();
            this.txtpart_name = new System.Windows.Forms.TextBox();
            this.txtpart_id = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.radio_outsourced = new System.Windows.Forms.RadioButton();
            this.radio_inhouse = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblMachineID_error
            // 
            this.lblMachineID_error.AutoSize = true;
            this.lblMachineID_error.ForeColor = System.Drawing.Color.Red;
            this.lblMachineID_error.Location = new System.Drawing.Point(129, 275);
            this.lblMachineID_error.Name = "lblMachineID_error";
            this.lblMachineID_error.Size = new System.Drawing.Size(116, 13);
            this.lblMachineID_error.TabIndex = 45;
            this.lblMachineID_error.Text = "Please enter a number.";
            this.lblMachineID_error.UseWaitCursor = true;
            // 
            // lblMinMax_error
            // 
            this.lblMinMax_error.AutoSize = true;
            this.lblMinMax_error.ForeColor = System.Drawing.Color.Red;
            this.lblMinMax_error.Location = new System.Drawing.Point(129, 234);
            this.lblMinMax_error.Name = "lblMinMax_error";
            this.lblMinMax_error.Size = new System.Drawing.Size(116, 13);
            this.lblMinMax_error.TabIndex = 44;
            this.lblMinMax_error.Text = "Please enter a number.";
            this.lblMinMax_error.UseWaitCursor = true;
            // 
            // lblPrice_error
            // 
            this.lblPrice_error.AutoSize = true;
            this.lblPrice_error.ForeColor = System.Drawing.Color.Red;
            this.lblPrice_error.Location = new System.Drawing.Point(129, 193);
            this.lblPrice_error.Name = "lblPrice_error";
            this.lblPrice_error.Size = new System.Drawing.Size(200, 13);
            this.lblPrice_error.TabIndex = 43;
            this.lblPrice_error.Text = "Please enter a valid price (without the \'$\')";
            this.lblPrice_error.UseWaitCursor = true;
            // 
            // lblInv_error
            // 
            this.lblInv_error.AutoSize = true;
            this.lblInv_error.ForeColor = System.Drawing.Color.Red;
            this.lblInv_error.Location = new System.Drawing.Point(129, 151);
            this.lblInv_error.Name = "lblInv_error";
            this.lblInv_error.Size = new System.Drawing.Size(116, 13);
            this.lblInv_error.TabIndex = 42;
            this.lblInv_error.Text = "Please enter a number.";
            this.lblInv_error.UseWaitCursor = true;
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(248, 295);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 41;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click_1);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(166, 295);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 40;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            // 
            // txtpart_mach_comp
            // 
            this.txtpart_mach_comp.Location = new System.Drawing.Point(129, 252);
            this.txtpart_mach_comp.Name = "txtpart_mach_comp";
            this.txtpart_mach_comp.Size = new System.Drawing.Size(100, 20);
            this.txtpart_mach_comp.TabIndex = 39;
            // 
            // txtpart_max
            // 
            this.txtpart_max.Location = new System.Drawing.Point(244, 211);
            this.txtpart_max.Name = "txtpart_max";
            this.txtpart_max.Size = new System.Drawing.Size(79, 20);
            this.txtpart_max.TabIndex = 38;
            // 
            // txtpart_min
            // 
            this.txtpart_min.Location = new System.Drawing.Point(129, 211);
            this.txtpart_min.Name = "txtpart_min";
            this.txtpart_min.Size = new System.Drawing.Size(68, 20);
            this.txtpart_min.TabIndex = 37;
            // 
            // txtpart_price
            // 
            this.txtpart_price.Location = new System.Drawing.Point(129, 170);
            this.txtpart_price.Name = "txtpart_price";
            this.txtpart_price.Size = new System.Drawing.Size(100, 20);
            this.txtpart_price.TabIndex = 36;
            // 
            // txtpart_inventory
            // 
            this.txtpart_inventory.Location = new System.Drawing.Point(129, 129);
            this.txtpart_inventory.Name = "txtpart_inventory";
            this.txtpart_inventory.Size = new System.Drawing.Size(100, 20);
            this.txtpart_inventory.TabIndex = 35;
            // 
            // txtpart_name
            // 
            this.txtpart_name.Location = new System.Drawing.Point(129, 88);
            this.txtpart_name.Name = "txtpart_name";
            this.txtpart_name.Size = new System.Drawing.Size(100, 20);
            this.txtpart_name.TabIndex = 34;
            // 
            // txtpart_id
            // 
            this.txtpart_id.Location = new System.Drawing.Point(129, 47);
            this.txtpart_id.Name = "txtpart_id";
            this.txtpart_id.Size = new System.Drawing.Size(100, 20);
            this.txtpart_id.TabIndex = 33;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(43, 255);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(117, 13);
            this.label8.TabIndex = 32;
            this.label8.Text = "Mach ID / Comp Name";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(214, 215);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 31;
            this.label7.Text = "Max";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(95, 215);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 13);
            this.label6.TabIndex = 30;
            this.label6.Text = "Min";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(88, 173);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Price";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(71, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Inventory";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(87, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(104, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "ID";
            // 
            // radio_outsourced
            // 
            this.radio_outsourced.AutoSize = true;
            this.radio_outsourced.Location = new System.Drawing.Point(215, 12);
            this.radio_outsourced.Name = "radio_outsourced";
            this.radio_outsourced.Size = new System.Drawing.Size(80, 17);
            this.radio_outsourced.TabIndex = 25;
            this.radio_outsourced.TabStop = true;
            this.radio_outsourced.Text = "Outsourced";
            this.radio_outsourced.UseVisualStyleBackColor = true;
            this.radio_outsourced.CheckedChanged += new System.EventHandler(this.radio_outsourced_CheckedChanged_1);
            // 
            // radio_inhouse
            // 
            this.radio_inhouse.AutoSize = true;
            this.radio_inhouse.Location = new System.Drawing.Point(107, 12);
            this.radio_inhouse.Name = "radio_inhouse";
            this.radio_inhouse.Size = new System.Drawing.Size(68, 17);
            this.radio_inhouse.TabIndex = 24;
            this.radio_inhouse.TabStop = true;
            this.radio_inhouse.Text = "In-House";
            this.radio_inhouse.UseVisualStyleBackColor = true;
            this.radio_inhouse.CheckedChanged += new System.EventHandler(this.radio_inhouse_CheckedChanged_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 17);
            this.label1.TabIndex = 23;
            this.label1.Text = "Modify Part";
            // 
            // ModifyPart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 329);
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
            this.Name = "ModifyPart";
            this.Text = "ModifyPart";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMachineID_error;
        private System.Windows.Forms.Label lblMinMax_error;
        private System.Windows.Forms.Label lblPrice_error;
        private System.Windows.Forms.Label lblInv_error;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.TextBox txtpart_mach_comp;
        private System.Windows.Forms.TextBox txtpart_max;
        private System.Windows.Forms.TextBox txtpart_min;
        private System.Windows.Forms.TextBox txtpart_price;
        private System.Windows.Forms.TextBox txtpart_inventory;
        private System.Windows.Forms.TextBox txtpart_name;
        private System.Windows.Forms.TextBox txtpart_id;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radio_outsourced;
        private System.Windows.Forms.RadioButton radio_inhouse;
        private System.Windows.Forms.Label label1;
    }
}