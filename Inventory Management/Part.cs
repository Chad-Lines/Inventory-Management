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
        public static int CurrentIndex { get; set; }

        public int PartId { get; set; }     // The part's unique ID
        public string Name { get; set; }    // The part's name
        public decimal Price { get; set; }  // The part's price
        public int InStock { get; set; }    // The number of this part in stock
        public int Min { get; set; }        // The minimum
        public int Max { get; set; }        // The maximum
        public bool IsInHouse { get; set; } // Determines whether the item is InHouse or Outsourced
    }
}
