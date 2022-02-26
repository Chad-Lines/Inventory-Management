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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Setting up the Product Datagrid
            // -------------------------------
            dgvProducts.DataSource = Product.products;                                                  // Adding the product list as the data source
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;                        // Full row sleect (rather than single cells)
            dgvProducts.ReadOnly = true;                                                                // Setting the data to "read only"
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize; // Auto-sizing the column headers
            dgvProducts.MultiSelect = false;                                                            // Disabling multi-select
            dgvProducts.AllowUserToAddRows = false;                                                     // Disallow adding new rows

            // Setting up the Part Datagrid
            // -------------------------------
            dgvParts.DataSource = Part.parts;
            dgvParts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvParts.ReadOnly = true;
            dgvParts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvParts.MultiSelect = false;
            dgvParts.AllowUserToAddRows= false;

        }

        private void partsBinding(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvParts.ClearSelection();  // Clears the automatic selection of the first row
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // This button opens the Add Part screen

            AddPart addPart = new AddPart();    // Instantiate the Add Part screen
            addPart.Show();                     // Shows the Add Part Screen
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // This button opens the Modify Part screen

            ModifyPart modifyPart = new ModifyPart();   // Instantiate the Modify Part screen
            modifyPart.Show();                          // Shows the Modify Part Screen
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Delete Part
            if (dgvParts.CurrentRow == null || !dgvParts.CurrentRow.Selected)   // If there are no rows, or if there are none selected
            {
                MessageBox.Show("Nothing is Selected");                         // Show the user an error message
                return;
            }

            Part P = dgvParts.CurrentRow.DataBoundItem as Part;                 // This is the actual object that is selected
            int Index = dgvParts.CurrentCell.RowIndex;                          // You can then use that object to reference
            Part.parts.Remove(P);                                               // Delete the item from the list
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // This button opens the Add Product screen

            AddProduct addProduct = new AddProduct();   // Instantiate the Add Product screen
            addProduct.Show();                          // Shows the Add Product Screen
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // This button opens the Modify Product screen
            ModifyProduct modifyProduct = new ModifyProduct();  // Instantiate the Modify Product screen
            modifyProduct.Show();                               // Shows the Modify Product Screen

        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Delete Product
            if (dgvProducts.CurrentRow == null || !dgvProducts.CurrentRow.Selected) // If there are no rows, or if there are none selected
            {
                MessageBox.Show("Nothing is Selected");                             // Show the user an error message
                return;
            }

            Product P = dgvProducts.CurrentRow.DataBoundItem as Product;    // This is the actual object that is selected
            int Index = dgvProducts.CurrentCell.RowIndex;                   // You can then use that object to reference
            Product.products.Remove(P);                                     // Delete the item from the list
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Search for Products     
            dgvProducts.ClearSelection();                                           // This makes sure there is nothing highlighted as default
            dgvProducts.MultiSelect = true;                                         // Allowing Multi-select

            bool found = false;                                                     // Setting the default value for the found variable

            if (txtProductSearch.Text != "")                                        // If the txtProductSearch box isn't empty...
            {
                for (int i = 0; i < Product.products.Count; i++)                    // Iterate through the product list...
                {                    
                    if (Product.products[i].Name.ToUpper()                          // Convert the search string AND the list item to Upper...
                        .Contains(txtProductSearch.Text.ToUpper()))                 // And see if the search string is IN the list. If so...          
                    {
                        dgvProducts.Rows[i].Selected = true;                        // Flag the matching row as Selected, and 
                        found = true;                                               // Set found to true
                    }
                }
            }
            if (!found) { MessageBox.Show("No Matches Found."); }                   // If there are no matches, inform the user

        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
                     
               
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Search for Parts     
            dgvParts.ClearSelection();                              // This makes sure there is nothing highlighted as default
            dgvParts.MultiSelect = true;                            // Allowing Multi-select

            bool found = false;                                     // Setting the default value for the found variable

            if (txtPartSearch.Text != "")                           // If the txtProductSearch box isn't empty...
            {
                for (int i = 0; i < Part.parts.Count; i++)          // Iterate through the product list...
                {
                    if (Part.parts[i].Name.ToUpper()                // Convert the search string AND the list item to Upper...
                        .Contains(txtPartSearch.Text.ToUpper()))    // And see if the search string is IN the list. If so...          
                    {
                        dgvParts.Rows[i].Selected = true;           // Flag the matching row as Selected, and 
                        found = true;                               // Set found to true
                    }
                }
            }
            if (!found) { MessageBox.Show("No Matches Found."); }   // If there are no matches, inform the user
        }
    }
}