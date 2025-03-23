using Lab2;

namespace Lab2.Tests
{
    public class WordSearchTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Main_ReadsInputFromStdin()
        {
            string input = "-text \"csharp is the best language\" -word \"csharp\"";
            using (StringReader reader = new StringReader(input))
            {
                Console.SetIn(reader);

                using (StringWriter writer = new StringWriter())
                {
                    Console.SetOut(writer);

                    int exitCode = WordSearch.Main();

                    string output = writer.ToString().Trim();
                    Assert.That(output, Does.Contain("1"));
                    Assert.That(exitCode, Is.EqualTo(0));
                }
            }
        }

        [Test]
        public void Main_WritesResultToStdout()
        {
            string input = "-text \"csharp is the best language\" -word \"csharp\"";
            using (StringReader reader = new StringReader(input))
            {
                Console.SetIn(reader);

                using (StringWriter writer = new StringWriter())
                {
                    Console.SetOut(writer);

                    int exitCode = WordSearch.Main();

                    string output = writer.ToString().Trim();
                    Assert.That(output, Does.Contain("1"));
                    Assert.That(exitCode, Is.EqualTo(0));
                }
            }
        }

        
        public void Main_WritesErrorToStderr()
        {
            string input = "-text \"csharp is the best language\"";
            
            var originalIn = Console.In;
            var originalError = Console.Error;

            var reader = new StringReader(input);
            var errorWriter = new StringWriter();
            
            Console.SetIn(reader);
            Console.SetError(errorWriter);

            try
            {
                int exitCode = WordSearch.Main();
                
                string errorOutput = errorWriter.ToString().Trim();
                
                Console.WriteLine($"Error Output: {errorOutput}");
                Console.WriteLine($"Exit Code: {exitCode}");
                
                Assert.That(errorOutput, Does.Contain("Input Invalid"));
                Assert.That(exitCode, Is.Not.EqualTo(0));
            }
            finally
            {
                Console.SetIn(originalIn);
                Console.SetError(originalError);
            }
        }


        [Test]
        public void Main_ReturnsZeroExitCodeOnSuccess()
        {
            var originalIn = Console.In;
            var originalOut = Console.Out;
            var originalError = Console.Error;

            using (var inputReader = new StringReader("-text \"csharp is the best language\" -word \"csharp\""))
            using (var outputWriter = new StringWriter())
            using (var errorWriter = new StringWriter())
            {
                Console.SetIn(inputReader);
                Console.SetOut(outputWriter);
                Console.SetError(errorWriter);

                int exitCode = WordSearch.Main();

                Assert.That(exitCode, Is.EqualTo(0));
            }
            
            Console.SetIn(originalIn);
            Console.SetOut(originalOut);
            Console.SetError(originalError);
        }


        [Test]
        public void Main_ReturnsNonZeroExitCodeOnError()
        {
            var originalIn = Console.In;
            var originalOut = Console.Out;
            var originalError = Console.Error;

            using (var reader = new StringReader("-text \"csharp is the best language\""))
            using (var writer = new StringWriter())
            using (var errorWriter = new StringWriter())
            {
                Console.SetIn(reader);
                Console.SetOut(writer); 
                Console.SetError(errorWriter); 

                int exitCode = WordSearch.Main();

                Assert.That(exitCode, Is.Not.EqualTo(0));
            }
            
            Console.SetIn(originalIn);
            Console.SetOut(originalOut);
            Console.SetError(originalError);
        }


        [Test]
        public void IsInputValid_ValidInput_ReturnsTrue()
        {
            string input = @"-text ""csharp is the best language"" -word ""csharp""";
            bool result = WordSearch.IsInputValid(input);
            Assert.That(result, Is.True);
        }

        [Test]
        public void IsInputValid_InvalidInput_ReturnsFalse()
        {
            string input = @"-text csharp is the best language -word csharp";
            bool result = WordSearch.IsInputValid(input);
            Assert.That(result, Is.False);
        }

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
            string input = @"-text ""csharp is the best language"" -word ""csharp""";
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
            string text = "csharp is the best language";
            string word = "hi";
            int result = WordSearch.CountWordOccurrences(text, word);
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void CountWordOccurrences_WordAsSubstring_ReturnsZero()
        {
            string text = "csharp is the best language";
            string word = "cshar";
            int result = WordSearch.CountWordOccurrences(text, word);
            Assert.That(result, Is.EqualTo(0));
        }
    }
}

