﻿using System;
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

                    }
                    break;
                case 2:
                    {

                    }
                    break;
                case 3:
                    {

                    }
                    break;
                case 4:
                    {

                    }
                    break;
                case 5:
                    {

                    }
                    break;
                case 6:
                    {

                    }
                    break;
                case 7:
                    {

                    }
                    break;
                case 8:
                    {

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
    }
}
