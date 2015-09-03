using System.Globalization;
using MussumIpsum.App.Enum;

namespace MussumIpsum.App.Auxiliary
{
    public static class Paragraphs
    {
        public static string GetRandomParagraph(ParagraphSize size)
        {
            switch (size)
            {
                case ParagraphSize.Short:
                    var paragraph = string.Empty;
                    var sentenceCount = Utils.Random.Next(3, 4);

                    for (var i = 0; i < sentenceCount; i++)
                    {
                        var sentence = Setences.GetRandomSentence(WordSize.Any);
                        paragraph += string.Concat(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(sentence), ". ");
                    }

                    return paragraph;
                case ParagraphSize.Medium:
                    return string.Concat(
                        GetRandomParagraph(ParagraphSize.Short),
                        GetRandomParagraph(ParagraphSize.Short));
                case ParagraphSize.Long:
                    return string.Concat(
                       GetRandomParagraph(ParagraphSize.Medium),
                       GetRandomParagraph(ParagraphSize.Medium));
                case ParagraphSize.VeryLong:
                    return string.Concat(
                       GetRandomParagraph(ParagraphSize.Long),
                       GetRandomParagraph(ParagraphSize.Long));
                case ParagraphSize.Any:
                default:
                    var randomSize = Utils.GetRandomEnumValue<ParagraphSize>();
                    return GetRandomParagraph(randomSize);
            }
        }

        public static WordSize GetLessEnumParagraph(WordSize size)
        {
            var newSize = WordSize.Short;

            switch (newSize)
            {
                case WordSize.Long:
                    newSize = WordSize.Medium;
                    break;
                case WordSize.VeryLong:
                    newSize = WordSize.Long;
                    break;
            }

            return newSize;
        }
    }
}
