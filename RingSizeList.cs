using System;
using System.Collections.Generic;
using System.Text;

namespace JewelleryProgramV2
{
    class RingSizeList
    {
        // Instance Variables
        private List<RingSize> List;

        // Constructor
        public RingSizeList()
        {
            List<RingSize> ringSizeList = new List<RingSize>();
            this.List = ringSizeList;
            AddDefaultSizes();
        }

        // Methods
        public List<RingSize> GetRingSizeList()
        {
            return this.List;
        }

        // Adds all default ring sizes
        public void AddDefaultSizes()
        {
            RingSize a = new RingSize("A", 0.5, 12.04);
            this.List.Add(a);
            RingSize b = new RingSize("B", 1.0, 12.45);
            this.List.Add(b);
            RingSize c = new RingSize("C", 1.5, 12.85);
            this.List.Add(c);
            RingSize d = new RingSize("D", 2.0, 13.26);
            this.List.Add(d);
            RingSize e = new RingSize("E", 2.5, 13.67);
            this.List.Add(e);
            RingSize f = new RingSize("F", 3.0, 14.07);
            this.List.Add(f);
            RingSize g = new RingSize("G", 3.5, 14.48);
            this.List.Add(g);
            RingSize h = new RingSize("H", 4.0, 14.88);
            this.List.Add(h);
            RingSize i = new RingSize("I", 4.5, 15.29);
            this.List.Add(i);
            RingSize j = new RingSize("J", 5.0, 15.49);
            this.List.Add(j);
            RingSize k = new RingSize("K", 5.5, 15.9);
            this.List.Add(k);
            RingSize l = new RingSize("L", 6.0, 16.31);
            this.List.Add(l);
            RingSize m = new RingSize("M", 6.5, 16.71);
            this.List.Add(m);
            RingSize n = new RingSize("N", 7.0, 17.12);
            this.List.Add(n);
            RingSize o = new RingSize("O", 7.5, 17.53);
            this.List.Add(o);
            RingSize p = new RingSize("P", 8.0, 17.93);
            this.List.Add(p);
            RingSize q = new RingSize("Q", 8.5, 18.34);
            this.List.Add(q);
            RingSize r = new RingSize("R", 9.0, 18.75);
            this.List.Add(r);
            RingSize s = new RingSize("S", 9.5, 19.15);
            this.List.Add(s);
            RingSize t = new RingSize("T", 10.0, 19.56);
            this.List.Add(t);
            RingSize u = new RingSize("U", 10.5, 19.96);
            this.List.Add(u);
            RingSize v = new RingSize("V", 11.0, 20.37);
            this.List.Add(v);
            RingSize w = new RingSize("W", 11.5, 20.78);
            this.List.Add(w);
            RingSize x = new RingSize("X", 12.0, 21.18);
            this.List.Add(x);
            RingSize y = new RingSize("Y", 12.5, 21.59);
            this.List.Add(y);
            RingSize z = new RingSize("Z", 13.0, 21.79);
            this.List.Add(z);
        }

        // Checks for ring size letter in list
        public bool CheckLetter(string letter)
        {
            for (int i = 0; i < this.List.Count; i++)
            {
                if (this.List[i].GetLetter() == letter.ToUpper())
                {
                    return true;
                }
            }
            return false;
        }

        // Checks for ring size number in list
        public bool CheckNumber(double number)
        {
            for (int i = 0; i < this.List.Count; i++)
            {
                if (this.List[i].GetNumber() == number)
                {
                    return true;
                }
            }
            return false;
        }

        // Gets Ring Size from list with letter
        public RingSize GetRingSizeLetter(string letter)
        {
            for (int i = 0; i < this.List.Count; i++)
            {
                if (this.List[i].GetLetter() == letter.ToUpper())
                {
                    return List[i];
                }
            }
            return null;
        }

        // Gets Ring Size from list with number
        public RingSize GetRingSizeNumber(double number)
        {
            for (int i = 0; i < this.List.Count; i++)
            {
                if (this.List[i].GetNumber() == number)
                {
                    return List[i];
                }
            }
            return null;
        }

        // Prints out ring sizes
        public void PrintRingSizes()
        {
            int i = 0;
            foreach (RingSize ringSize in this.List)
            {
                Console.Write("AUS: {0}", ringSize.GetLetter());
                Console.SetCursorPosition(12, (i + 1));
                Console.WriteLine("USA: {0}", ringSize.GetNumber());
                i++;
            }
        }

        // Prints details of ring sizes
        public void PrintRingSizeDetails()
        {
            Console.Clear();
            Console.Write("-- Ring Size List --");
            Console.SetCursorPosition(30, 0);
            Console.WriteLine("-- Diameter --");
            int i = 0;

            foreach (RingSize ringSize in this.List)
            {
                Console.Write("AUS: {0}", ringSize.GetLetter());
                Console.SetCursorPosition(12, (i + 1));
                Console.Write("USA: {0}", ringSize.GetNumber());
                Console.SetCursorPosition(35, (i + 1));
                Console.WriteLine("{0}", this.List[i].GetDiameter());
                i++;
            }

            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
        }

        // Adds a new ring size
        public List<RingSize> AddRingSize()
        {
            Console.Clear();
            Console.WriteLine("-- Add Ring Size --");
            string letter;
            double number = 0.0;
            double diameter = 0.0;
            int index = 0;

            do
            {
                Console.WriteLine("\nWhat is the letter size of the new ring size?");
                letter = Console.ReadLine().ToUpper();
                if (CheckLetter(letter)) index = 1;
                if (IsDouble(letter))
                {
                    if (CheckNumber(Convert.ToDouble(letter))) index = 1;
                }
            } while (index == 0);

            do
            {
                try
                {
                    Console.WriteLine("\nWhat is the number size of the new ring size?");
                    number = Convert.ToDouble(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Error. Must be a number.");
                }
            } while (number <= 0.0);

            do
            {
                try
                {
                    Console.WriteLine("\nWhat is the diameter of the new ring size?");
                    diameter = Convert.ToDouble(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Error. Must be a number.");
                }
            } while (diameter <= 0.0);

            RingSize newRingSize = new RingSize(letter, number, diameter);
            this.List.Add(newRingSize);
            return List;
        }

        // Remove a ring size
        public List<RingSize> RemoveRingSize()
        {
            Console.Clear();
            Console.WriteLine("-- Remove Ring Size --");
            PrintRingSizes();
            string answer;
            int index = 0;

            do
            {
                Console.WriteLine("\nWhat is the letter or number of the ring size to remove?");
                answer = Console.ReadLine().ToUpper();
                if (CheckLetter(answer)) index = 1;
                if (IsDouble(answer))
                {
                    if (CheckNumber(Convert.ToDouble(answer))) index = 1;
                }
            } while (index == 0);
            
            for (int i = 0; i < this.List.Count; i++)
            {
                if (this.List[i].GetLetter() == answer)
                {
                    this.List.RemoveAt(i);
                    break;
                }
                if (IsDouble(answer))
                {
                    if (this.List[i].GetNumber() == Convert.ToDouble(answer))
                    {
                        this.List.RemoveAt(i);
                        break;
                    }
                }
            }
            return List;
        }

        // Modify a ring size
        public List<RingSize> ModifyRingSize()
        {
            Console.Clear();
            Console.WriteLine("-- Modify Ring Size --");
            PrintRingSizes();
            int index = 0;
            string answer;
            double answerDouble = 0.0;
            string letter = "";
            double number = 0.0;
            double diameter = 0.0;

            do
            {
                Console.WriteLine("\nWhat is the letter or number of the ring size to remove?");
                answer = Console.ReadLine().ToUpper();
                if (CheckLetter(answer)) index = 1;
                if (IsDouble(answer))
                {
                    if (CheckNumber(Convert.ToDouble(answer))) index = 1;
                }
            } while (index == 0);
            index = 0;

            for (int i = 0; i < this.List.Count; i++)
            {
                if (this.List[i].GetLetter() == answer)
                {
                    letter = this.List[i].GetLetter();
                    number = this.List[i].GetNumber();
                    diameter = this.List[i].GetDiameter();
                }
                if (IsDouble(answer))
                {
                    if (this.List[i].GetNumber() == Convert.ToDouble(answer))
                    {
                        letter = this.List[i].GetLetter();
                        number = this.List[i].GetNumber();
                        diameter = this.List[i].GetDiameter();
                    }
                }
            }

            do
            {
                Console.WriteLine("\nDo you want to modify the letter, number or diameter?");
                answer = Console.ReadLine().ToLower();
                if (answer == "letter") index = 1;
                if (answer == "number") index = 1;
                if (answer == "diameter") index = 1;
            } while (index == 0);

            if (answer == "letter")
            {
                Console.WriteLine("\nWhat is the new letter?");
                answer = Console.ReadLine().ToLower();

                for (int i = 0; i < this.List.Count; i++)
                {
                    if (this.List[i].GetLetter() == letter)
                    {
                        this.List[i].SetLetter(answer);
                        break;
                    }
                }
            }
            if (answer == "number")
            {
                do
                {
                    try
                    {
                        Console.WriteLine("\nWhat is the new number?");
                        answerDouble = Convert.ToDouble(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Error. Must be a number.");
                    }
                } while (answerDouble <= 0.0);

                for (int i = 0; i < this.List.Count; i++)
                {
                    if (this.List[i].GetNumber() == number)
                    {
                        this.List[i].SetNumber(answerDouble);
                        break;
                    }
                }
            }
            if (answer == "diameter")
            {
                do
                {
                    try
                    {
                        Console.WriteLine("\nWhat is the new diameter?");
                        answerDouble = Convert.ToDouble(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Error. Must be a number.");
                    }
                } while (answerDouble <= 0.0);

                for (int i = 0; i < this.List.Count; i++)
                {
                    if (this.List[i].GetDiameter() == diameter)
                    {
                        this.List[i].SetDiameter(answerDouble);
                        break;
                    }
                }    
            }                  
            return List;       
        }

        // Resets all ring sizes to default
        public void ResetDefaultValues()
        {            
            Console.WriteLine("Would you like to reset ring sizes to default? Y/N");
            string answer = Console.ReadLine().ToLower();
            
            if (answer == "y")
            {
                List<RingSize> ringSizeList = new List<RingSize>();
                List = ringSizeList;
                AddDefaultSizes();
            }
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
    }
}
