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
            radio_inhouse.Checked = true;   // By default we're assuming that the part in-house            
            txtpart_id.Text = GetNextID();  // Populate the Part ID text box
            txtpart_id.ReadOnly = true;     // Disable the user from chaning the Part ID value
            SaveButton.Enabled = false;     // Disabling the save button (until all data is entered)
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
        }

        private void radio_inhouse_CheckedChanged(object sender, EventArgs e)
        {
            label8.Text = inHouseText;      // Since the part is assumed to be machined in-house, we set the text accordingly
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
    }
}
