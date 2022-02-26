using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory_Management
{
    public partial class AddPart : Form
    {
        public string inHouseText = "Machine ID";
        public string outsourceText = "Company Name";
        public static BindingList<Part> parts = Part.parts;

        public AddPart()
        {
            InitializeComponent();

            // Setting the initial state of the various form elements
            radio_inhouse.Checked = true;   // By default we're assuming that the part in-house            
            txtpart_id.Text = GetNextID();  // Populate the Part ID text box
            txtpart_id.ReadOnly = true;     // Disable the user from chaning the Part ID value
            SaveButton.Enabled = false;     // Disabling the save button (until all data is entered)            
            lblInv_error.Hide();            // Hiding the Inventory Error label
            lblPrice_error.Hide();          // Hiding the Pirce/Cost Error label
            lblMinMax_error.Hide();         // Hiding the Min/Max Error label
            lblMachineID_error.Hide();      // Hiding the MachineID Error label

            // Since the texboxes are all empty, we initialize them with a red background indicating that they are required.
            txtpart_name.BackColor = System.Drawing.Color.Salmon;
            txtpart_inventory.BackColor = System.Drawing.Color.Salmon;
            txtpart_price.BackColor = System.Drawing.Color.Salmon;
            txtpart_min.BackColor = System.Drawing.Color.Salmon;
            txtpart_max.BackColor = System.Drawing.Color.Salmon;
            txtpart_mach_comp.BackColor = System.Drawing.Color.Salmon;

        }

       public string GetNextID()
        {
            // The purpose of this method is to generate the next ID automaticall by
            // comparing the existing IDs

            int nextID = 0;                                                         // Initialize nextID as 0
            for (int i = 0; i < parts.Count; i++)                                   // For each part...
            {
                if (parts[i].PartId >= nextID) { nextID = parts[i].PartId + 1; }    // If the PartID is greater or equal than the nextID, then
            }                                                                       // set the nextID to PartID + 1

            return nextID.ToString();                                               // Finally we return the nextID as a string
        }

        private bool allowSave()
        {
            return true;

            //int number;
            //return (!(string.IsNullOrWhiteSpace(txtpart_name.Text)) &&
        }

        private void radio_outsourced_CheckedChanged(object sender, EventArgs e)
        {
            label8.Text = outsourceText;    // Since the part outsourced, we set the text accordingly
            lblMachineID_error.Hide();      // Hide any existing errors on button switch
        }

        private void radio_inhouse_CheckedChanged(object sender, EventArgs e)
        {
            label8.Text = inHouseText;  // Since the part is assumed to be machined in-house, we set the text accordingly
            lblMachineID_error.Hide();  // Hide any existing errors on button switch
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtpart_name_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtpart_name.Text))
            {
                txtpart_name.BackColor = System.Drawing.Color.Salmon;
                Console.WriteLine("Empty");
            }
            else
            {
                txtpart_name.BackColor = System.Drawing.Color.White;
                Console.WriteLine("Not Empty");
            }

            SaveButton.Enabled = allowSave();
        }

        private void txtpart_inventory_TextChanged(object sender, EventArgs e)
        {
            VerifyNumericInput(txtpart_inventory, lblInv_error);
        }

        private void txtpart_price_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Decimal.Parse(txtpart_price.Text);                      // Try to convert the string into an Int
                lblPrice_error.Hide();                                  // If it works, hide the error label

            }
            catch (FormatException)
            {
                lblPrice_error.Show();                                  // If it doesn't work, show the error label
            }

            if (string.IsNullOrWhiteSpace(txtpart_price.Text))          // If the textbox is empty...
            {
                txtpart_price.BackColor = System.Drawing.Color.Salmon;  // Set the background color to Salmon
            }
            else
            {
                txtpart_price.BackColor = System.Drawing.Color.White;   // If it's not empty, set it to White
            }

            SaveButton.Enabled = allowSave();                           // Check if we can save
        }   

        private void VerifyNumericInput(TextBox textBox, Label label)
        {
            // This method is used to verify that the user has input a number and not a string.
            try
            {
                Int32.Parse(textBox.Text);                          // Try to convert the string into an Int
                label.Hide();                                       // If it works, hide the error label

            }
            catch (FormatException)
            {
                label.Show();                                       // If it doesn't work, show the error label
            }

            if (string.IsNullOrWhiteSpace(textBox.Text))            // If the textbox is empty...
            {
                textBox.BackColor = System.Drawing.Color.Salmon;    // Set the background color to Salmon
            }
            else
            {
                textBox.BackColor = System.Drawing.Color.White;     // If it's not empty, set it to White
            }

            SaveButton.Enabled = allowSave();                       // Check if we can save
        }

        private void txtpart_min_TextChanged(object sender, EventArgs e)
        {
            VerifyNumericInput(txtpart_min, lblMinMax_error);
        }

        private void txtpart_max_TextChanged(object sender, EventArgs e)
        {
            VerifyNumericInput(txtpart_max, lblMinMax_error);
        }

        private void txtpart_mach_comp_TextChanged(object sender, EventArgs e)
        {
            if (radio_inhouse.Checked == true)                              // If this is an in-house item...
            {
                VerifyNumericInput(txtpart_mach_comp, lblMachineID_error);  // Make sure a Machine ID number is valid. Otherwise...
            }
            else
            {
                
                if (string.IsNullOrWhiteSpace(txtpart_mach_comp.Text))          // If the textbox is empty...
                {
                    txtpart_mach_comp.BackColor = System.Drawing.Color.Salmon;  // Set the background color to Salmon
                    lblMachineID_error.Text = "Please enter a company name";    // Prompt the user to enter a Company
                    lblMachineID_error.Show();                                  // Show the error to the user
                }
                else
                {
                    txtpart_mach_comp.BackColor = System.Drawing.Color.White;   // If it's not empty, set it to White
                    lblMachineID_error.Hide();                                  // Hide the error label
                }
            }
        }
    }
}
