using System;
using System.Collections.Generic;

namespace JewelleryProgramV2
{
    class Program
    {
        enum MenuOption
        {
            MetalConverter = 1,
            MetalSettings = 2,
            Quit = 3
        };

        enum SettingsMenu
        {
            CheckMetals = 1,
            AddMetal = 2,
            RemoveMetal = 3,
            Back = 4
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

            // Reads and checks user input for Main Menu
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

            // Prints Main Menu
            static void printMainMenu()
            {
                Console.WriteLine("-- MAIN MENU --");
                Console.WriteLine("{0}. Metal Calculator", Convert.ToInt32(MenuOption.MetalConverter));
                Console.WriteLine("{0}. Metal Settings", Convert.ToInt32(MenuOption.MetalSettings));
                Console.WriteLine("{0}. Quit", Convert.ToInt32(MenuOption.Quit));
            }

            // Reads and checks user input for Settings Menu
            static SettingsMenu ReadSettingsMenu()
            {
                int option = 0;
                do
                {
                    try
                    {
                        option = Convert.ToInt32(Console.ReadLine());
                        if (option! < 1 || option! > Convert.ToInt32(SettingsMenu.Back))
                        {
                            Console.WriteLine("Must be a number between 1 and {0}. Please try again.", Convert.ToInt32(SettingsMenu.Back));
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Error. Must be a number.");
                    }
                } while (option! < 1 && option! > Convert.ToInt32(SettingsMenu.Back));
                return (SettingsMenu)option;
            }                   
            
            // Prints Metal Settings Menu
            static void printMetalSettings()
            {
                Console.WriteLine("-- METAL SETTINGS --");
                Console.WriteLine("{0}. Check Metals", Convert.ToInt32(SettingsMenu.CheckMetals));
                Console.WriteLine("{0}. Add Metal", Convert.ToInt32(SettingsMenu.AddMetal));
                Console.WriteLine("{0}. Remove Metal", Convert.ToInt32(SettingsMenu.RemoveMetal));
                Console.WriteLine("{0}. Back to Main Menu", Convert.ToInt32(SettingsMenu.Back));
            }

            // Checks for metal name in metalList
            static bool CheckMetal(string metal, List<Metal> metalList)
            {
                for (int i = 0; i < metalList.Count; i++)
                {
                    if (metalList[i].GetName().ToLower() == metal)
                    {
                        return true;
                    }
                }
                return false;
            }

            // Gets metal from metalList
            static Metal GetMetal(string metal, List<Metal> metalList)
            {
                for (int i = 0; i < metalList.Count; i++)
                {
                    if (metalList[i].GetName().ToLower() == metal)
                    {
                        return metalList[i];
                    }
                }
                return null;
            }

            // Prints out metals
            static void PrintMetals(List<Metal> metalList)
            {
                Console.WriteLine("\nMetal List:");
                foreach (Metal metal in metalList)
                {
                    Console.WriteLine(metal.GetName());
                }
            }

            // Prints details of metals
            static void PrintMetalDetails(List<Metal> metalList)
            {
                Console.Clear();
                Console.Write("{0}", "-- Metal List --");
                Console.SetCursorPosition(30, 0);
                Console.WriteLine("{0}", "-- Specific Gravity --");
                for (int i = 0; i < metalList.Count; i++)
                {                   
                    Console.Write("{0}. {1}", (i+1), metalList[i].GetName());
                    Console.SetCursorPosition(38, (i + 1));
                    Console.WriteLine("{0}", metalList[i].GetSG());
                }

                Console.WriteLine("\nPress any key to continue."); 
                Console.ReadKey();
            }

            // Adds a new metal
            static List<Metal> AddMetal(List<Metal> metalList)
            {
                Console.Clear();
                Console.WriteLine("-- Add Metal --");
                Console.WriteLine("\nWhat is the name of the new metal?");
                string metal = Console.ReadLine().ToString();
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
                metalList.Add(newMetal);
                return metalList;
            }

            // Remove a metal
            static List<Metal> RemoveMetal(List<Metal> metalList)
            {
                Console.Clear();
                Console.WriteLine("-- Remove Metal --");

                PrintMetals(metalList);
                Console.WriteLine("\nWhat is the name of the metal to remove?");
                string metal = Console.ReadLine().ToString().ToLower();

                for (int i = 0; i < metalList.Count; i++)
                {
                    if (metalList[i].GetName().ToLower() == metal)
                    {
                        metalList.RemoveAt(i);
                    }
                }               

                return metalList;
            }

            // Converts metal to another metal
            static void metalConverter(List<Metal> metalList)
            {              
                Metal dummyMetal = new Metal("", 0.0);
                string oldMetal;
                string newMetal;
                double weight = 0.0;

                Console.Clear();
                Console.WriteLine("-- Metal Converter --");
                PrintMetals(metalList);
                
                do
                {
                    Console.WriteLine("\nWhat is the original metal?");
                    oldMetal = Console.ReadLine().ToString();
                } while (CheckMetal(oldMetal.ToLower(), metalList) == false);

                do
                {
                    Console.WriteLine("\nWhat is the new metal?");
                    newMetal = Console.ReadLine().ToString();
                } while (CheckMetal(newMetal.ToLower(), metalList) == false);
               
                do
                {
                    try
                    {
                        Console.WriteLine("\nWhat is the weight? (grams)");
                        weight = Convert.ToDouble(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Error. Must be a number.");
                    }                   
                } while (weight <= 0.0);

                weight = dummyMetal.ConvertMetal(GetMetal(oldMetal.ToLower(), metalList), GetMetal(newMetal.ToLower(), metalList), weight);
                Console.WriteLine("\nNew metal weight is: {0}g", weight);

                Console.WriteLine("\nPress any key to continue.");
                Console.ReadKey();
            }

            // Metal Settings Menu
            static void MetalSettingsMenu(List<Metal> metalList)
            {
                SettingsMenu option;
                do
                {
                    Console.Clear();
                    printMetalSettings();
                    Console.WriteLine("\nWhat would you like to do?");
                    option = ReadSettingsMenu();

                    switch (option)
                    {
                        case SettingsMenu.CheckMetals: PrintMetalDetails(metalList); break;
                        case SettingsMenu.AddMetal: metalList = AddMetal(metalList); break;
                        case SettingsMenu.RemoveMetal: metalList = RemoveMetal(metalList); break;
                        case SettingsMenu.Back: break;
                    }
                    Console.WriteLine();
                } while (option != SettingsMenu.Back);
            }

            // Main Menu
            MenuOption option;
            do
            {
                Console.Clear();
                printMainMenu();
                Console.WriteLine("\nWhat would you like to do?");
                option = ReadUserOption();

                switch (option)
                {
                    case MenuOption.MetalConverter: metalConverter(metalList); break;
                    case MenuOption.MetalSettings: MetalSettingsMenu(metalList); break;
                    case MenuOption.Quit: break;
                }
                Console.WriteLine();
            } while (option != MenuOption.Quit);
        }
    }
}
