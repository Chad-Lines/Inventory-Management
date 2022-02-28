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
        public static int currentPartIndex;     // Used to hold the index of the part selected
        public static Part currentPart;         // Used to hold the part being selected
        public static int currentProductIndex;  // Used to hold the index of the product selected
        public static Part currentProduct;      // Used to hold the product being selected

        public Form1()
        {
            InitializeComponent();

            // Setting up the Product Datagrid
            // -------------------------------
            dgvProducts.DataSource = Inventory.Products;                                                // Adding the product list as the data source
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;                        // Full row sleect (rather than single cells)
            dgvProducts.ReadOnly = true;                                                                // Setting the data to "read only"
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize; // Auto-sizing the column headers
            dgvProducts.MultiSelect = false;                                                            // Disabling multi-select
            dgvProducts.AllowUserToAddRows = false;                                                     // Disallow adding new rows

            // Setting up the Part Datagrid
            // -------------------------------
            dgvParts.DataSource = Inventory.AllParts;
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

        private void button5_Click(object sender, EventArgs e)  // OPEN ADD PART
        {
            AddPart addPart = new AddPart();    // Instantiate the Add Part screen
            addPart.Show();                     // Shows the Add Part Screen
        }

        private void button4_Click(object sender, EventArgs e) // OPEN MODIFY PART
        {   
            if(dgvParts.CurrentRow.DataBoundItem.GetType() == typeof(Inhouse))      // If the current item is an 'Inhouse' part, then...
            {
                Inhouse part = (Inhouse)dgvParts.CurrentRow.DataBoundItem;          // Create an Inhouse part to represent that part, and...
                ModifyPart modifyPart = new ModifyPart(part);                       // Instantiate the Modify Part screen
                modifyPart.Show();                                                  // Shows the Modify Part Screen
            }
            else if (dgvParts.CurrentRow.DataBoundItem.GetType() == typeof(Outsourced))
            {
                Outsourced part = (Outsourced)dgvParts.CurrentRow.DataBoundItem;    // Create an Inhouse part to represent that part, and...
                ModifyPart modifyPart = new ModifyPart(part);                       // Instantiate the Modify Part screen
                modifyPart.Show();                                                  // Shows the Modify Part Screen
            }
            else
            {                                                                       // If no part has been selected...
                MessageBox.Show("No Part Selected");                                // Let the user know of the error
            }
        }

        private void button3_Click(object sender, EventArgs e) // DELETE PART
        {
            if (dgvParts.CurrentRow == null || !dgvParts.CurrentRow.Selected)   // If there are no rows, or if there are none selected
            {
                MessageBox.Show("Nothing is Selected");                         // Show the user an error message
                return;
            }

            Inventory I = new Inventory();                                      // Instantiating Inventory to access it's method
            Part P = dgvParts.CurrentRow.DataBoundItem as Part;                 // This is the actual object that is selected
            int Index = dgvParts.CurrentCell.RowIndex;                          // You can then use that object to reference
            I.deletePart(P);                                                    // Delete the item from the list
        }

        private void button1_Click(object sender, EventArgs e) // SEARCH PARTS
        {
            dgvParts.ClearSelection();                              // This makes sure there is nothing highlighted as default
            dgvParts.MultiSelect = true;                            // Allowing Multi-select

            bool found = false;                                     // Setting the default value for the found variable

            if (txtPartSearch.Text != "")                           // If the txtProductSearch box isn't empty...
            {
                for (int i = 0; i < Inventory.AllParts.Count; i++)  // Iterate through the product list...
                {
                    if (Inventory.AllParts[i].Name.ToUpper()        // Convert the search string AND the list item to Upper...
                        .Contains(txtPartSearch.Text.ToUpper()))    // And see if the search string is IN the list. If so...          
                    {
                        dgvParts.Rows[i].Selected = true;           // Flag the matching row as Selected, and 
                        found = true;                               // Set found to true
                    }
                }
            }
            if (!found) { MessageBox.Show("No Matches Found."); }   // If there are no matches, inform the user
        }

        private void button8_Click(object sender, EventArgs e) // OPEN ADD PRODUCT
        {
            AddProduct addProduct = new AddProduct();   // Instantiate the Add Product screen
            addProduct.Show();                          // Shows the Add Product Screen
        }

        private void button7_Click(object sender, EventArgs e) // OPEN MODIFY PRODUCT
        {
            ModifyProduct modifyProduct = new ModifyProduct();  // Instantiate the Modify Product screen
            modifyProduct.Show();                               // Shows the Modify Product Screen

        }

        private void button6_Click(object sender, EventArgs e) // DELETE PRODUCT
        {            
            if (dgvProducts.CurrentRow == null || !dgvProducts.CurrentRow.Selected) // If there are no rows, or if there are none selected
            {
                MessageBox.Show("Nothing is Selected");                             // Show the user an error message
                return;
            }

            Inventory I = new Inventory();                                  // Instantiating Inventory to access it's method
            Product P = dgvProducts.CurrentRow.DataBoundItem as Product;    // This is the actual object that is selected
            int Index = dgvProducts.CurrentCell.RowIndex;                   // You can then use that object to reference            
            I.removeProduct(P.ProductId);                                   // Delete the item from the list
        }

        private void button2_Click(object sender, EventArgs e) // SEARCH PRODUCTS
        {
            // Search for Products     
            dgvProducts.ClearSelection();                                           // This makes sure there is nothing highlighted as default
            dgvProducts.MultiSelect = true;                                         // Allowing Multi-select

            bool found = false;                                                     // Setting the default value for the found variable

            if (txtProductSearch.Text != "")                                        // If the txtProductSearch box isn't empty...
            {
                for (int i = 0; i < Inventory.Products.Count; i++)                    // Iterate through the product list...
                {                    
                    if (Inventory.Products[i].Name.ToUpper()                          // Convert the search string AND the list item to Upper...
                        .Contains(txtProductSearch.Text.ToUpper()))                 // And see if the search string is IN the list. If so...          
                    {
                        dgvProducts.Rows[i].Selected = true;                        // Flag the matching row as Selected, and 
                        found = true;                                               // Set found to true
                    }
                }
            }
            if (!found) { MessageBox.Show("No Matches Found."); }                   // If there are no matches, inform the user

        }

        private void button9_Click(object sender, EventArgs e) // EXIT THE APPLICATION
        {
            this.Close();
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e) // CAPTURE PRODUCT SELECTION
        {
            try{
                currentPartIndex = e.RowIndex;                      // Capturing the row index
                currentPart = Inventory.AllParts[currentPartIndex]; // Using the index to get the selected product (for
                                                                    // use in ModifyProduct)
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void dgvParts_CellClick(object sender, DataGridViewCellEventArgs e) // CAPTURE PART SELECTION
        {
            try
            {
                currentPartIndex = e.RowIndex;                      // Capturing the row index
                currentPart = Inventory.AllParts[currentPartIndex]; // Using the index to get the selected part (for use in ModifyPart)
            }
            catch(Exception ex)
            {
                return;
            }
            
        }   

        private void dgvParts_CellContentClick(object sender, DataGridViewCellEventArgs e) // NOT USED
        {

        }
        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e) // NOT USED
        {


        }

        
    }
}