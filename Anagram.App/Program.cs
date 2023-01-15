using System;
using System.IO;

namespace Anagram.App
{
    class Program
    {
        static void Main(string[] args)
        {
            // Specify the input file path and name.
            string filePath = Directory.GetCurrentDirectory() + "\\";
            string inputFileName = "InputAnagramFile.txt";

            // Specify the separator of word.
            char separator = ' ';

            // Create a instance object of AnagramManager. 
            AnagramManager anagram = new AnagramManager(filePath, inputFileName, separator);

            // Get input file and write out file that contains all anagrams. 
            anagram.MatchAnagrams();

            // Let user enter an word and test is there any anagarms for it.
            Console.WriteLine("Enter your word to investigate its anagrams in input file: ");
            
            string userWord = Console.ReadLine();
            string userAnagram = "";

            userAnagram = anagram.GetAnagramsForEnteredValue(userWord);

            if(userAnagram != "")
                Console.WriteLine($"Anagrams: {userAnagram}");
            else
                Console.WriteLine($"No Anagrams.");

            Console.WriteLine("");


            // Let user enter a number and test for factorial root.
            Console.WriteLine("Enter a number to investigate if there is any n in the input file => n! = your number): ");
            string userNumStr = Console.ReadLine();
            long userNum, factorialRoot;
            
            long.TryParse(userNumStr, out userNum);

            if (userNum > 0)
            {
                string result; 

                if (anagram.CheckFactorialRoot(userNum, out factorialRoot))
                    result = $"Yes, {userNum} is the factorial of {factorialRoot} and it is in the file. ({factorialRoot}! = {userNum})";
                else
                    result = $"No, {userNum} is not Factorial (n!) of any numbers in the input file!";


                Console.WriteLine(result);
            }

            Console.ReadLine();
        }
    }
}
