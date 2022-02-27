﻿using System;
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

        public static int currentPartIndex;
        public static Part currentPart;

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
            dgvAllParts.DataSource = Inventory.AllParts;                                                   // Adding the AssociatedParts list
            dgvAllParts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;                           // Full row sleect (rather than single cells)
            dgvAllParts.ReadOnly = true;                                                                   // Setting the data to "read only"
            dgvAllParts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;    // Auto-sizing the column headers
            dgvAllParts.MultiSelect = false;                                                               // Disabling multi-select
            dgvAllParts.AllowUserToAddRows = false;                                                        // Disallow adding new rows    

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
                minValid && maxValid && machOrCompValid;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        } // CANCEL BUTTON

        private void button2_Click(object sender, EventArgs e) // ADD BUTTON
        {
            // Add the "Current Part" (selected from dgvAllParts)
            // to the AssociatedParts list, which will cause it to show up in dgvParts
            Product.AssociatedParts.Add(currentPart);   
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
            currentPartIndex = e.RowIndex;                      // Capturing the row index
            currentPart = Inventory.AllParts[currentPartIndex]; // Using the index to get the selected part (for use in ModifyPart)
        }
    }
}
