using System;
using System.Collections.Generic;
using System.Text;

namespace JewelleryProgramV2
{
    class History
    {
        // Instance Variables
        private string Identifier;
        private double Output;

        // Constructor
        public History(string identifier, double output)
        {
            this.Identifier = identifier;
            this.Output = output;
        }

        // Methods
        public string GetIdentifier()
        {
            return this.Identifier;
        }

        public double GetOutput()
        {
            return this.Output;
        }
    }
}
