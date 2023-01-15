using Anagram.App;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Anagram.MSTest
{
    [TestClass]
    public class AnagramMSTest
    {
        public AnagramManager anagram;

        public AnagramMSTest()
        {
            // Specify the input file path and name.
            //
            string filePath = Directory.GetCurrentDirectory() + "\\";
            string inputFileName = "InputAnagramFile.txt";

            // Specify the separator of word.
            //
            char separator = ' ';

            anagram = new AnagramManager(filePath, inputFileName, separator);
            anagram.MatchAnagrams();
        }

        [TestMethod]
        public void IsFilePathAssignedCorrectly_ShouldReturnTrue()
        {
            Assert.IsTrue(anagram._filePath != "");
        }

        [TestMethod]
        [DataRow("lisa")]
        [DataRow("AnnAn")]
        [DataRow("list")]
        [DataRow("silence")]
        [DataRow("احمدی")]
        [DataRow("عمید")]
        public void IsThereAnagramForUserWord_ShouldReturnEmpty(string word)
        {
            string userAnagram = anagram.GetAnagramsForEnteredValue(word);

            Assert.IsTrue(userAnagram == "");
        }

        [TestMethod]
        [DataRow("anan")]
        [DataRow("AnnA")]
        [DataRow("listen")]
        [DataRow("silent")]
        [DataRow("حمید")]
        [DataRow("احمد")]
        public void IsThereAnagramForUserWord_ShouldReturnValue(string word)
        {
            string userAnagram = anagram.GetAnagramsForEnteredValue(word);

            Assert.IsTrue(userAnagram != "");
        }

        [TestMethod]
        [DataRow(14)]
        [DataRow(1200)]
        [DataRow(720)]
        public void IsThereFactorialRootForUserNumber_ShouldReturnFalse(long number)
        {
            long factorialRoot;
            bool result = anagram.CheckFactorialRoot(number, out factorialRoot);

            Assert.IsFalse(result);
        }

        [TestMethod]
        [DataRow(14)]
        [DataRow(1200)]
        public void IsThereFactorialRootForUserNumber_ShouldReturnZeroForFactorialRoot(long number)
        {
            long factorialRoot;
            bool result = anagram.CheckFactorialRoot(number, out factorialRoot);

            Assert.IsTrue(factorialRoot == 0);
        }


        [TestMethod]
        [DataRow(720)]
        public void IsThereFactorialRootForUserNumber_ShouldReturnFalseAndGreaterThanZeroForFactorialRoot(long number)
        {
            long factorialRoot;
            bool result = anagram.CheckFactorialRoot(number, out factorialRoot);

            Assert.IsTrue(!result && factorialRoot == 6);
        }

        [TestMethod]
        [DataRow(24)]
        [DataRow(120)]
        public void IsThereFactorialRootForUserNumber_ShouldReturnValue(long number)
        {
            long factorialRoot;
            bool result = anagram.CheckFactorialRoot(number, out factorialRoot);

            Assert.IsTrue(result && factorialRoot > 0);
        }
    }
}
