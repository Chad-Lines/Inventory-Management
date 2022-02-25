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

        public static BindingList<Part> parts = new BindingList<Part>();            // The parts that make up the product. This is created
                                                                                    // as a BindingList of Parts
        public static BindingList<Product> products = new BindingList<Product>();   // This is a binding list of the Products

        public int ProductId { get; set; }  // The unique ID of the product
        public string Name { get; set; }    // The name of the product
        public decimal Price { get; set; }  // The product's price
        public int InStock { get; set; }    // The number of products in stock
        public int Min { get; set; }        // The minimum 
        public int Max { get; set; }        // The maximum

        // DUMMY DATA --------------------------------
        static Product()
        {
            products.Add(new Product { ProductId = 1, Name = "Semi-Hollow Body Electric", Price = 579.99m, InStock = 5, Min = 1, Max = 10 });
            products.Add(new Product { ProductId = 2, Name = "Sold Body Electric", Price = 299.99m, InStock = 3, Min = 1, Max = 10 });
            products.Add(new Product { ProductId = 3, Name = "Dreadnought Acoustic", Price = 349.99m, InStock = 8, Min = 1, Max = 10 });
            products.Add(new Product { ProductId = 4, Name = "Classical Acoustic", Price = 399.99m, InStock = 5, Min = 1, Max = 10 });
            products.Add(new Product { ProductId = 5, Name = "Rancher Acoustic-Electric", Price = 389.99m, InStock = 1, Min = 1, Max = 10 });
            products.Add(new Product { ProductId = 6, Name = "Series DC-X4S Acoustic", Price = 849.99m, InStock = 4, Min = 1, Max = 10 });
        }

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
