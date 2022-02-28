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

    public partial class ModifyProduct : Form
    {
        // Variables for adding and deleting parts 
        public static int currentAllPartIndex;
        public static Part currentAllPart;

        public static int currentProdPartIndex;
        public static Part currentProdPart;

        // BindingList used to stage parts we want to add to the new product
        BindingList<Part> newParts = new BindingList<Part>();

        // Validation Variables
        public bool nameValid = false;
        public bool inventoryValid = false;
        public bool priceValid = false;
        public bool minValid = false;
        public bool maxValid = false;
        public bool machOrCompValid = false;

        public ModifyProduct(Product product)
        {
            InitializeComponent();
            populateForm(product);
        }

        private bool allowSave() // DONE
        {
            // This method checks whether all the inputs have been marked as valid.
            // If they have, then we return 'true' which enables the Save button.
            return nameValid && inventoryValid && priceValid &&
                minValid && maxValid;

        }

        private void button5_Click(object sender, EventArgs e)  // CANCEL BUTTON (DONE)
        {
            this.Close();
        }

        private void populateForm(Product product)
        {
            // Reset all the text Fields
            txtName.Clear();
            txtPrice.Clear();
            txtInventory.Clear();
            txtMin.Clear();
            txtMax.Clear();

            // Setting the initial state of the various form elements
            
            textBox2.Text = product.ProductId.ToString();   // Populate the ProductID text box
            textBox2.ReadOnly = true;                       // Populate the ProductID field to read only
            txtName.Text = product.Name;                    // Populate the product name
            txtPrice.Text = product.Price.ToString();       // Populate the product price
            txtInventory.Text = product.InStock.ToString(); // Populate the product InStock (inventory) value
            txtMin.Text = product.Min.ToString();           // Populate the product Min
            txtMax.Text = product.Max.ToString();           // Populate the product Max

            foreach (Part part in product.AssociatedParts)  // For each part associated with the product...
            {   
                newParts.Add(part);                         // We add that part to our BindingList 
            }
            
            lblInv_error.Hide();                            // Hiding the Inventory Error label
            lblPrice_error.Hide();                          // Hiding the Pirce/Cost Error label
            lblMinMax_error.Hide();                         // Hiding the Min/Max Error label

            // Populating the 'All Candidate Parts' Data Grid View
            dgvAllParts.DataSource = Inventory.AllParts;                                                    // Adding the AssociatedParts list
            dgvAllParts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;                            // Full row sleect (rather than single cells)
            dgvAllParts.ReadOnly = true;                                                                    // Setting the data to "read only"
            dgvAllParts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;     // Auto-sizing the column headers
            dgvAllParts.MultiSelect = false;                                                                // Disabling multi-select
            dgvAllParts.AllowUserToAddRows = false;                                                         // Disallow adding new rows    

            // Populating the 'Parts Associated with this Product' Data Grid View
            dgvParts.DataSource = newParts;                                                                 // Adding the AssociatedParts list
            dgvParts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;                               // Full row sleect (rather than single cells)
            dgvParts.ReadOnly = true;                                                                       // Setting the data to "read only"
            dgvParts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;        // Auto-sizing the column headers
            dgvParts.MultiSelect = false;                                                                   // Disabling multi-select
            dgvParts.AllowUserToAddRows = false;                                                            // Disallow adding new rows     

        }

        private void txtName_TextChanged(object sender, EventArgs e)
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

        private void txtInventory_TextChanged(object sender, EventArgs e)
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

        private void txtPrice_TextChanged(object sender, EventArgs e)
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
                txtPrice.BackColor = System.Drawing.Color.White;     // If it's not empty, set it to White
                priceValid = true;                                  // And mark the field as valid
            }
            SaveButton.Enabled = allowSave();                       // Check if we can save
        }

        private void txtMin_TextChanged(object sender, EventArgs e)
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

        private void txtMax_TextChanged(object sender, EventArgs e)
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

        private void SearchButton_Click(object sender, EventArgs e)
        {
            bool found = false;                                                 // Variable to track whether results are found

            dgvAllParts.ClearSelection();                                       // Clear any existing selections, and...
            dgvAllParts.MultiSelect = true;                                     // Enable MultiSelect 

            if (txtSearch.Text != "")                                           // If the search box is not empty, then...
            {
                for (int i = 0; i < Inventory.AllParts.Count; i++)              // Iterate through all parts in the Inventory
                {
                    if (Inventory.AllParts[i].Name.ToUpper().                   // If a part name includes the search term, then...
                        Contains(txtSearch.Text.ToUpper()))
                    {
                        dgvAllParts.Rows[i].Selected = true;                    // Select the row
                        found = true;                                           // Set the found variable to true
                    }
                }
            }

            if (txtSearch.Text != "" && dgvParts.Rows.Count > 0)                // If there are rows in dgvParts...
            {
                dgvParts.ClearSelection();                                      // Clear any existing selections, and...
                dgvParts.MultiSelect = true;                                    // Enable MultiSelect

                for (int i = 0; i < dgvParts.Rows.Count; i++)                   // Iterate through the dgvParts rows
                {
                    string name = (string)dgvParts.Rows[i].Cells[1].Value;      // Get the string value of the 1st cell (Name column)
                    if (name.ToUpper().Contains(txtSearch.Text.ToUpper()))      // If the search term is in the name, then...
                    {
                        dgvParts.Rows[i].Selected = true;                       // Select the row
                        found = true;                                           // Set the found variable to true
                    }
                }
            }

            if (!found) { MessageBox.Show("No Matches Found."); }               // If there are no matches, inform the user
        }

        private void button3_Click(object sender, EventArgs e) // DELETE BUTTON
        { 
            try                                                                 // Trying something different...
            {
                if (dgvParts.SelectedRows.Count > 0)                            // If there is a row selected, then...
                { 
                    Part currentPart = (Part)dgvParts.CurrentRow.DataBoundItem; // Convert the row into a part, and...
                    int id = Int32.Parse(textBox2.Text);                        // Capture the part ID, and...

                    Inventory I = new Inventory();                              // Instantiate a new inventory, and...
                    Product currentProduct = I.lookupProduct(id);               // Lookup the current product in the inventory, and...
                    currentProduct.removeAssociatedPart(currentPart.PartId);    // Remove the part from the "AssociatedParts" of the product, and...

                    foreach (DataGridViewRow row in dgvParts.SelectedRows)      // For each selected row in the Data Grid View
                    {
                        dgvParts.Rows.RemoveAt(row.Index);                      // Remove the part (i.e. we're updating the DGV)
                    }
                }
                else
                {
                    MessageBox.Show("No part selected.");                       // If no row is selected, then alert the user
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
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
                if (!isDuplicate)                                                   // If it's not a duplicate, add the new part to the list
                {
                    newParts.Add(currentAllPart);
                }
            }
            else { MessageBox.Show("No Part Selected."); }                          // If the currentPart is null, alert the user
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Product modifiedProduct = new Product();
            modifiedProduct.ProductId = Int32.Parse(textBox2.Text);         // Adding the product ID
            modifiedProduct.Name = txtName.Text;                            // Adding the product Name
            modifiedProduct.Price = Decimal.Parse(txtPrice.Text);           // Adding the product Price
            modifiedProduct.InStock = Int32.Parse(txtInventory.Text);       // Adding the product InStock (Inventory) value
            modifiedProduct.Min = Int32.Parse(txtMin.Text);                 // Adding the product Min
            modifiedProduct.Max = Int32.Parse(txtMax.Text);                 // Adding the product Max

            foreach (Part part in newParts)                                 // For each part we've staged for the product...
            {
                modifiedProduct.addAssociatedPart(part);                    // Add the part to the product 
            }

            Inventory I = new Inventory();                                  // Instantiate an inventory object
            I.updateProduct(modifiedProduct.ProductId, modifiedProduct);    // Add the product to the inventory

            MessageBox.Show(modifiedProduct.Name + " added successfully."); // Let the user know it was added successfully
            this.Close();                                                   // Close the Add Product window
        }

        private void dgvParts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvAllParts_CellClick(object sender, DataGridViewCellEventArgs e)
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
    }
}
