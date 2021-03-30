using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BulkThumbnaillCreator
{
    class View
    {
        public static void Menu()
        {
            Console.Clear();

            Console.Write("\t");

            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("MENU:");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine("\npress 1 for renaming a photo;");
            Console.WriteLine("press 2 change of the size of a photo;");
            Console.WriteLine("press 3 to exit the program.");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("select the required action: ");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static int EnterNumber(int number, Action action)
        {
            var numberMenu = 0;

            string message = string.Format("Enter a number from 1 to {0}: ", number);

            // Cycle until one of the menu item numbers is entered
            while (true)
            {
                // The required menu number is entered, taking into account 
                // the overflow and the format of the entered number.
                try
                {
                    numberMenu = int.Parse(Console.ReadLine());

                    var condition = numberMenu > 0 && numberMenu < (number + 1);

                    if (condition)
                    {
                        break;
                    }
                    else
                    {
                        throw new Exception(message);
                    }
                }
                catch (Exception ex)
                {
                    try
                    {
                        if (ex.GetType().ToString() == "System.FormatException")
                        {
                            throw new FormatException(message);
                        }
                        else if (ex.GetType().ToString() == "System.OverflowException")
                        {
                            throw new OverflowException(message);
                        }
                        else
                        {
                            Console.Clear();

                            action();

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("\n" + ex.Message);
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                    }
                    catch (OverflowException exc)
                    {
                        Console.Clear();

                        action();

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\n" + exc.Message);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    catch (FormatException exc)
                    {
                        Console.Clear();

                        action();

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\n" + exc.Message);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                }
            }

            return numberMenu;
        }

        public static void ExitProgram()
        {
            Environment.Exit(0);
        }

        public static void DisplayMessageSize()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("Thanks, the size of all pictures it is changed. Can be convinced.");

            Console.ForegroundColor = ConsoleColor.Gray;

            Console.ReadKey();
        }

        public static string EnterNamePictures()
        {
            Console.Clear();

            Console.Write("Enter name files: ");

            Console.ForegroundColor = ConsoleColor.Green;
            string namePictures = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Gray;

            return namePictures;
        }
    }
}
