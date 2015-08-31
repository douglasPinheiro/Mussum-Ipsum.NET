using System.Text;
using MussumIpsum.App.Auxiliary;
using MussumIpsum.Enum;

namespace MussumIpsum
{
    public static class MussumGenerator
    {
        public static string GetRandomParagraphs(ParagraphSize size, int count)
        {
            var result = new StringBuilder();

            for (var i = 0; i < count; i++)
            {
                var paragraph = Paragraphs.GetRandomParagraph(size);
                result.Append(paragraph.Trim() + "\n\n");
            }

            return result.ToString().Trim();
        }
    }
}