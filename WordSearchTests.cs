namespace Lab2.Tests
{
    public class WordSearchTests
    {
        [SetUp]
        public void Setup()
        {
        }
        
        [Test]
        public void IsInputValid_ValidInput_ReturnsTrue()
        {
            string input = @"-text ""сsharp is the best language"" -word ""csharp""";

            bool result = WordSearch.IsInputValid(input);

            Assert.That(result, Is.True);
        }

        [Test]
        public void IsInputValid_InvalidInput_ReturnsFalse()
        {
            string input = @"-text сsharp is the best language -word csharp";

            bool result = WordSearch.IsInputValid(input);

            Assert.That(result, Is.False);        }

        [Test]
        public void ExtractText_ValidInput_ReturnsText()
        {
            string input = @"-text ""csharp is the best language"" -word ""hello""";

            string result = WordSearch.ExtractText(input);

            Assert.That(result, Is.EqualTo("csharp is the best language"));
        }

        [Test]
        public void ExtractWord_ValidInput_ReturnsWord()
        {
            string input = @"-text ""сsharp is the best language"" -word ""csharp""";

            string result = WordSearch.ExtractWord(input);

            Assert.That(result, Is.EqualTo("csharp"));
        }

        [Test]
        public void CountWordOccurrences_ValidInput_ReturnsCorrectCount()
        {
            string text = "csharp is the best language csharp";
            string word = "csharp";

            int result = WordSearch.CountWordOccurrences(text, word);

            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void CountWordOccurrences_WordNotInText_ReturnsZero()
        {

            string text = "сsharp is the best language";
            string word = "hi";

            int result = WordSearch.CountWordOccurrences(text, word);

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void CountWordOccurrences_WordAsSubstring_ReturnsZero()
        {

            string text = "сsharp is the best language";
            string word = "cshar";

            int result = WordSearch.CountWordOccurrences(text, word);

            Assert.That(result, Is.EqualTo(0));
        }
    }
}
