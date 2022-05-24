using System;
using System.Collections.Generic;
using System.Text;

namespace JewelleryProgramV2
{
    class Calculations : GeneralMethods
    {
        // Instance Variables
        private MetalList Metals;
        private RingSizeList RingSizes;
        private List<History> CalculationHistory;       

        // Constructor
        public Calculations(MetalList metals, RingSizeList ringSizes)
        {
            this.Metals = metals;
            this.RingSizes = ringSizes;
            List<History> calculationHistory = new List<History>();
            this.CalculationHistory = calculationHistory;
        }

        // Methods
        public MetalList GetMetals()
        {
            return this.Metals;
        }

        public RingSizeList GetRingSizes()
        {
            return this.RingSizes;
        }

        public void SetMetals(MetalList metals)
        {
            this.Metals = metals;
        }

        public void SetRingSizes(RingSizeList ringSizes)
        {
            this.RingSizes = ringSizes;
        }

        // Converts metal to another metal
        public double MetalConverter()
        {
            string oldMetalStr;
            string newMetalStr;
            Console.WriteLine("-- Metals --");
            this.Metals.PrintMetals();

            do
            {
                Console.WriteLine("\nWhat is the original metal?");
                oldMetalStr = Console.ReadLine().ToString();
            } while (Metals.CheckMetal(oldMetalStr.ToLower()) == false);

            do
            {
                Console.WriteLine("\nWhat is the new metal?");
                newMetalStr = Console.ReadLine().ToString();
            } while (Metals.CheckMetal(newMetalStr.ToLower()) == false);

            double weight = GetDouble("weight", "grams");

            Metal oldMetal = Metals.GetMetal(oldMetalStr.ToLower());
            Metal newMetal = Metals.GetMetal(newMetalStr.ToLower());

            weight *= 1.0 / oldMetal.GetSG();
            weight *= newMetal.GetSG();
            return weight;
        }

        // Outputs the rough weight of a ring
        public (double, double, double, double, string) RingWeight()
        {
            int index = 0;
            double metalSG = 0.0;
            double thickness = 0.0;
            double weight;
            string answer;
            string shape;

            do
            {
                Console.WriteLine("\nHave you got a round, half-round, square or rectangle ring?");
                shape = Console.ReadLine().ToLower();
                if (shape == "round") index = 1;
                if (shape == "half-round") index = 1;
                if (shape == "square") index = 1;
                if (shape == "rectangle") index = 1;
            } while (index == 0);

            Console.Clear();
            Console.WriteLine("-- Metals --");
            this.Metals.PrintMetals();

            do
            {
                Console.WriteLine("\nWhat is the metal?");
                answer = Console.ReadLine().ToLower();
            } while (this.Metals.CheckMetal(answer) == false);

            for (int i = 0; i < this.Metals.GetMetalList().Count; i++)
            {
                if (this.Metals.GetMetalList()[i].GetName().ToLower() == answer)
                {
                    metalSG = this.Metals.GetMetal(answer).GetSG();
                    break;
                }
            }
        
            double width = GetDouble("width", "milimeters");
            if (shape == "rectangle") thickness = GetDouble("thickness", "milimeters");

            Console.Clear();
            Console.WriteLine("-- Ring Sizes --");
            this.RingSizes.PrintRingSizes();

            index = 0;
            do
            {
                Console.WriteLine("\nWhat is the letter or number of the rings size?");
                answer = Console.ReadLine().ToUpper();
                if (this.RingSizes.CheckLetter(answer)) index = 1;
                if (IsDouble(answer))
                {
                    if (this.RingSizes.CheckNumber(Convert.ToDouble(answer))) index = 1;
                }
            } while (index == 0);
            double length = GetRingSizeDiameter(answer, this.RingSizes);

            if (shape == "round") weight = (pi * Math.Pow(width, 2) * (length + width)) * metalSG / 1000;
            else if (shape == "half-round") weight = (0.75 * pi * Math.Pow(width, 2) * (length + width)) * metalSG / 1000;
            else if (shape == "square") weight = (length + width + width) * pi * width * width * metalSG / 1000;
            else weight = (length + width + thickness) * pi * width * thickness * metalSG / 1000;
            return (weight, width, thickness, metalSG, shape);
        }

        // Outputs the difference between two ring sizes
        public double RingResizer()
        {
            int index = 0;         
            double weight;
            string answer;
            (double oldWeight, double width, double thickness, double metalSG, string shape) = RingWeight();

            do
            {
                Console.WriteLine("\nWhat is the letter or number of the new rings size?");
                answer = Console.ReadLine().ToUpper();
                if (this.RingSizes.CheckLetter(answer)) index = 1;
                if (IsDouble(answer))
                {
                    if (this.RingSizes.CheckNumber(Convert.ToDouble(answer))) index = 1;
                }
            } while (index == 0);
            double length = GetRingSizeDiameter(answer, this.RingSizes);
           
            if (shape == "round") weight = (pi * Math.Pow(width, 2) * (length + width)) * metalSG / 1000;
            else if (shape == "half-round") weight = (0.75 * pi * Math.Pow(width, 2) * (length + width)) * metalSG / 1000;
            else if (shape == "square") weight = (length + width + width) * pi * width * width * metalSG / 1000;
            else weight = (length + width + thickness) * pi * width * thickness * metalSG / 1000;
            return oldWeight - weight;
        }

        // Calculations for rolling wire
        public (double, double, double) RollingWireCalculator()
        {
            double width = GetDouble("width/diameter required", "milimeters");
            double thickness = GetDouble("thickness required", "milimeters");
            double length = GetDouble("length required", "milimeters");          
            double stockSize = 0.0;
            bool stock = false;
            string shape;
            int index = 0;

            do
            {
                Console.WriteLine("\nAre you using round or square wire?");
                shape = Console.ReadLine().ToLower();
                if (shape == "round") index = 1;
                if (shape == "square") index = 1;
            } while (index == 0);

            Console.WriteLine("\nWill you be using stock gauge? Y/N");
            string answer = Console.ReadLine().ToLower();
            if (answer == "y")
            {
                stock = true;
                stockSize = GetDouble("width/diameter of stock being used", "milimeters");
            }

            double side = Math.Pow((Math.Pow(width, 2) * thickness), 1.0 / 3);
            length = (length * width * thickness) / Math.Pow(side, 2);
            if (shape == "round")
            {
                double diameter = (2 * side) / Math.Sqrt(pi);
                if (stock == true)
                {
                    stockSize = (4 * Math.Pow(side, 2) * length) / (pi * Math.Pow(stockSize, 2));
                }
                return (diameter, length, stockSize);
            }
            else
            {
                if (stock == true)
                {
                    stockSize = (Math.Pow(side, 2) * length) / Math.Pow(stockSize, 2);                 
                }
                return (side, length, stockSize);
            }          
        }

        // Adds to calculation history
        public void AddToCalculationHisory(History input)
        {
            CalculationHistory.Add(input);
        }

        // Prints history of calcuations
        public void PrintCalculationHistory()
        {
            Console.Clear();
            int i = 1;
            if (CalculationHistory.Count == 0)
            {
                Console.WriteLine("No calculations have been made yet.");
            }
            foreach (History history in CalculationHistory)
            {
                if (history.GetIdentifier() == "Metal Conversion")
                {
                    Console.WriteLine("{0}. {1} Weight: {2}", i, history.GetIdentifier(), history.GetOutput());
                }
                if (history.GetIdentifier() == "Ring Resize")
                {
                    Console.WriteLine("{0}. {1} Difference: {2}", i, history.GetIdentifier(), history.GetOutput());
                }
                if (history.GetIdentifier() == "Ring Weight")
                {
                    Console.WriteLine("{0}. {1}: {2}", i, history.GetIdentifier(), history.GetOutput());
                }
                i++;
            }
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
        }
    }
}
