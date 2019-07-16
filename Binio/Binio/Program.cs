using System;
using System.Collections.Generic;
using System.Linq;

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
            List<Number> orderedList = new List<Number>();
            List<Number> pulledList = new List<Number>();
            orderedList = PopulateArray(orderedList);
            do
            {
                DisplayMenu(2);
                switch (CallUserKeyInput())
                {
                    case '1':
                        {
                            if (orderedList != null)
                            {
                                CallConsoleMessage("Selected New Number...");
                                int selectedNum = PullNewNumber(orderedList, pulledList);
                                Console.WriteLine("The new Number is : " + selectedNum);
                                CallOptionalKeyMessage();
                            }
                            else
                            {
                                CallConsoleMessage("ERROR!! All numbers have been pulled!!");
                                CallOptionalKeyMessage();
                            }
                        }
                        break;
                    case '2':
                        {
                            pulledList = pulledList.OrderBy(number => number.NumData).ToList();
                        }
                        break;
                    case '3':
                        {
                            orderedList = orderedList.OrderBy(number => number.NumData).ToList();
                            int start = 1;
                            for(int i = 0;i < orderedList.Count; i++)
                            {
                                Console.WriteLine("===================================");
                                Console.WriteLine("| " + orderedList[i].ToString() + "| ");
                                if ((i + 3) <= orderedList.Count)
                                {
                                    Console.Write(orderedList[i + 3].ToString() + "| ");
                                    i += 3;
                                }
                                else
                                if ((i + 2) <= orderedList.Count)
                                {
                                    Console.Write(orderedList[i + 2].ToString() + "| ");
                                }
                                else
                                    if ((i + 1) <= orderedList.Count)
                                {
                                    Console.Write(orderedList[i + 1].ToString() + "| ");
                                }
                            }
                            CallOptionalKeyMessage();
                        }
                        break;
                    case '4':
                        {
                            SearchPulledNumbers(pulledList);
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
        static int PullNewNumber(List<Number> orderedArray,List<Number> pulledArray)
        {
            Random randNum = new Random();
            int randomNum = randNum.Next(1, orderedArray.Count - 1);

            Number tempNum = orderedArray[randomNum];
            tempNum.Pulled = true;

            pulledArray.Add(tempNum);
            orderedArray.RemoveAt(randomNum);
            return tempNum.NumData;
        }

        //Search Numbers
        static void SearchPulledNumbers(List<Number> pulledList)
        {
            bool exit = false;
            do
            {
                pulledList = pulledList.OrderBy(number => number.NumData).ToList();
                CallConsoleMessage("|Search any Number between 1 and 99!|Write 0 to Exit!|");
                int userOption = Convert.ToInt32(Console.ReadLine());
                if(userOption >= 1 && userOption <= 99)
                {
                    Number result = pulledList.Find(x => x.NumData == userOption);

                    if (result == null)
                    {
                        CallConsoleMessage("ERROR!! Number has not been Pulled yet!!");
                    }
                    else
                    {
                        CallConsoleMessage("SUCCESS!! Number has been Pulled!!");
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
        static List<Number> PopulateArray(List<Number> orderedList)
        {
            for(int i = 0; i < 99; i++)
            {
                Number newNumber = new Number();
                newNumber.NumData = i + 1;
                newNumber.Pulled = false;
                orderedList.Add(newNumber);
            }
            
            return orderedList;
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
