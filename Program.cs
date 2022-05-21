using System;
using System.Collections.Generic;

namespace JewelleryProgramV2
{
    class Program
    {
        enum MenuOption
        {
            MetalConverter = 1,
            RingWeight = 2,
            RingResizer = 3,
            PrintHistory = 4,
            MetalSettings = 5,
            RingSizeSettings = 6,
            Quit = 7
        };

        enum SettingsMenu
        {
            Check = 1,
            Add = 2,
            Remove = 3,
            Modify = 4,
            ResetDefault = 5,
            Back = 6
        };

        static void Main(string[] args)
        {
            // Create new lists
            MetalList metalList = new MetalList();
            RingSizeList ringSizeList = new RingSizeList();
            Calculations calculations = new Calculations(metalList, ringSizeList);

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
                Console.WriteLine("{0}. Calculate Ring Weight", Convert.ToInt32(MenuOption.RingWeight));
                Console.WriteLine("{0}. Ring Resizer", Convert.ToInt32(MenuOption.RingResizer));
                Console.WriteLine("{0}. Print Calculation History", Convert.ToInt32(MenuOption.PrintHistory));
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
                Console.WriteLine("{0}. Reset to Default", Convert.ToInt32(SettingsMenu.ResetDefault), keyword);
                Console.WriteLine("{0}. Back to Main Menu", Convert.ToInt32(SettingsMenu.Back));
            }

            // Executes Ring Resizer
            static void DoRingResizer(Calculations calculations)
            {
                Console.Clear();
                Console.WriteLine("-- Ring Resizer --");

                double weight = calculations.RingResizer();
                History history = new History("Ring Resize", weight);
                calculations.AddToCalculationHisory(history);

                Console.WriteLine("\nDifference between rings is: {0}g", weight);
                Console.WriteLine("\nPress any key to continue.");
                Console.ReadKey();
                
            }

            // Executes and calculates ring weight
            static void DoRingWeight(Calculations calculations)
            {
                Console.Clear();
                Console.WriteLine("-- Calculate Ring Weight --");

                (double weight, double width, double thickness, double metalSG) = calculations.RingWeight();
                History history = new History("Ring Weight", weight);
                calculations.AddToCalculationHisory(history);

                Console.WriteLine("\nThe weight of the ring is: {0}g", weight);
                Console.WriteLine("\nPress any key to continue.");
                Console.ReadKey();
            }

            static void DoMetalConversion(Calculations calculations)
            {
                Console.Clear();
                Console.WriteLine("-- Metal Converter --");

                double weight = calculations.MetalConverter();
                History history = new History("Metal Conversion", weight);
                calculations.AddToCalculationHisory(history);

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
                        case SettingsMenu.ResetDefault: ringSizeList.ResetDefaultValues(); break;
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
                        case SettingsMenu.ResetDefault: metalList.ResetDefaultValues(); break;
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
                    case MenuOption.MetalConverter: DoMetalConversion(calculations); break;
                    case MenuOption.RingWeight: DoRingWeight(calculations); break;
                    case MenuOption.RingResizer: DoRingResizer(calculations); break;
                    case MenuOption.PrintHistory: calculations.PrintCalculationHistory(); break;
                    case MenuOption.MetalSettings: MetalSettingsMenu(metalList); break;
                    case MenuOption.RingSizeSettings: RingSizeSettingsMenu(ringSizeList); break;
                    case MenuOption.Quit: break;
                }
                Console.WriteLine();
            } while (option != MenuOption.Quit);
        }
    }
}
