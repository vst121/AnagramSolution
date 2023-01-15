using Anagram.App;
using NUnit.Framework;
using System.IO;

namespace Anagram.nUnitTest
{
    public class AnagramnUnitTest
    {
        public AnagramManager anagram;

        [SetUp]
        public void Setup()
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

        [Test]
        public void IsFilePathAssignedCorrectly_ShouldReturnTrue()
        {
            Assert.IsTrue(anagram._filePath != "");
        }


        [TestCase("lisa")]
        [TestCase("AnnAn")]
        [TestCase("list")]
        [TestCase("silence")]
        [TestCase("احمدی")]
        [TestCase("عمید")]
        public void IsThereAnagramForUserWord_ShouldReturnEmpty(string word)
        {
            string userAnagram = anagram.GetAnagramsForEnteredValue(word);

            Assert.IsTrue(userAnagram == "");
        }

        [TestCase("anan")]
        [TestCase("AnnA")]
        [TestCase("listen")]
        [TestCase("silent")]
        [TestCase("حمید")]
        [TestCase("احمد")]
        public void IsThereAnagramForUserWord_ShouldReturnValue(string word)
        {
            string userAnagram = anagram.GetAnagramsForEnteredValue(word);

            Assert.IsTrue(userAnagram != "");
        }

        [TestCase(14)]
        [TestCase(1200)]
        [TestCase(720)]
        public void IsThereFactorialRootForUserNumber_ShouldReturnFalse(long number)
        {
            long factorialRoot;
            bool result = anagram.CheckFactorialRoot(number, out factorialRoot);

            Assert.IsFalse(result);
        }

        [TestCase(14)]
        [TestCase(1200)]
        public void IsThereFactorialRootForUserNumber_ShouldReturnZeroForFactorialRoot(long number)
        {
            long factorialRoot;
            bool result = anagram.CheckFactorialRoot(number, out factorialRoot);

            Assert.IsTrue(factorialRoot == 0);
        }


        [TestCase(720)]
        public void IsThereFactorialRootForUserNumber_ShouldReturnFalseAndGreaterThanZeroForFactorialRoot(long number)
        {
            long factorialRoot;
            bool result = anagram.CheckFactorialRoot(number, out factorialRoot);

            Assert.IsTrue(!result && factorialRoot == 6);
        }

        [TestCase(24)]
        [TestCase(120)]
        public void IsThereFactorialRootForUserNumber_ShouldReturnValue(long number)
        {
            long factorialRoot;
            bool result = anagram.CheckFactorialRoot(number, out factorialRoot);

            Assert.IsTrue(result && factorialRoot > 0);
        }
    }
}