using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MussumIpsum.Enum;

namespace MussumIpsum.App.Auxiliary
{
    public static class Setences
    {
        public static string GetRandomSentence(WordSize size)
        {
            if (size == WordSize.Short) return Fragments.GetRandomFragment();

            if (size == WordSize.Any)
            {
                var randomSize = Utils.GetRandomEnumValue<WordSize>();
                return GetRandomSentence(randomSize);
            }

            return string.Concat(
                GetRandomSentence(Paragraphs.GetLessEnumParagraph(size)),
                Words.GetPreposition(),
                GetRandomSentence(Paragraphs.GetLessEnumParagraph(size)));
        }

        public static string GetRandomSentences(WordSize size, int count)
        {
            var result = new StringBuilder();

            for (var i = 0; i < count; i++)
            {
                var sentence = GetRandomSentence(size);
                sentence = string.Concat(sentence.First().ToString().ToUpper(), sentence.Substring(1), ". ");
                result.Append(sentence.Trim());
                result.Append("\n\n");
            }

            return result.ToString().Trim();
        }
    }
}
