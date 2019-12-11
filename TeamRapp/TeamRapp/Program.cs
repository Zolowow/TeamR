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
                        string[] textarray = text.Split(' ');
                        ErrorMessage($"Number of words {textarray.Length}");
                    }
                    break;
                case 4:
                    {
                        int countPuncMarks = 0;
                        for (int i = 0; i < text.Length; i++)
                        {
                            if (text[i] == '!' || text[i] == ',' || text[i] == ';' || text[i] == '.' || text[i] == '?' || text[i] == '-' ||
                                       text[i] == '\'' || text[i] == '\"' || text[i] == ':')
                            {
                                countPuncMarks++;
                            }
                        }                        
                        ErrorMessage($"Number of punctuation marks {countPuncMarks}");
                    }
                    break;
                case 5:
                    {
                        int countSentences = 0;
                        for (int i = 0; i < text.Length; i++)
                        {
                            if (text[i] == '.')
                            {
                                countSentences++;
                            }
                        }                        
                        ErrorMessage($"Number of sentences {countSentences}");
                    }
                    break;
                case 6:
                    {
                        int[] c = new int[(int)char.MaxValue];
                        string letters = string.Empty;

                        foreach (char t in text)
                        {
                            c[(int)t]++;
                        }

                        for (int i = 0; i < (int)char.MaxValue; i++)
                        {
                            if (c[i] > 0 && char.IsLetterOrDigit((char)i))
                            {
                                letters += $"{(char)i}: {c[i]} \n";
                            }
                        }

                        Console.Clear();
                        Console.WriteLine(letters);
                        Console.WriteLine("Press any button to continue.");
                        Console.ReadKey();
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
