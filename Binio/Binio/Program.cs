using System;

namespace Binio
{
    class Program
    {
        static void Main(string[] args)
        {
            //Call Title writing Method
            CallTitleSequence();
            bool exitApp = false;
            do
            {
                switch (CallMenuSequence())
                {
                    case 1:
                        {
                            CallGameMenuSequence();
                        }
                        break;
                    case 2:
                        {
                            CallConsoleMessage("This has not been implemented yet!");
                            CallOptionalKeyMessage();
                        }
                        break;
                    case 3:
                        {
                            CallConsoleMessage("Exiting Program...");
                            CallOptionalKeyMessage();
                            exitApp = true;
                        }
                        break;
                }
            } while (!exitApp);
        }
        #region methods
        //Title Display
        static void CallTitleSequence()
        {
            Console.WriteLine("   ===============");
            Console.WriteLine(" ====  2 0 1 9  ====");
            Console.WriteLine("===== B I N I O =====");
            Console.WriteLine(" ====  2 0 1 9  ====");
            Console.WriteLine("   ===============");
            Console.WriteLine("Press any key to start!");
            CallUserKeyInput();
        }
        //Main Sequence Menu and Switch
        static int CallMenuSequence()
        {
            int choice = 0;
            do
            {
                DisplayMenu(1);
                switch (CallUserKeyInput())
                {
                    case '1':
                        {
                            choice = 1;
                        }break;
                    case '2':
                        {
                            choice = 2;
                        }break;
                    case '3':
                        {
                            bool exitConfirmed = CallExitValidator();
                            if (exitConfirmed)
                            {
                                choice = 3;
                            }
                            else
                            {
                                CallConsoleMessage("EXIT aborted");
                                CallOptionalKeyMessage();
                            }
                        }
                        break;
                    default:
                        {
                            CallConsoleMessage("ERROR! Please Choose from the Available Options!!");
                            CallOptionalKeyMessage();
                        }
                        break;
                }
            } while (choice == 0);
            return choice;
        }

        //Call Display Menu
        static void DisplayMenu(int menuID)
        {
            if(menuID == 1)
            {
                Console.Clear();
                Console.WriteLine("====================");
                Console.WriteLine("1. Start new Game.");
                Console.WriteLine("2. Get Game Info.");
                Console.WriteLine("3. Exit.");
                Console.WriteLine("====================");
                Console.WriteLine("Press a number!");
            }
            else if(menuID == 2)
            {
                Console.Clear();
                Console.WriteLine("====================");
                Console.WriteLine("1. Select Another Number.");
                Console.WriteLine("2. Display Selected Numbers.");
                Console.WriteLine("3. Display Remaining Numbers.");
                Console.WriteLine("4. Search Selected Numbers.");
                Console.WriteLine("5. Exit.");
                Console.WriteLine("====================");
                Console.WriteLine("Press a number!");
            }
        }

        //Game Sequence Menu and Switch
        static void CallGameMenuSequence()
        {
            bool exit = false;
            int [] orderedList = new int [99];
            int [] pulledList = new int [0];

            do
            {
                orderedList = PopulateArray(orderedList);
                DisplayMenu(2);
                switch (CallUserKeyInput())
                {
                    case '1':
                        {
                            SelectNewNumber(orderedList, pulledList);
                        }
                        break;
                    case '2':
                        {

                        }
                        break;
                    case '3':
                        {

                        }
                        break;
                    case '4':
                        {
                            SearchPulledNumbers(orderedList);
                        }
                        break;
                    case '5':
                        {
                            bool exitConfirmed = CallExitValidator();
                            if (exitConfirmed)
                            {
                                exit = true;
                            }
                            else
                            {
                                CallConsoleMessage("EXIT aborted");
                                CallOptionalKeyMessage();
                            }
                        }
                        break;
                    default:
                        {
                            CallConsoleMessage("ERROR! Please Choose from the Available Options!!");
                            CallOptionalKeyMessage();
                        }
                        break;
                }
            } while (exit == false);
        }
        
        //Pull/Select new Number
        static void SelectNewNumber(int [] orderedArray,int [] pulledArray)
        {
            Random randNum = new Random();
            int randomNum = randNum.Next(1, orderedArray.Length - 1);
            pulledArray[pulledArray.Length - 1] = orderedArray[randomNum];
        }

        //Search Numbers
        static void SearchPulledNumbers(int[] array)
        {
            bool exit = false;
            do
            {
                CallConsoleMessage("|Search any Number between 1 and 99!|Write 0 to Exit!|");
                int userOption = Convert.ToInt32(Console.ReadLine());
                if(userOption >= 1 && userOption <= 99)
                {
                    int pos = Array.BinarySearch(array, userOption);
                    if (pos >= 0)
                    {
                        CallConsoleMessage("SUCCESS!! The number " + userOption + " has been Pulled!!");
                    }
                    else
                    {
                        CallConsoleMessage("ERROR!! The number " + userOption + " has not been Pulled Yet!!");
                    }
                }
                else if(userOption == 0)
                {
                    CallConsoleMessage("Exiting to Main Menu!");
                    exit = true;
                }
                else
                {
                    CallConsoleMessage("ERROR! Choose from the available options.");
                }
                CallOptionalKeyMessage();
            } while (!exit);
        }

        //Array populator
        static int[] PopulateArray(int [] array)
        {
            for(int i = 0; i < array.Length; i++)
            {
                array[i] = i+1;
            }
            
            return array;
        }
        //Exit Validator
        static bool CallExitValidator()
        {
            bool chosen;
            bool exit = false;
            do
            {
                chosen = true;
                CallConsoleMessage("|Press Y to Exit|Press N to go back to Menu|");
                switch (CallUserKeyInput())
                {
                    case 'Y':
                        {
                            exit = true;
                        }break;
                    case 'y':
                        {
                            exit = true;
                        }break;
                    case 'N':
                        {
                            exit = false;
                        }break;
                    case 'n':
                        {
                            exit = false;
                        }break;
                    default:
                        {
                            CallConsoleMessage("ERROR! Choose from the available options.");
                            CallOptionalKeyMessage();
                            chosen = false;
                        }break;
                }
            } while (chosen == false);
            return exit;
        }

        //USER CHAR INPUT
        static char CallUserKeyInput()
        {
            return Console.ReadKey().KeyChar;
        }

        //USER STRING INPUT
        static string CallUserStringInput()
        {
            return Console.ReadLine();
        }
        
        //Factory Console Message
        static void CallConsoleMessage(string consoleMessage)
        {
            Console.Clear();
            Console.WriteLine("============================");
            Console.WriteLine(consoleMessage);
            Console.WriteLine("============================");
        }

        //OPTIONAL KEY MESSAGE
        static void CallOptionalKeyMessage()
        {
            Console.WriteLine("Press any key to Continue...");
            CallUserKeyInput();
            Console.Clear();
        }
        #endregion methods
    }
}
