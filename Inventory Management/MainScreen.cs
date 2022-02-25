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

        }

        private void partsBinding(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvParts.ClearSelection();  // Clears the automatic selection of the first row
        }
    }
}
