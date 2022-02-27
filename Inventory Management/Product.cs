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

        public static BindingList<Part> AssociatedParts = new BindingList<Part>();  // The parts that make up the product. This is created
                                                                                    // as a BindingList of Parts
        public static int CurrentIndex { get; set; }
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
            AssociatedParts.Add(part);  // Add the new part
        }
        
        public bool removeAssociatedPart(int id)
        {
            bool found = false;                     // Used to determine if the part is found

            foreach (Part part in AssociatedParts)  // Iterate through the list of AssociatedParts
            {
                if (part.PartId == id)              // If the part ID is equal to the ID selected, then...
                {
                    AssociatedParts.Remove(part);   // Remove that part
                    found = true;                   // Set the found variable to true
                }
            }   
            return found;                           // Return the found variable
        }

        public Part lookupAssociatedPart(int id)
        {
            Part inHousePart = new Inhouse();
            Part outsourcePart = new Outsourced();
            bool found = false;

            foreach (Part part in AssociatedParts)
            {
                if (part.PartId == id)
                {
                    found = true;
                    if (part is Inhouse)
                    {
                        inHousePart = part;
                    }
                    else
                    {
                        outsourcePart = part;
                    }
                }
            }
            if (found)
            {
                if (inHousePart != null)
                {
                    return inHousePart;
                }
                else
                {
                    return outsourcePart;
                }
            }
            else
            {
                return null;
            }

        }
    }
}
