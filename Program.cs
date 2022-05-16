using System;
using System.Collections.Generic;

namespace JewelleryProgramV2
{
    class Program
    {
        enum MenuOption
        {
            MetalConverter = 1,
            Quit = 2
        };

        static void Main(string[] args)
        {
            // Default Metals
            List<Metal> metalList = new List<Metal>();
            Metal platinum = new Metal("Platinum", 21.24);
            metalList.Add(platinum);
            Metal fineGold = new Metal("Fine Gold", 19.36);
            metalList.Add(fineGold);
            Metal yellow18ct = new Metal("18ct Yellow Gold", 16.04);
            metalList.Add(yellow18ct);
            Metal yellow14ct = new Metal("14ct Yellow Gold", 13.56);
            metalList.Add(yellow14ct);
            Metal yellow9ct = new Metal("9ct Yellow Gold", 11.64);
            metalList.Add(yellow9ct);
            Metal white18ct = new Metal("18ct White Gold", 16.59);
            metalList.Add(white18ct);
            Metal white14ct = new Metal("14ct White Gold", 14.02);
            metalList.Add(white14ct);
            Metal white9ct = new Metal("9ct White Gold", 13.04);
            metalList.Add(white9ct);
            Metal pink18ct = new Metal("18ct Pink Gold", 15.45);
            metalList.Add(pink18ct);
            Metal pink14ct = new Metal("14ct Pink Gold", 14.00);
            metalList.Add(pink14ct);
            Metal pink9ct = new Metal("9ct Pink Gold", 11.71);
            metalList.Add(pink9ct);
            Metal fineSilver = new Metal("Fine Silver", 10.64);
            metalList.Add(fineSilver);
            Metal brightSilver = new Metal("Bright Silver", 10.50);
            metalList.Add(brightSilver);
            Metal sterlingSilver = new Metal("Sterling Silver", 10.55);
            metalList.Add(sterlingSilver);
            Metal wax = new Metal("Wax", 1.0);
            metalList.Add(wax);

            // Reads and checks user input
            static MenuOption ReadUserOption()
            {
                int option = 0;
                do
                {
                    try
                    {
                        option = Convert.ToInt32(Console.ReadLine());
                        if (option! < 1 || option! > Convert.ToInt32(MenuOption.Quit))
                        {
                            Console.WriteLine("Must be a number between 1 and {0}. Please try again.", Convert.ToInt32(MenuOption.Quit));
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Error. Must be a number.");
                    }
                } while (option! < 1 && option! > Convert.ToInt32(MenuOption.Quit));
                return (MenuOption)option;
            }

            // Checks for metal
            static bool CheckMetal(string metal, List<Metal> metalList)
            {
                for (int i = 0; i < metalList.Count; i++)
                {
                    if (metalList[i].GetName() == metal)
                    {
                        return true;
                    }
                }
                return false;
            }
            
            // Prints Main Menu
            static void printMainMenu()
            {
                Console.WriteLine("-- MAIN MENU --");
                Console.WriteLine("{0}. Metal Calculator", Convert.ToInt32(MenuOption.MetalConverter));
                Console.WriteLine("{0}. Quit", Convert.ToInt32(MenuOption.Quit));
            }
            
            // Converts metals
            static void metalConverter(List<Metal> metalList)
            {
                string metal1 = "";
                string metal2 = "";
                double weight = 0.0;

                Console.WriteLine("What is the original metal?");
                do
                {
                    metal1 = Console.ReadLine().ToString();
                } while (CheckMetal(metal1, metalList)! == true);

                Console.WriteLine("What is the new metal?");
                do
                {
                    metal2 = Console.ReadLine().ToString();
                } while (CheckMetal(metal2, metalList)! == true);

                Console.WriteLine("What is the weight?");
                do
                {
                    try
                    {
                        weight = Convert.ToDouble(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Error. Must be a number.");
                    }                   
                } while (weight! == );

            }

            // Main Menu
            MenuOption option;
            do
            {
                printMainMenu();
                Console.WriteLine();
                Console.WriteLine("What would you like to do?");
                option = ReadUserOption();

                switch (option)
                {
                    case MenuOption.MetalConverter: metalConverter(metalList); break;
                    case MenuOption.Quit: break;
                }
                Console.WriteLine("");
            } while (option != MenuOption.Quit);
        }
    }
}
