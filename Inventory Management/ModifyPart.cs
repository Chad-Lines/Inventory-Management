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
    public partial class ModifyPart : Form
    {
        private Part currentPart = Form1.currentPart;                       // This is the part selected in the MainScreen

        // String Variables
        public string inHouseText = "Machine ID";                           // The label text for Inhouse parts
        public string outsourceText = "Company Name";                       // The label text for Outsourced parts
        public string outsourceInputError = "Please enter a company name";  // The error text for Outsourced parts

        // Validation Variables
        public bool nameValid = false;
        public bool inventoryValid = false;
        public bool priceValid = false;
        public bool minValid = false;
        public bool maxValid = false;
        public bool machOrCompValid = false;
        public bool initialized = false;

        public ModifyPart(Inhouse part)
        {
            InitializeComponent();

            // Resetting all of the errors
            SaveButton.Enabled = false;                         // Disabling the save button (until all data is entered)            
            lblInv_error.Hide();                                // Hiding the Inventory Error label
            lblPrice_error.Hide();                              // Hiding the Pirce/Cost Error label
            lblMinMax_error.Hide();                             // Hiding the Min/Max Error label
            lblMachineID_error.Hide();                          // Hiding the MachineID Error label

            radio_inhouse.Checked = true;
            radio_outsourced.Checked = false;
            txtpart_id.Text = part.PartId.ToString();
            txtpart_id.ReadOnly = true;                         // Disable the user from chaning the Part ID value
            txtpart_name.Text = part.Name;
            txtpart_inventory.Text = part.InStock.ToString();
            txtpart_price.Text = part.Price.ToString();
            txtpart_min.Text = part.Min.ToString();
            txtpart_max.Text = part.Max.ToString();
            txtpart_mach_comp.Text = part.MachineID.ToString(); // The Inhouse parts use the machine ID
            label8.Text = inHouseText;
            initialized = true;
        }

        public ModifyPart(Outsourced part)
        {
            InitializeComponent();

            // Resetting all of the errors
            SaveButton.Enabled = false;                         // Disabling the save button (until all data is entered)            
            lblInv_error.Hide();                                // Hiding the Inventory Error label
            lblPrice_error.Hide();                              // Hiding the Pirce/Cost Error label
            lblMinMax_error.Hide();                             // Hiding the Min/Max Error label
            lblMachineID_error.Hide();                          // Hiding the MachineID Error label

            radio_inhouse.Checked = false;
            radio_outsourced.Checked = true;
            txtpart_id.Text = part.PartId.ToString();
            txtpart_id.ReadOnly = true;                         // Disable the user from chaning the Part ID value
            txtpart_name.Text = part.Name;
            txtpart_inventory.Text = part.InStock.ToString();
            txtpart_price.Text = part.Price.ToString();
            txtpart_min.Text = part.Min.ToString();
            txtpart_max.Text = part.Max.ToString();
            txtpart_mach_comp.Text = part.CompanyName;          // Outsourced items use a Company Name
            label8.Text = outsourceText;
            initialized = true;
        }

        private bool allowSave()
        {
            // This method checks whether all the inputs have been marked as valid.
            // If they have, then we return 'true' which enables the Save button
            if (initialized)
            {
                if (!string.IsNullOrWhiteSpace(txtpart_max.Text) && !string.IsNullOrWhiteSpace(txtpart_min.Text))
                {
                    if (Int32.Parse(txtpart_max.Text) < Int32.Parse(txtpart_min.Text))
                    {
                        MessageBox.Show("Max must be greater than Min");
                        return false;
                    }
                    else if(!string.IsNullOrWhiteSpace(txtpart_max.Text) && !string.IsNullOrWhiteSpace(txtpart_min.Text) &&
                        !string.IsNullOrWhiteSpace(txtpart_inventory.Text))
                    {
                        if (Int32.Parse(txtpart_inventory.Text) > Int32.Parse(txtpart_max.Text) ||
                            Int32.Parse(txtpart_inventory.Text) < Int32.Parse(txtpart_min.Text))
                        {
                            MessageBox.Show("Inventory must be between Min and Max");
                            return false;
                        }
                        else
                        {
                            return nameValid && inventoryValid && priceValid &&
                            minValid && maxValid;
                        }                            
                    }
                    else
                    {
                        return nameValid && inventoryValid && priceValid &&
                        minValid && maxValid;
                    }
                }
                else
                {
                    return nameValid && inventoryValid && priceValid &&
                    minValid && maxValid;
                }
            }
            else
            {
                return false;
            }

            
            if (Int32.Parse(txtpart_max.Text) < Int32.Parse(txtpart_min.Text))
            {
                MessageBox.Show("Max must be greater than Min");
                return false;
            }
            else if (Int32.Parse(txtpart_inventory.Text) > Int32.Parse(txtpart_max.Text) ||
                Int32.Parse(txtpart_inventory.Text) < Int32.Parse(txtpart_min.Text))
            {
                MessageBox.Show("Inventory must be between Min and Max");
                return false;
            }
            else
            {
                return nameValid && inventoryValid && priceValid &&
                minValid && maxValid;
            }

        }

        private void CancelButton_Click_1(object sender, EventArgs e)
        {
            // Close out the form
            this.Close();
        }

        private void radio_inhouse_CheckedChanged_1(object sender, EventArgs e)
        {
            label8.Text = inHouseText;  // Since the part is assumed to be machined in-house, we set the text accordingly
            lblMachineID_error.Hide();  // Hide any existing errors on button switch
        }

        private void radio_outsourced_CheckedChanged_1(object sender, EventArgs e)
        {
            label8.Text = outsourceText;    // Since the part outsourced, we set the text accordingly
            lblMachineID_error.Hide();      // Hide any existing errors on button switch
        }

        private void txtpart_name_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtpart_name.Text))           // If the textbox is empty...
            {
                txtpart_name.BackColor = System.Drawing.Color.Salmon;   // Set the background color to Salmon
                nameValid = false;                                      //  Marking the field as invalid
            }
            else
            {
                txtpart_name.BackColor = System.Drawing.Color.White;    // If it's not empty, set the background color to Salmon
                nameValid = true;                                       // Marking the field as valid
            }
            SaveButton.Enabled = allowSave();                           // Check if we can save
        }

        private void txtpart_inventory_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Int32.Parse(txtpart_inventory.Text);                        // Try to convert the string into an Int
                lblInv_error.Hide();                                        // If it works, hide the error label
                inventoryValid = true;
                SaveButton.Enabled = allowSave();                               // Check if we can save

            }
            catch (FormatException)
            {
                lblInv_error.Show();                                        // If it doesn't work, show the error label
                inventoryValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtpart_inventory.Text))          // If the textbox is empty...
            {
                txtpart_inventory.BackColor = System.Drawing.Color.Salmon;  // Set the background color to Salmon
            }
            else
            {
                txtpart_inventory.BackColor = System.Drawing.Color.White;   // If it's not empty, set it to White
            }
            
        }

        private void txtpart_price_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Decimal.Parse(txtpart_price.Text);                      // Try to convert the string into an Int
                lblPrice_error.Hide();                                  // If it works, hide the error label
                priceValid = true;

            }
            catch (FormatException)
            {
                lblPrice_error.Show();                                  // If it doesn't work, show the error label
                priceValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtpart_price.Text))          // If the textbox is empty...
            {
                txtpart_price.BackColor = System.Drawing.Color.Salmon;  // Set the background color to Salmon
                priceValid = false;
            }
            else
            {
                txtpart_price.BackColor = System.Drawing.Color.White;   // If it's not empty, set it to White
                priceValid = true;
            }
            SaveButton.Enabled = allowSave();                           // Check if we can save
        }

        private void txtpart_min_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Int32.Parse(txtpart_min.Text);                      // Try to convert the string into an Int
                lblMinMax_error.Hide();                                  // If it works, hide the error label
                minValid = true;
                SaveButton.Enabled = allowSave();                           // Check if we can save
            }
            catch (FormatException)
            {
                lblMinMax_error.Show();                                  // If it doesn't work, show the error label
                minValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtpart_min.Text))          // If the textbox is empty...
            {
                txtpart_min.BackColor = System.Drawing.Color.Salmon;  // Set the background color to Salmon
            }
            else
            {
                txtpart_min.BackColor = System.Drawing.Color.White;   // If it's not empty, set it to White
            }
            
        }

        private void txtpart_max_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Int32.Parse(txtpart_max.Text);                          // Try to convert the string into an Int
                lblMinMax_error.Hide();                                 // If it works, hide the error label
                maxValid = true;
                SaveButton.Enabled = allowSave();                           // Check if we can save
            }
            catch (FormatException)
            {
                lblMinMax_error.Show();                                 // If it doesn't work, show the error label
                maxValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtpart_max.Text))            // If the textbox is empty...
            {
                txtpart_max.BackColor = System.Drawing.Color.Salmon;    // Set the background color to Salmon
            }
            else
            {
                txtpart_max.BackColor = System.Drawing.Color.White;     // If it's not empty, set it to White
            }
            
        }

        private void txtpart_mach_comp_TextChanged(object sender, EventArgs e)
        {
            if (radio_inhouse.Checked == true)                                  // If this is an in-house item...
            {
                try
                {
                    Int32.Parse(txtpart_mach_comp.Text);                        // Try to convert the string into an Int
                    lblMachineID_error.Hide();                                  // If it works, hide the error label
                    machOrCompValid = true;

                }
                catch (FormatException)
                {
                    lblMachineID_error.Show();                                  // If it doesn't work, show the error label
                    machOrCompValid = false;
                }

                if (string.IsNullOrWhiteSpace(txtpart_mach_comp.Text))          // If the textbox is empty...
                {
                    txtpart_mach_comp.BackColor = System.Drawing.Color.Salmon;  // Set the background color to Salmon
                }
                else
                {
                    txtpart_mach_comp.BackColor = System.Drawing.Color.White;   // If it's not empty, set it to White
                }
                SaveButton.Enabled = allowSave();                               // Check if we can save
            }
            else
            {

                if (string.IsNullOrWhiteSpace(txtpart_mach_comp.Text))          // If the textbox is empty...
                {
                    txtpart_mach_comp.BackColor = System.Drawing.Color.Salmon;  // Set the background color to Salmon
                    lblMachineID_error.Text = outsourceInputError;              // Prompt the user to enter a Company
                    lblMachineID_error.Show();                                  // Show the error to the user
                    machOrCompValid = false;
                }
                else
                {
                    txtpart_mach_comp.BackColor = System.Drawing.Color.White;   // If it's not empty, set it to White
                    lblMachineID_error.Hide();                                  // Hide the error label
                    machOrCompValid = true;
                }
                SaveButton.Enabled = allowSave();
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (radio_inhouse.Checked)                              // If the Inhouse radio button is checked...
            {
                Inhouse part = new Inhouse
                {                                                   // Create a new Inhouse part object with the
                    PartId = Int32.Parse(txtpart_id.Text),          // parameters as defined by the user
                    Name = txtpart_name.Text,                       
                    Price = Decimal.Parse(txtpart_price.Text),
                    InStock = Int32.Parse(txtpart_inventory.Text),
                    Min = Int32.Parse(txtpart_min.Text),
                    Max = Int32.Parse(txtpart_max.Text),
                    MachineID = Int32.Parse(txtpart_mach_comp.Text)
                };

                Inventory I = new Inventory();                      // Create an inventory object to access the methods
                I.updatePart(part.PartId, part);                    // Add the part
            }
            else
            {
                Outsourced part = new Outsourced                    // If the Inhouse radio button is not checked...
                {
                    Name = txtpart_name.Text,                       // Create a new Oursourced part object with the
                    PartId = Int32.Parse(txtpart_id.Text),          // parameters as defined by the user
                    Price = Decimal.Parse(txtpart_price.Text),      
                    InStock = Int32.Parse(txtpart_inventory.Text),
                    Min = Int32.Parse(txtpart_min.Text),
                    Max = Int32.Parse(txtpart_max.Text),
                    CompanyName = txtpart_mach_comp.Text
                };
                Inventory I = new Inventory();                      // Create an inventory object to access the methods
                I.updatePart(part.PartId, part);                    // Add the part
            }
            MessageBox.Show("Part Updated Successfully");           // Show a message letting the user know the part was created
            this.Close();
        }
    }
}
