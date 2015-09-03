using Microsoft.VisualStudio.TestTools.UnitTesting;
using MussumIpsum.App;
using MussumIpsum.App.Enum;
using System.Text.RegularExpressions;

namespace MussumIpsum.Tests.Unit
{
    [TestClass]
    public class MussumGeneratorTest
    {
        [TestMethod]
        public void GetRandomParagraphs_TestNumberParagraphs()
        {
            var paragraphsNumber = new int[] { 1, 3, 5, 8, 10 };

            foreach (var number in paragraphsNumber)
	        {
                string text = MussumGenerator.GetRandomParagraphs(ParagraphSize.Any, number);

                int paragraphsNumberResult = Regex.Matches(text, "\n\n").Count + 1;

                Assert.AreEqual(paragraphsNumberResult, number);
	        }
        }
    }
}
