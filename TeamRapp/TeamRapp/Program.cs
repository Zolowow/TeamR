using System;
using System.Net;
using System.Threading;

namespace TeamRapp
{
    class Program
    {
        static string text = null;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1 - Download file/text");
                Console.WriteLine("2 - Count number of letters");
                Console.WriteLine("3 - Count number of words");
                Console.WriteLine("4 - Count number of punctuation marks");
                Console.WriteLine("5 - Count number of sentences");
                Console.WriteLine("6 - Generate raport (A-Z)");
                Console.WriteLine("7 - Save statistics");
                Console.WriteLine("8 - Exit");

                int userInput = Convert.ToInt32(Console.ReadLine());
                if (text == null && userInput != 1)
                {
                    ErrorMessage();
                }
                else
                {
                    MenuSelection(userInput);
                }

                Console.Clear();
            }
        }

        private static void MenuSelection(int userInput)
        {
            switch (userInput)
            {
                case 1:
                    {
                        string path = @"https://s3.zylowski.net/public/input/4.txt";

                        WebClient client = new WebClient();
                        text = client.DownloadString(path);
                        if (text != null)
                        {
                            ErrorMessage("The file has been loaded!");
                        }
                        else
                        {
                            ErrorMessage("Something went wrong, try again.");
                        }
                    }
                    break;
                case 2:
                    {
                        ErrorMessage($"Number of letters {text.Length}");
                    }
                    break;
                case 3:
                    {
                        //Count number of words
                    }
                    break;
                case 4:
                    {
                        //Count number of punctuation marks
                    }
                    break;
                case 5:
                    {
                        //Count number of sentences
                    }
                    break;
                case 6:
                    {
                        //Generate raport (A-Z)
                    }
                    break;
                case 7:
                    {
                        //Save statistics
                    }
                    break;
                case 8:
                    {
                        //Exit
                    }
                    break;

            }
        }

        private static void ErrorMessage()
        {
            Console.Clear();
            Console.WriteLine("You have no file load! Please load the file first.");
            Thread.Sleep(3000);
            Console.Clear();
        }

        private static void ErrorMessage(string message)
        {
            Console.Clear();
            Console.WriteLine(message);
            Thread.Sleep(3000);
            Console.Clear();
        }
    }

}
