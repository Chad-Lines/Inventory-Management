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

        static Inventory()
        {
            // Adding initial product data
            Products.Add(new Product { ProductId = 1, Name = "Semi-Hollow Body Electric", Price = 579.99m, InStock = 5, Min = 1, Max = 10 });
            Products.Add(new Product { ProductId = 2, Name = "Sold Body Electric", Price = 299.99m, InStock = 3, Min = 1, Max = 10 });
            Products.Add(new Product { ProductId = 3, Name = "Dreadnought Acoustic", Price = 349.99m, InStock = 8, Min = 1, Max = 10 });
            Products.Add(new Product { ProductId = 4, Name = "Classical Acoustic", Price = 399.99m, InStock = 5, Min = 1, Max = 10 });
            Products.Add(new Product { ProductId = 5, Name = "Rancher Acoustic-Electric", Price = 389.99m, InStock = 1, Min = 1, Max = 10 });
            Products.Add(new Product { ProductId = 6, Name = "Series DC-X4S Acoustic", Price = 849.99m, InStock = 4, Min = 1, Max = 10 });

            // Adding initial outsourced part data
            AllParts.Add(new Outsourced { PartId = 1, Name = "6-String Pack", Price = 5.99m, InStock = 5, Min = 1, Max = 10, IsInHouse = false, CompanyName = "Acme" }); ;
            AllParts.Add(new Outsourced { PartId = 2, Name = "12-String Pack", Price = 8.99m, InStock = 5, Min = 1, Max = 10, IsInHouse = false, CompanyName = "Acme" });
            AllParts.Add(new Outsourced { PartId = 3, Name = "Bridge", Price = 4.99m, InStock = 5, Min = 1, Max = 10, IsInHouse = false, CompanyName = "Acme" });
            AllParts.Add(new Outsourced { PartId = 4, Name = "Single-Line Pickups", Price = 69.99m, InStock = 5, Min = 1, Max = 10, IsInHouse = false, CompanyName = "Acme" });
            AllParts.Add(new Outsourced { PartId = 5, Name = "Knob/Switch Pack", Price = 44.99m, InStock = 5, Min = 1, Max = 10, IsInHouse = false, CompanyName = "Acme" });

            // Adding initial in house part data
            AllParts.Add(new Inhouse { PartId =  6, Name = "Bridge", Price = 3.99m, InStock = 5, Min = 1, Max = 10, IsInHouse = true, MachineID = 1 });
            AllParts.Add(new Inhouse { PartId =  7, Name = "Fret Pack", Price = 19.99m, InStock = 5, Min = 1, Max = 10, IsInHouse = true, MachineID = 2 });
            AllParts.Add(new Inhouse { PartId =  8, Name = "Pegs", Price = 4.99m, InStock = 5, Min = 1, Max = 10, IsInHouse = true, MachineID = 3 });
            AllParts.Add(new Inhouse { PartId =  9, Name = "Tuning Pegs", Price = 29.99m, InStock = 5, Min = 1, Max = 10, IsInHouse = true, MachineID = 2 });
            AllParts.Add(new Inhouse { PartId = 10, Name = "Pick Guard", Price = 12.99m, InStock = 5, Min = 1, Max = 10, IsInHouse = true, MachineID = 1 });
        }
               
        // METHODS --------------------------------
        public void addProduct(Product product) // DONE
        {
            Products.Add(product);  // Add the product to the list
        }

        public bool removeProduct(int id) // DONE
        {
            try
            {
                for (int i = 0; i < Products.Count; i++)    // Iterate through the list of products
                {
                    if (Products[i].ProductId == id)        // If a product has an ID that matches that provided, then...
                    {
                        Products.RemoveAt(i);               // Remove that product, and..
                        break;                              // Stop the loop
                    }                    
                }
            }
            catch 
            {
                Console.WriteLine("Product ID: " + id + " not found");  // If there is an issue, then log the error, and...
                return false;                                           // return false
            }           
            
            return true;
        }

        public Product lookupProduct(int id) // DONE
        {
            Product P = new Product();                  // Create a new Product object to hold the found product
            bool found = false;                         // Determine whether the product is found or not
            for (int i = 0; i < Products.Count; i++)    // Iterate through the list of products
            {
                if (Products[i].ProductId == id)        // If a product has an ID that matches that provided, then...
                {
                    P = Products[i];                    // Return the product, and...
                    found = true;                       // Set found to true
                }
            }
            if (found) { return P; }                    // If found, return the product...
            else { return null; }                       // If not found, return null
        }

        public void updateProduct(int id, Product product) // DONE
        {
            removeProduct(id);
            addProduct(product);
        }

        public void addPart(Part part) // DONE
        {
            AllParts.Add(part);
        }

        public bool deletePart(Part part) // DONE
        {
            try
            {
                AllParts.Remove(part);                              // Remove the specified part from the list
            }
            catch 
            {
                Console.WriteLine("Part: " + part + " not found");  // If there is an issue, then log the error, and...
                return false;                                       // Return false
            }
            return true;
        }

        public Part lookupPart(int id) // DONE
        {
            Part inHousePart = new Inhouse();
            Part outsourcePart = new Outsourced();
            bool found = false;

            foreach(Part part in AllParts)
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

        public void updatePate(int id, Part part) // DONE
        {
            deletePart(part);
            addPart(part);  
        }
    }
}
