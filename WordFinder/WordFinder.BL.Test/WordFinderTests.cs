using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace WordFinder.BL.Test
{
    public class WordFinderTests
    {
        [Fact]
        public void WordFinder_3x3_2_Words()
        {
            List<string> matrix = new()
            {
                "oso",
                "aos",
                "hlo"
            };
            string wordOne = "oso";
            string wordTwo = "sol";
            string wordThree = "osoa";
            List<string> words = new() { wordOne, wordTwo, wordThree };
            IEnumerable<string> result = new WordFinder(matrix).Find(words);

            Assert.NotNull(result);
            Assert.True(result.Count() == 2);
            Assert.Contains(wordOne, result);
            Assert.Contains(wordTwo, result);
            Assert.DoesNotContain(wordThree, result);
        }

        [Fact]
        public void WordFinder_5x5_3_Words()
        {
            List<string> matrix = new()
            {
                "abcdc",
                "fgwio",
                "chill",
                "pqnsd",
                "uvdxy"
            };
            string wordOne = "cold";
            string wordTwo = "wind";
            string wordThree = "chill";
            List<string> words = new() { wordOne, wordTwo, wordThree };
            IEnumerable<string> result = new WordFinder(matrix).Find(words);

            Assert.NotNull(result);
            Assert.True(result.Count() == 3);
            Assert.Contains(wordOne, result);
            Assert.Contains(wordTwo, result);
            Assert.Contains(wordThree, result);
        }

        [Fact]
        public void WordFinder_5x5_0_Words()
        {
            List<string> matrix = new()
            {
                "abcdc",
                "fgwio",
                "chill",
                "pqnsd",
                "uvdxy"
            };
            string wordOne = "fire";
            string wordTwo = "zero";
            string wordThree = "nice";
            List<string> words = new() { wordOne, wordTwo, wordThree };
            IEnumerable<string> result = new WordFinder(matrix).Find(words);

            Assert.NotNull(result);
            Assert.True(result.Count() == 0);
        }
    }
}
