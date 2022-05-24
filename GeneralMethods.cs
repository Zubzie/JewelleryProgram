using System;
using System.Collections.Generic;
using System.Text;

namespace JewelleryProgramV2
{
    class GeneralMethods
    {
        // Instance Variables
        protected const double pi = 3.14159265359;

        // Methods
        // Returns true if input is double
        protected bool IsDouble(string input)
        {
            bool isDouble = Double.TryParse(input, out _);
            if (isDouble) return true;
            return false;
        }

        // Returns double
        protected double GetDouble(string identifier, string measurement)
        {
            double input = 0.0;
            do
            {
                try
                {
                    Console.WriteLine("\nWhat is the {0}? ({1})", identifier, measurement);
                    input = Convert.ToDouble(Console.ReadLine());
                    if (input < 0.0) Console.WriteLine("Error. Must be greater then zero.");
                }
                catch
                {
                    Console.WriteLine("Error. Must be a number.");
                }
            } while (input <= 0.0);
            return input;
        }

        // Gets diameter from ring size name
        protected double GetRingSizeDiameter(string input, RingSizeList ringSizeList)
        {
            RingSize ringSize;
            double diameter;
            for (int i = 0; i < ringSizeList.GetRingSizeList().Count; i++)
            {
                if (ringSizeList.GetRingSizeList()[i].GetLetter() == input)
                {
                    ringSize = ringSizeList.GetRingSizeLetter(input);
                    diameter = ringSize.GetDiameter();
                    return diameter;
                }
                if (IsDouble(input))
                {
                    if (ringSizeList.GetRingSizeList()[i].GetNumber() == Convert.ToDouble(input))
                    {
                        ringSize = ringSizeList.GetRingSizeNumber(Convert.ToDouble(input));
                        diameter = ringSize.GetDiameter();
                        return diameter;
                    }
                }
            }
            diameter = 0.0;
            return diameter;
        }
    }
}
