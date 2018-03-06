using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Models
{
    public class Furniture
    {
        string name, dimensions, describe, number;
        double price;

        public string Name { get { return name; } set { name = value; } }
        public double Price { get { return price; } set { price = value; } }
        public string Dimensions { get { return dimensions; } set { dimensions = value; } }
        public string Describe { get { return describe; } set { describe = value; } }
        public string Number { get { return number; } set { number = value; } }
    }
}
