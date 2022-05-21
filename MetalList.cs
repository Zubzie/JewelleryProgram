using System;
using System.Collections.Generic;
using System.Text;

namespace JewelleryProgramV2
{
    class MetalList
    {
        // Instance Variables
        private List<Metal> List;

        // Constructor
        public MetalList()
        {
            List<Metal> metalList = new List<Metal>();
            this.List = metalList;
            AddDefaultMetals();
        }

        // Methods
        public List<Metal> GetMetalList()
        {
            return this.List;
        }

        // Adds all default metals
        public void AddDefaultMetals()
        {
            Metal platinum = new Metal("Platinum", 21.24);
            this.List.Add(platinum);
            Metal fineGold = new Metal("Fine Gold", 19.36);
            this.List.Add(fineGold);
            Metal yellow18ct = new Metal("18ct Yellow Gold", 16.04);
            this.List.Add(yellow18ct);
            Metal yellow14ct = new Metal("14ct Yellow Gold", 13.56);
            this.List.Add(yellow14ct);
            Metal yellow9ct = new Metal("9ct Yellow Gold", 11.64);
            this.List.Add(yellow9ct);
            Metal white18ct = new Metal("18ct White Gold", 16.59);
            this.List.Add(white18ct);
            Metal white14ct = new Metal("14ct White Gold", 14.02);
            this.List.Add(white14ct);
            Metal white9ct = new Metal("9ct White Gold", 13.04);
            this.List.Add(white9ct);
            Metal pink18ct = new Metal("18ct Pink Gold", 15.45);
            this.List.Add(pink18ct);
            Metal pink14ct = new Metal("14ct Pink Gold", 14.00);
            this.List.Add(pink14ct);
            Metal pink9ct = new Metal("9ct Pink Gold", 11.71);
            this.List.Add(pink9ct);
            Metal fineSilver = new Metal("Fine Silver", 10.64);
            this.List.Add(fineSilver);
            Metal brightSilver = new Metal("Bright Silver", 10.50);
            this.List.Add(brightSilver);
            Metal sterlingSilver = new Metal("Sterling Silver", 10.55);
            this.List.Add(sterlingSilver);
            Metal wax = new Metal("Wax", 1.0);
            this.List.Add(wax);
        }

        // Checks for metal name in list
        public bool CheckMetal(string metal)
        {
            for (int i = 0; i < this.List.Count; i++)
            {
                if (this.List[i].GetName().ToLower() == metal)
                {
                    return true;
                }
            }
            return false;
        }

        // Gets metal from list
        public Metal GetMetal(string metal)
        {
            for (int i = 0; i < this.List.Count; i++)
            {
                if (this.List[i].GetName().ToLower() == metal)
                {
                    return List[i];
                }
            }
            return null;
        }

        // Prints out metals
        public void PrintMetals()
        {
            foreach (Metal metal in this.List)
            {
                Console.WriteLine(metal.GetName());
            }
        }

        // Prints details of metals
        public void PrintMetalDetails()
        {
            Console.Clear();
            Console.Write("-- Metal List --");
            Console.SetCursorPosition(30, 0);
            Console.WriteLine("-- Specific Gravity --");
            for (int i = 0; i < this.List.Count; i++)
            {
                Console.Write("{0}. {1}", (i + 1), this.List[i].GetName());
                Console.SetCursorPosition(38, (i + 1));
                Console.WriteLine("{0}", this.List[i].GetSG());
            }

            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
        }

        // Adds a new metal
        public List<Metal> AddMetal()
        {
            Console.Clear();
            Console.WriteLine("-- Add Metal --");
            Console.WriteLine("\nWhat is the name of the new metal?");
            string metal = Console.ReadLine();
            metal = char.ToUpper(metal[0]) + metal[1..];
            double sg = 0.0;

            do
            {
                try
                {
                    Console.WriteLine("\nWhat is the specific gravity of the new metal?");
                    sg = Convert.ToDouble(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Error. Must be a number.");
                }
            } while (sg <= 0.0);

            Metal newMetal = new Metal(metal, sg);
            this.List.Add(newMetal);
            return List;
        }

        // Remove a metal
        public List<Metal> RemoveMetal()
        {
            Console.Clear();
            Console.WriteLine("-- Remove Metal --");
            PrintMetals();
            string metal;
            do
            {
                Console.WriteLine("\nWhat is the name of the metal to remove?");
                metal = Console.ReadLine().ToString().ToLower();
            } while (CheckMetal(metal) == false);          

            for (int i = 0; i < this.List.Count; i++)
            {
                if (this.List[i].GetName().ToLower() == metal)
                {
                    this.List.RemoveAt(i);
                    break;
                }
            }
            return List;
        }

        // Modify a metal
        public List<Metal> ModifyMetal()
        {
            Console.Clear();
            Console.WriteLine("-- Modify Metal --");
            PrintMetals();
            string metal, answer;
            double sg = 0.0;
            int index = 0;

            do
            {
                Console.WriteLine("\nWhat is the name of the metal to modify?");
                metal = Console.ReadLine().ToLower();
            } while (CheckMetal(metal) == false);
            
            do
            {
                Console.WriteLine("\nWould you like to change the name or specific gravity(SG)?");
                answer = Console.ReadLine().ToLower();
                if (answer == "name") index = 1;               
                if (answer == "specific gravity") index = 1;
                if (answer == "sg") index = 1;
            } while (index == 0);
           
            if (answer == "name")
            {   
                Console.WriteLine("\nWhat is the new name of the metal?");
                answer = Console.ReadLine().ToString();
                answer = char.ToUpper(answer[0]) + answer[1..];

                for (int i = 0; i < this.List.Count; i++)
                {
                    if (this.List[i].GetName().ToLower() == metal)
                    {
                        this.List[i].SetName(answer);
                        break;
                    }
                }
                return List;
            }
            else
            {
                do
                {
                    try
                    {
                        Console.WriteLine("\nWhat is the new specific gravity of the metal?");
                        sg = Convert.ToDouble(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Error. Must be a number.");
                    }
                } while (sg <= 0.0);

                for (int i = 0; i < this.List.Count; i++)
                {
                    if (this.List[i].GetName().ToLower() == metal)
                    {
                        this.List[i].SetSG(sg);
                        break;
                    }
                }
                return List;
            }
        }

        // Restores all metals to default values
        public void ResetDefaultValues()
        {
            Console.WriteLine("Would you like to reset metals to default? Y/N");
            string answer = Console.ReadLine().ToLower();

            if (answer == "y")
            {
                List<Metal> metalList = new List<Metal>();
                List = metalList;
                AddDefaultMetals();
            }
        }
    }
}
