using MussumIpsum.App;
using MussumIpsum.App.Enum;
using System.Text.RegularExpressions;
using Xunit;

namespace MussumIpsum.Tests.Unit
{
    public class MussumGeneratorTest
    {
        [Theory()]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(10)]
        public void GetRandomParagraphs_TestNumberParagraphs(int number)
        {
            string text = MussumGenerator.GetRandomParagraphs(ParagraphSize.Any, number);

            int paragraphsNumberResult = Regex.Matches(text, "\n\n").Count + 1;

            Assert.Equal(paragraphsNumberResult, number);
        }
    }
}
