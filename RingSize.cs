using System;
using System.Collections.Generic;
using System.Text;

namespace JewelleryProgramV2
{
    class RingSize
    {
        // Instance Variables
        private string LetterSize;
        private double NumberSize;
        private double Diameter;

        // Constructor
        public RingSize(string letterSize, double numberSize, double diameter)
        {
            this.LetterSize = letterSize;
            this.NumberSize = numberSize;
            this.Diameter = diameter;
        }

        // Methods
        public string GetLetter()
        {
            return this.LetterSize;
        }

        public double GetNumber()
        {
            return this.NumberSize;
        }
        public double GetDiameter()
        {
            return this.Diameter;
        }

        public void SetLetter(string letterSize)
        {
            this.LetterSize = letterSize;
        }

        public void SetNumber(double numberSize)
        {
            this.NumberSize = numberSize;
        }

        public void SetDiameter(double diameter)
        {
            this.Diameter = diameter;
        }
    }
}