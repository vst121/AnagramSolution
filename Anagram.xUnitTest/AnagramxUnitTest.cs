using Anagram.App;
using System;
using System.IO;
using Xunit;

namespace Anagram.xUnitTest
{
    public class AnagramxUnitTest
    {
        public AnagramManager anagram;

       
        public AnagramxUnitTest()
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

        [Fact]
        public void IsFilePathAssignedCorrectly_ShouldReturnTrue()
        {
            Assert.True(anagram._filePath != "");
        }

        [Theory]
        [InlineData("lisa")]
        [InlineData("AnnAn")]
        [InlineData("list")]
        [InlineData("silence")]
        [InlineData("احمدی")]
        [InlineData("عمید")]
        public void IsThereAnagramForUserWord_ShouldReturnEmpty(string word)
        {
            string userAnagram = anagram.GetAnagramsForEnteredValue(word);

            Assert.True(userAnagram == "");
        }

        [Theory]
        [InlineData("anan")]
        [InlineData("AnnA")]
        [InlineData("listen")]
        [InlineData("silent")]
        [InlineData("حمید")]
        [InlineData("احمد")]
        public void IsThereAnagramForUserWord_ShouldReturnValue(string word)
        {
            string userAnagram = anagram.GetAnagramsForEnteredValue(word);

            Assert.True(userAnagram != "");
        }

        [Theory]
        [InlineData(14)]
        [InlineData(1200)]
        [InlineData(720)]
        public void IsThereFactorialRootForUserNumber_ShouldReturnFalse(long number)
        {
            long factorialRoot;
            bool result = anagram.CheckFactorialRoot(number, out factorialRoot);

            Assert.False(result);
        }

        [Theory]
        [InlineData(14)]
        [InlineData(1200)]
        public void IsThereFactorialRootForUserNumber_ShouldReturnZeroForFactorialRoot(long number)
        {
            long factorialRoot;
            bool result = anagram.CheckFactorialRoot(number, out factorialRoot);

            Assert.True(factorialRoot == 0);
        }

        [Theory]
        [InlineData(720)]
        public void IsThereFactorialRootForUserNumber_ShouldReturnFalseAndGreaterThanZeroForFactorialRoot(long number)
        {
            long factorialRoot;
            bool result = anagram.CheckFactorialRoot(number, out factorialRoot);

            Assert.True(!result && factorialRoot == 6);
        }

        [Theory]
        [InlineData(24)]
        [InlineData(120)]
        public void IsThereFactorialRootForUserNumber_ShouldReturnValue(long number)
        {
            long factorialRoot;
            bool result = anagram.CheckFactorialRoot(number, out factorialRoot);

            Assert.True(result && factorialRoot > 0);
        }

    }
}
