using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anagram.App
{
    public class AnagramManager
    {
        public string _filePath, _inputFileName;
        public char _seperatorChar;
        Dictionary<string, List<string>> anagrams = new Dictionary<string, List<string>>();
        List<long> numbers = new List<long>();

        public AnagramManager(string filePath, string inputFileName, char seperatorChar)
        {
            _filePath = filePath;
            _inputFileName = inputFileName;
            _seperatorChar = seperatorChar;
        }

        public void MatchAnagrams()
        {
            ReadInputFile();
            WriteToFile();
        }

        private void ReadInputFile()
        {
            string inputFile = _filePath + _inputFileName;
            long itemNum = 0;

            string fileString = File.ReadAllText(inputFile);

            var arrayString = fileString.Split(_seperatorChar);
            foreach (var item in arrayString)
            {
                Int64.TryParse(item, out itemNum);

                if (itemNum > 0)
                {
                    if (!(numbers.Find(i => i == itemNum) > 0))
                        numbers.Add(itemNum);
                }
                else
                {
                    string itemSortedString = GetSortedValue(item);

                    if (!anagrams.ContainsKey(itemSortedString))
                        anagrams[itemSortedString] = new List<string>();

                    if (anagrams[itemSortedString].Find(i => i.ToLower() == item.ToLower()) is null)
                        anagrams[itemSortedString].Add(item);
                }
            }
        }

        private string GetSortedValue(string str)
        {

            var itemArray = str.ToUpper().ToCharArray();
            Array.Sort(itemArray);

            return new string(itemArray);
        }

        private void WriteToFile()
        {
            string outputFile = _filePath + _inputFileName + ".Output.txt";

            File.Delete(outputFile);
            var fileOutput = File.OpenWrite(outputFile);

            foreach (var (key, value) in anagrams)
            {
                foreach (var item in value)
                {
                    var binaryItem = Encoding.UTF8.GetBytes($"{item} | ");
                    fileOutput.Write(binaryItem);
                }

                fileOutput.Write(Encoding.UTF8.GetBytes("\r\n\r\n"));
            }

            fileOutput.Close();
            fileOutput.Dispose();
        }

        public string GetAnagramsForEnteredValue(string userWord)
        {
            string result = "";


            string itemSortedString = GetSortedValue(userWord);

            if (anagrams.ContainsKey(itemSortedString))
            {
                List<string> res = new List<string>();
                res = anagrams[itemSortedString];

                if (anagrams[itemSortedString].Find(i => i.ToLower() == userWord.ToLower()) is null)
                    anagrams[itemSortedString].Add(userWord);

                foreach (var r in res)
                {
                    result += $"{r} | ";
                }
            }

            return result;
        }

        public bool CheckFactorialRoot(long userNum, out long factorialRoot)
        {
            bool result = false;
            long userNumRoot;
            userNumRoot = CalculateFactorialRoot(userNum);
            if (userNumRoot > 0 && (numbers.Find(i => i == userNumRoot) > 0))
                result = true;

            factorialRoot = userNumRoot;
            return result;
        }

        private long CalculateFactorialRoot(long userNum)
        {
            long result = 1;
            int i = 2;

            while (result < userNum)
            {
                result *= i;
                i++;
            }

            return (result == userNum) ? --i : 0;
        }
    }
}
