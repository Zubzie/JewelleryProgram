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
            RingSizeSettings = 3,
            Quit = 4
        };

        enum SettingsMenu
        {
            Check = 1,
            Add = 2,
            Remove = 3,
            Modify = 4,
            Back = 5
        };

        static void Main(string[] args)
        {
            // Create new lists
            MetalList metalList = new MetalList();
            RingSizeList ringSizeList = new RingSizeList();

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

            // Prints Main Menu
            static void PrintMainMenu()
            {
                Console.WriteLine("-- MAIN MENU --");
                Console.WriteLine("{0}. Metal Calculator", Convert.ToInt32(MenuOption.MetalConverter));
                Console.WriteLine("{0}. Metal Settings", Convert.ToInt32(MenuOption.MetalSettings));
                Console.WriteLine("{0}. Ring Size Settings", Convert.ToInt32(MenuOption.RingSizeSettings));
                Console.WriteLine("{0}. Quit", Convert.ToInt32(MenuOption.Quit));
            }                            
            
            // Prints Metal Settings Menu
            static void PrintSettings(string keyword)
            {
                Console.WriteLine("-- {0} SETTINGS --", keyword.ToUpper());
                Console.WriteLine("{0}. Check {1}s", Convert.ToInt32(SettingsMenu.Check), keyword);
                Console.WriteLine("{0}. Add {1}", Convert.ToInt32(SettingsMenu.Add), keyword);
                Console.WriteLine("{0}. Remove {1}", Convert.ToInt32(SettingsMenu.Remove), keyword);
                Console.WriteLine("{0}. Modify {1}", Convert.ToInt32(SettingsMenu.Modify), keyword);
                Console.WriteLine("{0}. Back to Main Menu", Convert.ToInt32(SettingsMenu.Back));
            }             

            // Converts metal to another metal
            static void MetalConverter(MetalList metalList)
            {              
                Metal dummyMetal = new Metal("", 0.0);
                string oldMetal;
                string newMetal;
                double weight = 0.0;

                Console.Clear();
                Console.WriteLine("-- Metal Converter --");
                metalList.PrintMetals();
                
                do
                {
                    Console.WriteLine("\nWhat is the original metal?");
                    oldMetal = Console.ReadLine().ToString();
                } while (metalList.CheckMetal(oldMetal.ToLower()) == false);

                do
                {
                    Console.WriteLine("\nWhat is the new metal?");
                    newMetal = Console.ReadLine().ToString();
                } while (metalList.CheckMetal(newMetal.ToLower()) == false);
               
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

                weight = dummyMetal.ConvertMetal(metalList.GetMetal(oldMetal.ToLower()), metalList.GetMetal(newMetal.ToLower()), weight);
                Console.WriteLine("\nNew metal weight is: {0}g", weight);

                Console.WriteLine("\nPress any key to continue.");
                Console.ReadKey();
            }

            // Ring Size Settings Menu
            static void RingSizeSettingsMenu(RingSizeList ringSizeList)
            {
                SettingsMenu option;
                do
                {
                    Console.Clear();
                    PrintSettings("Ring Size");
                    Console.WriteLine("\nWhat would you like to do?");
                    option = ReadSettingsMenu();

                    switch (option)
                    {
                        case SettingsMenu.Check: ringSizeList.PrintRingSizeDetails(); break;
                        case SettingsMenu.Add: ringSizeList.AddRingSize(); break;
                        case SettingsMenu.Remove: ringSizeList.RemoveRingSize(); break;
                        case SettingsMenu.Modify: ringSizeList.ModifyRingSize(); break;
                        case SettingsMenu.Back: break;
                    }
                    Console.WriteLine();
                } while (option != SettingsMenu.Back);
            }

            // Metal Settings Menu
            static void MetalSettingsMenu(MetalList metalList)
            {
                SettingsMenu option;
                do
                {
                    Console.Clear();
                    PrintSettings("Metal");
                    Console.WriteLine("\nWhat would you like to do?");
                    option = ReadSettingsMenu();

                    switch (option)
                    {
                        case SettingsMenu.Check: metalList.PrintMetalDetails(); break;
                        case SettingsMenu.Add: metalList.AddMetal(); break;
                        case SettingsMenu.Remove: metalList.RemoveMetal(); break;
                        case SettingsMenu.Modify: metalList.ModifyMetal(); break;
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
                PrintMainMenu();
                Console.WriteLine("\nWhat would you like to do?");
                option = ReadUserOption();

                switch (option)
                {
                    case MenuOption.MetalConverter: MetalConverter(metalList); break;
                    case MenuOption.MetalSettings: MetalSettingsMenu(metalList); break;
                    case MenuOption.RingSizeSettings: RingSizeSettingsMenu(ringSizeList); break;
                    case MenuOption.Quit: break;
                }
                Console.WriteLine();
            } while (option != MenuOption.Quit);
        }
    }
}
