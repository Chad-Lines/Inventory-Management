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
    public partial class AddProduct : Form
    {       
        // Variables for adding and deleting parts 
        public static int currentAllPartIndex;
        public static Part currentAllPart;

        public static int currentProdPartIndex;
        public static Part currentProdPart;

        // Validation Variables
        public bool nameValid = false;
        public bool inventoryValid = false;
        public bool priceValid = false;
        public bool minValid = false;
        public bool maxValid = false;
        public bool machOrCompValid = false;

        public AddProduct()
        {
            InitializeComponent();           

            // Populating the 'All Candidate Parts' Data Grid View
            dgvAllParts.DataSource = Inventory.AllParts;                                                    // Adding the AssociatedParts list
            dgvAllParts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;                            // Full row sleect (rather than single cells)
            dgvAllParts.ReadOnly = true;                                                                    // Setting the data to "read only"
            dgvAllParts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;     // Auto-sizing the column headers
            dgvAllParts.MultiSelect = false;                                                                // Disabling multi-select
            dgvAllParts.AllowUserToAddRows = false;                                                         // Disallow adding new rows    

            // Populating the 'Parts Associated with this Product' Data Grid View
            dgvParts.DataSource = Product.AssociatedParts;                                                  // Adding the AssociatedParts list
            dgvParts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;                               // Full row sleect (rather than single cells)
            dgvParts.ReadOnly = true;                                                                       // Setting the data to "read only"
            dgvParts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;        // Auto-sizing the column headers
            dgvParts.MultiSelect = false;                                                                   // Disabling multi-select
            dgvParts.AllowUserToAddRows = false;                                                            // Disallow adding new rows     

            resetForm();
        }
        public string GetNextID() // DONE
        {
            // The purpose of this method is to generate the next ID automatically by
            // comparing the existing IDs                                   
            int nextID = 0;                                     // Initialize nextID as 0
            foreach(Product product in Inventory.Products)      // Iterate through the e
            {
                if (product.ProductId >= nextID)                // If the ProductID is greater or equal than the nextID, then...             
                {
                    nextID = product.ProductId + 1;             // set the nextID to PartID + 1
                }
            }
            return nextID.ToString();                           // Finally we return the nextID as a string
        }

        private bool allowSave() // DONE
        {
            // This method checks whether all the inputs have been marked as valid.
            // If they have, then we return 'true' which enables the Save button.
            return nameValid && inventoryValid && priceValid &&
                minValid && maxValid;

        }

        private void button5_Click(object sender, EventArgs e) // CANCEL BUTTON (DONE)
        {
            this.Close();
        } 

        private void button2_Click(object sender, EventArgs e) // ADD BUTTON (DONE)
        {
            // Add the "Current Part" (selected from dgvAllParts)
            // to the AssociatedParts list, which will cause it to show up in dgvParts

            bool isDuplicate = false;                                               // Determine whether an addition is a duplicate

            if (currentAllPart != null)                                             // If the currentAllPart isn't null, then...
            { 
                for (int i = 0; i < dgvParts.Rows.Count; i++)                       // Iterate through the existing dgvParts rows
                {
                    if (currentAllPart.PartId.ToString() ==                         // Check the name of the part to be inserted against names
                        dgvParts.Rows[i].Cells[0].Value.ToString())                 // of already existing parts. If there's a match, then...
                    {
                        isDuplicate = true;                                         // Set the duplicate variable as true, and...
                        MessageBox.Show(dgvParts.Rows[i].Cells[1].Value +           // Show a message box to alert the user
                            " has already been added");
                        break;                                                      // Stop searching
                    }                    
                }
                if (!isDuplicate) { Product.AssociatedParts.Add(currentAllPart); }  // If it's not a duplicate, add the new part to the list
            }
            else { MessageBox.Show("No Part Selected."); }                          // If the currentPart is null, alert the user
        }

        private void resetForm() // DONE
        {
            // Reset all the text Fields
            txtName.Clear();
            txtPrice.Clear();
            txtInventory.Clear();
            txtMin.Clear();
            txtMax.Clear();

            // Setting the initial state of the various form elements
            txtProductID.Text = GetNextID();    // Populate the Part ID text box
            txtProductID.ReadOnly = true;       // Setting the ProductID field to read only
            SaveButton.Enabled = false;         // Disabling the save button (until all data is entered)            
            lblInv_error.Hide();                // Hiding the Inventory Error label
            lblPrice_error.Hide();              // Hiding the Pirce/Cost Error label
            lblMinMax_error.Hide();             // Hiding the Min/Max Error label

            // Since the texboxes are all empty, we initialize them with a red background indicating that they are required
            txtName.BackColor = System.Drawing.Color.Salmon;
            txtPrice.BackColor = System.Drawing.Color.Salmon;
            txtInventory.BackColor = System.Drawing.Color.Salmon;
            txtMin.BackColor = System.Drawing.Color.Salmon;
            txtMax.BackColor = System.Drawing.Color.Salmon;
        }

        private void SearchButton_Click(object sender, EventArgs e) // DONE
        {            
            bool found = false;                                                 // Variable to track whether results are found

            dgvAllParts.ClearSelection();                                       // Clear any existing selections, and...
            dgvAllParts.MultiSelect = true;                                     // Enable MultiSelect 

            if (txtPartSearch.Text != "")                                       // If the search box is not empty, then...
            {
                for (int i = 0; i < Inventory.AllParts.Count; i++)              // Iterate through all parts in the Inventory
                {
                    if (Inventory.AllParts[i].Name.ToUpper().                   // If a part name includes the search term, then...
                        Contains(txtPartSearch.Text.ToUpper()))
                    {
                        dgvAllParts.Rows[i].Selected = true;                    // Select the row
                        found = true;                                           // Set the found variable to true
                    }
                }
            }

            if (txtPartSearch.Text != "" && dgvParts.Rows.Count > 0)            // If there are rows in dgvParts...
            {
                dgvParts.ClearSelection();                                      // Clear any existing selections, and...
                dgvParts.MultiSelect = true;                                    // Enable MultiSelect

                for (int i = 0; i < dgvParts.Rows.Count; i++)                   // Iterate through the dgvParts rows
                {
                    string name = (string)dgvParts.Rows[i].Cells[i].Value;      // Get the string value of the 1st cell (Name column)
                    if (name.ToUpper().Contains(txtPartSearch.Text.ToUpper()))  // If the search term is in the name, then...
                    {
                        dgvParts.Rows[i].Selected = true;                       // Select the row
                        found = true;                                           // Set the found variable to true
                    }
                }
            }

            if (!found) { MessageBox.Show("No Matches Found."); }               // If there are no matches, inform the user
        }

        private void dgvAllParts_CellClick(object sender, DataGridViewCellEventArgs e) // DONE
        {
            try
            {
                currentAllPartIndex = e.RowIndex;                           // Capturing the row index
                currentAllPart = Inventory.AllParts[currentAllPartIndex];   // Using the index to get the selected part (for use in ModifyPart)
            }
            catch (Exception ex)
            {
                return;
            }
            
        }

        private void DeleteButton_Click(object sender, EventArgs e) // DONE
        {
            // Remove the "Current Part" (selected from dgvParts) from the AssociatedParts list
            if (currentProdPart != null) { Product.AssociatedParts.Remove(currentProdPart); }
            else { MessageBox.Show("No Part Selected."); }
        }

        private void dgvParts_CellClick(object sender, DataGridViewCellEventArgs e) // DONE
        {
            try
            {
                currentProdPartIndex = e.RowIndex;                                  // Capturing the row index
                currentProdPart = Product.AssociatedParts[currentProdPartIndex];    // Capture the part from Product.AssociatedParts
            }
            catch (Exception ex)
            {
                return;
            }
            
                        
        }

        private void txtName_TextChanged(object sender, EventArgs e) // DONE
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))            // If the textbox is empty, then...
            {   
                txtName.BackColor = System.Drawing.Color.Salmon;    // Set the background color to Salmon, and...
                nameValid = false;                                  // Mark the field as invalid
            }
            else
            {                                                       // If the textbox is not empty, then...
                txtName.BackColor = System.Drawing.Color.White;     // Set the background color to White, and...
                nameValid = true;                                   // Mark  the field as valid
            }
            SaveButton.Enabled = allowSave();                       // Check if we can save
        }

        private void txtInventory_TextChanged(object sender, EventArgs e) // DONE
        {
            try
            {
                Int32.Parse(txtInventory.Text);                         // Try to convert the string into an int (validate)
                lblInv_error.Hide();                                    // If it works, hide the error label, and...
                inventoryValid = true;                                  // Mark the field as valid
            }
            catch (FormatException)
            {
                lblInv_error.Show();                                    // If it doesn't work, show the error label
                inventoryValid = false;                                 // And mark the field as invalid
            }

            if (string.IsNullOrWhiteSpace(txtInventory.Text))           // If the textbox is empty...
            {
                txtInventory.BackColor = System.Drawing.Color.Salmon;   // Set the background color to Salmon
                inventoryValid = false;                                     // And mark the field as invalid
            }
            else
            {
                txtInventory.BackColor = System.Drawing.Color.White;    // If it's not empty, set it to White
                inventoryValid = true;                                      // And mark the field as valid
            }
            SaveButton.Enabled = allowSave();                           // Check if we can save
        }

        private void txtPrice_TextChanged(object sender, EventArgs e) // DONE
        {
            try
            {
                Decimal.Parse(txtPrice.Text);                       // Try to convert the string into a Decimal (validate)
                lblPrice_error.Hide();                              // If it works, hide the error label, and...
                priceValid = true;                                  // Mark the field as valid
            }
            catch (FormatException)
            {
                lblPrice_error.Show();                              // If it doesn't work, show the error label
                priceValid = false;                                 // And mark the field as invalid
            }

            if (string.IsNullOrWhiteSpace(txtPrice.Text))           // If the textbox is empty...
            {
                txtPrice.BackColor = System.Drawing.Color.Salmon;   // Set the background color to Salmon
                priceValid = false;                                 // And mark the field as invalid
            }
            else
            {
                txtPrice.BackColor= System.Drawing.Color.White;     // If it's not empty, set it to White
                priceValid = true;                                  // And mark the field as valid
            }
            SaveButton.Enabled = allowSave();                       // Check if we can save
        }

        private void txtMin_TextChanged(object sender, EventArgs e) // DONE
        {
            try
            {
                Int32.Parse(txtMin.Text);                         // Try to convert the string into an int (validate)
                lblMinMax_error.Hide();                           // If it works, hide the error label, and...
                minValid = true;                                  // Mark the field as valid
            }
            catch (FormatException)
            {
                lblMinMax_error.Show();                           // If it doesn't work, show the error label
                minValid = false;                                 // And mark the field as invalid
            }

            if (string.IsNullOrWhiteSpace(txtMin.Text))           // If the textbox is empty...
            {
                txtMin.BackColor = System.Drawing.Color.Salmon;   // Set the background color to Salmon
                minValid = false;                                 // And mark the field as invalid
            }
            else
            {
                txtMin.BackColor = System.Drawing.Color.White;    // If it's not empty, set it to White
                minValid = true;                                  // And mark the field as valid
            }
            SaveButton.Enabled = allowSave();                     // Check if we can save
        }

        private void txtMax_TextChanged(object sender, EventArgs e) // DONE
        {
            try
            {
                Int32.Parse(txtMax.Text);                         // Try to convert the string into an int (validate)
                lblMinMax_error.Hide();                           // If it works, hide the error label, and...
                maxValid = true;                                  // Mark the field as valid
            }
            catch (FormatException)
            {
                lblMinMax_error.Show();                           // If it doesn't work, show the error label
                maxValid = false;                                 // And mark the field as invalid
            }

            if (string.IsNullOrWhiteSpace(txtMax.Text))           // If the textbox is empty...
            {
                txtMax.BackColor = System.Drawing.Color.Salmon;   // Set the background color to Salmon
                maxValid = false;                                 // And mark the field as invalid
            }
            else
            {
                txtMax.BackColor = System.Drawing.Color.White;    // If it's not empty, set it to White
                maxValid = true;                                  // And mark the field as valid
            }
            SaveButton.Enabled = allowSave();                     // Check if we can save

        }

        private void SaveButton_Click(object sender, EventArgs e) // DONE
        {
            Product product = new Product();                        // Creating the product that we'll pass to Inventory later
            product.ProductId = Int32.Parse(txtProductID.Text);     // Adding the product ID
            product.Name = txtName.Text;                            // Adding the product Name
            product.InStock = Int32.Parse(txtInventory.Text);       // Adding the product InStock (Inventory) value
            product.Min = Int32.Parse(txtMin.Text);                 // Adding the product Min
            product.Max = Int32.Parse(txtMax.Text);                 // Adding the product Max

            Inventory I = new Inventory();                          // Instantiate an inventory object
            I.addProduct(product);                                  // Add the product to the inventory
                
            MessageBox.Show(product.Name + " added successfully."); // Let the user know it was added successfully
            this.Close();                                           // Close the Add Product window
        }
    }
}