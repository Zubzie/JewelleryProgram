using System;
using System.Collections.Generic;
using System.Text;

namespace JewelleryProgramV2
{
    class Calculations
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
            double weight = 0.0;
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

            weight = GetDouble("weight", "grams");

            Metal oldMetal = Metals.GetMetal(oldMetalStr.ToLower());
            Metal newMetal = Metals.GetMetal(newMetalStr.ToLower());

            weight *= 1.0 / oldMetal.GetSG();
            weight *= newMetal.GetSG();
            return weight;
        }

        // Outputs the rough weight of a ring
        public (double, double, double, double) RingWeight()
        {
            int index = 0;
            double pi = 3.14159265359;
            double metalSG = 0.0;
            string answer;

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
            double thickness = GetDouble("thickness", "milimeters");

            Console.Clear();
            Console.WriteLine("-- Ring Sizes --");
            this.RingSizes.PrintRingSizes();
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

            double size = GetDiameter(answer);
            double weight = ((((width + thickness + size) * pi) * width * thickness) * metalSG) / 1000;
            return (weight, width, thickness, metalSG);
        }

        // Outputs the difference between two ring sizes
        public double RingResizer()
        {
            int index = 0;
            double pi = 3.14159265359;
            string answer;
            (double oldWeight, double width, double thickness, double metalSG) = RingWeight();
            
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

            double newSize = GetDiameter(answer);
            double weight = ((((width + thickness + newSize) * pi) * width * thickness) * metalSG) / 1000;
            weight = oldWeight - weight;
            return weight;
        }

        // Calculations for rolling wire
        public double RollingWireCalculator()
        {
            double width = GetDouble("width", "milimeters");
            double thickness = GetDouble("thickness", "milimeters");
            double length = GetDouble("length", "milimeters");
            string stock;

            Console.WriteLine("Are you using stock gauge? Y/N");
            string answer = Console.ReadLine().ToLower();

            if (answer == "y")
            {
                int index = 0;              
                do
                {
                    Console.WriteLine("Are you using round or square?");
                    answer = Console.ReadLine().ToLower();
                    if (answer == "round") index = 1; stock = "round";
                    if (answer == "square") index = 1; stock = "square";
                } while (index == 0);
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

        // Returns true if input is double
        private bool IsDouble(string input)
        {
            bool isDouble = Double.TryParse(input, out double output);
            if (isDouble)
            {
                return true;
            }
            return false;
        }

        // Gets diameter from ring size name
        private double GetDiameter(string input)
        {
            RingSize ringSize;
            double diameter;
            for (int i = 0; i < this.RingSizes.GetRingSizeList().Count; i++)
            {              
                if (this.RingSizes.GetRingSizeList()[i].GetLetter() == input)
                {
                    ringSize = this.RingSizes.GetRingSizeLetter(input);
                    diameter = ringSize.GetDiameter();
                    return diameter;
                }
                if (IsDouble(input))
                {
                    if (this.RingSizes.GetRingSizeList()[i].GetNumber() == Convert.ToDouble(input))
                    {
                        ringSize = this.RingSizes.GetRingSizeNumber(Convert.ToDouble(input));
                        diameter = ringSize.GetDiameter();
                        return diameter;
                    }
                }
            }
            diameter = 0.0;
            return diameter;
        }

        // Returns double
        private double GetDouble(string identifier, string measurement)
        {
            double input = 0.0;
            do
            {
                try
                {
                    Console.WriteLine("\nWhat is the {0}? ({1})", identifier, measurement);
                    input = Convert.ToDouble(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Error. Must be a number.");
                }
            } while (input <= 0.0);
            return input;
        }
    }
}
