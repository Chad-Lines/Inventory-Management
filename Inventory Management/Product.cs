using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;    // Required for using BindingList

namespace Inventory_Management
{
    public class Product
    {
        // PROPERTIES --------------------------------

        public static BindingList<Part> parts = new BindingList<Part>();    // the parts that make up the product. This is created
                                                                            // as a BindingList of Parts
        public int ProductId { get; set; }  // The unique ID of the product
        public string Name { get; set; }    // The name of the product
        public decimal Price { get; set; }  // The product's price
        public int InStock { get; set; }    // The number of products in stock
        public int Min { get; set; }        // The minimum 
        public int Max { get; set; }        // The maximum

        // METHODS --------------------------------
        public override string ToString()
        {
            // Overriding the default display to show useful information about a given Product
            return "[ " + Name + " ] " + "Price: " + Price + ", Stock: " + InStock; 
        }

        public void addAssociatedPart(Part part)
        {
            return; 
        }
        
        public bool removeAssociatedPart(int id)
        {
            return false;
        }

        public Part lookupAssociatedPart(int id)
        {
            return null;
        }
    }
}
