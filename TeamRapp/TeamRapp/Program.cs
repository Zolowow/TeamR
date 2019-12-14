using System;
using System.IO;
using System.Net;
using System.Threading;

namespace TeamRapp
{
    class Program
    {
        static string text = null;

        static int numberOfLetters = 0;
        static int numberOfWords = 0;
        static int punctuationMarks = 0;
        static int numberOfSentences = 0;

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

                if(userInput == 8)
                {
                    MenuSelection(userInput);
                }

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
                        Console.WriteLine("Wybierz plik wejściowy:");
                        Console.WriteLine("Pobrać plik z internetu? [T/N]");
                        string answer = Console.ReadLine();
                        if (answer == "T" || answer == "t")
                        {
                            Console.Clear();
                            Console.WriteLine("Podaj adres pliku:");
                            string path = Console.ReadLine();
                            WebClient client = new WebClient();
                            try
                            {
                                text = client.DownloadString(path.Normalize());
                            }
                            catch
                            {
                                ErrorMessage("Something went wrong, try again.");
                            }

                            if (text != null)
                            {
                                ErrorMessage("The file has been loaded!");
                            }
                        }
                        else if (answer == "N" || answer == "n")
                        {
                            Console.Clear();
                            Console.WriteLine("Podaj nazwę pliku:");
                            string file = Console.ReadLine();
                            using (StreamReader sr = new StreamReader(file))
                            {
                                text = sr.ReadToEnd();
                            }
                            if (text != null)
                            {
                                ErrorMessage("The file has been loaded!");
                            }
                            else
                            {
                                ErrorMessage("Something went wrong, try again.");
                            }
                        }
                    }
                    break;
                case 2:
                    {
                        numberOfLetters = text.Length;
                        ErrorMessage($"Number of letters {text.Length}");


                    }
                    break;
                case 3:
                    {
                        string[] textarray = text.Split(' ');
                        numberOfWords = textarray.Length;
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
                        punctuationMarks = countPuncMarks;
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
                        numberOfSentences = countSentences;
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
                        ErrorMessage("If you have not choose any other options the numbers can be 0");

                        using (StreamWriter writetext = new StreamWriter(@"statystyki.txt", false))
                        {
                            writetext.WriteLine($"Number of letters = {numberOfLetters}, \n" +
                                $"Number of words = {numberOfWords}, \n" +
                                $"Number of punctuation marks = {punctuationMarks}, \n" +
                                $"Number of sentences = {numberOfSentences}");
                        }

                        ErrorMessage("File successfully created!");
                    }
                    break;
                case 8:
                    {
                        File.Delete(@"statystyki.txt");
                        ErrorMessage("BYE BYE! Have a nice day!");
                        Environment.Exit(0);
                    }
                    break;
                default:
                    {
                        ErrorMessage("Wrong number, choose another number");
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
