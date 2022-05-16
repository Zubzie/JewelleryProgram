using System;
using System.Collections.Generic;
using System.Text;

namespace JewelleryProgramV2
{
    class Metal
    {
        // Instance Variables
        private string Name { get; set; }
        private double SpecificGravity { get; set; }

        // Constructor
        public Metal(string name, double specificGravity)
        {
            this.Name = name;
            this.SpecificGravity = specificGravity;
        }

        // Methods
        public string GetName()
        {
            return this.Name;
        }

        public double GetSG()
        {
            return this.SpecificGravity;
        }
    }
}
