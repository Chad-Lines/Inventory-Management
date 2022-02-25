using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;    // Required for using BindingList

namespace Inventory_Management
{
    public abstract class Part
    {
        // PROPERTIES --------------------------------
        public static BindingList<Part> parts = new BindingList<Part>();

        public int PartId { get; set; }     // The part's unique ID
        public string Name { get; set; }    // The part's name
        public decimal Price { get; set; }  // The part's price
        public int InStock { get; set; }    // The number of this part in stock
        public int Min { get; set; }        // The minimum
        public int Max { get; set; }        // The maximum

        static Part()
        {
            parts.Add(new Outsourced { PartId = 1, Name = "6-String Pack", Price = 5.99m, InStock = 5, Min = 1, Max = 10 });
            parts.Add(new Outsourced { PartId = 2, Name = "12-String Pack", Price = 8.99m, InStock = 5, Min = 1, Max = 10 });
            parts.Add(new Outsourced { PartId = 3, Name = "Bridge", Price = 4.99m, InStock = 5, Min = 1, Max = 10 });
            parts.Add(new Outsourced { PartId = 4, Name = "Single-Line Pickups", Price = 69.99m, InStock = 5, Min = 1, Max = 10 });
            parts.Add(new Outsourced { PartId = 5, Name = "Knob/Switch Pack", Price = 44.99m, InStock = 5, Min = 1, Max = 10 });
            parts.Add(new Inhouse { PartId = 6, Name = "Bridge", Price = 3.99m, InStock = 5, Min = 1, Max = 10 });
            parts.Add(new Inhouse { PartId = 7, Name = "Fret Pack", Price = 19.99m, InStock = 5, Min = 1, Max = 10 });
            parts.Add(new Inhouse { PartId = 8, Name = "Pegs", Price = 4.99m, InStock = 5, Min = 1, Max = 10 });
            parts.Add(new Inhouse { PartId = 9, Name = "Tuning Pegs", Price = 29.99m, InStock = 5, Min = 1, Max = 10 });
            parts.Add(new Inhouse { PartId = 10, Name = "Pick Guard", Price = 12.99m, InStock = 5, Min = 1, Max = 10 });
        }

    }
}
