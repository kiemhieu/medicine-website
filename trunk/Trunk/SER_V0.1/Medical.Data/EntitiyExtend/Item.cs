using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Medical.Data.EntitiyExtend
{
    public class Item
    {
        public Item()
        {
            
        }

        public Item(int value, String name)
        {
            this.Value = value;
            this.Name = name;
        }
        public int Value { get; set; }
        public String Name { get; set; }
    }
}
