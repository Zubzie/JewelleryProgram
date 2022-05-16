using System;
using System.Collections.Generic;
using System.Text;

namespace JewelleryProgramV2
{
    class Metal
    {
        // Instance Variables
        private string Name;
        private double SpecificGravity;

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

        public void SetName(string name)
        {
            this.Name = name;
        }

        public void SetSG(double specificGravity)
        {
            this.SpecificGravity = specificGravity;
        }

        public double ConvertMetal(Metal oldMetal, Metal newMetal, double weight)
        {
            double result = weight * (1.0 / oldMetal.SpecificGravity);
            result *= newMetal.SpecificGravity;
            return result;            
        }
    }
}
