using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;    // Required for using BindingList

namespace Inventory_Management
{
    internal class Inventory
    {
        // PROPERTIES --------------------------------

        public static BindingList<Product> Products = new BindingList<Product>();   // All Products
        public static BindingList<Part> AllParts = new BindingList<Part>();         // All Parts

        // METHODS --------------------------------
        public void addProduct(int id)
        {
            return;
        }

        public bool removeProduct(int id)
        {
            return false;
        }

        public Product lookupProduct(int id)
        {
            return null;
        }

        public void updateProduct(int id, Product product)
        {
            Product productToUpdate = product;        
        }

        public void addPart(Part part)
        {
            return ;
        }

        public bool deletePart(Part part)
        {
            return true;
        }

        public Part lookupPart(int id)
        {
            return null;
        }

        public void updatePate(int id, Part part)
        {
            Part partToUpdate = part;
        }
    }
}
