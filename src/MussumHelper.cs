using System;
using System.Linq;
using System.Text;
using MussumIpsum.Enum;

namespace MussumIpsum
{
    public static class MussumHelper
    {
        private static Random _random = new Random();
        
        // defaults
        private const UnitType DEFAULT_TYPE = UnitType.Paragraph;
        private const WordSize DEFAULT_SIZE = WordSize.Medium;

        // words
        private static string[] ShortWords
        {
            get
            {
                return new string[]
                {
                    "a", "ab", "ad", "an", "cus", "de", "do", "e", "ea", "est",
                    "et", "eu", "ex", "hic", "id", "iis", "in", "ita", "nam", "ne",
                    "non", "o", "qui", "quo", "se", "sed", "si", "te", "ubi", "ut"
                };
            }
        }

        private static string[] MediumWords
        {
            get
            {
                return new string[]
                {
                    "amet", "aliqua", "vidis", "vidis", "cillum", "culpa", "vidis",
                    "dolore", "duis", "elit", "enim", "eram", "esse", "fore",
                    "Mussum", "illum", "ipsum", "irure", "Mussum", "legam",
                    "lorem", "magna", "malis", "minim", "multos", "nisi",
                    "noster", "nulla", "quae", "quem", "quid", "quis", "quorum",
                    "sint", "summis", "sunt", "Sapien", "varias", "Mussum", "veniam"
                };
            }
        }

        private static string[] LongWords
        {
            get
            {
                return new string[]
                {
                    "admodum", "aliquip", "appellat", "arbitror", "cernantur",
                    "cacilds", "consequat", "cupidatat", "deserunt", "doctrina",
                    "eiusmod", "excepteur", "expetendis", "fabulas", "incididunt",
                    "incurreret", "ingeniis", "iudicem", "laboris", "laborum",
                    "litteris", "mandaremus", "mentitum", "nescius", "nostrud",
                    "occaecat", "officia", "cacilds", "pariatur", "delegadis",
                    "cacilds", "proident", "quamquam", "quibusdam", "senserit",
                    "singulis", "tempor", "ullamco", "vidisse", "voluptate"
                };
            }
        }

        private static string[] VeryLongWords
        {
            get
            {
                return new string[]
                {
                    "adipisicing", "arbitrantur", "cohaerescant", "comprehenderit",
                    "concursionibus", "coniunctione", "consectetur", "despicationes",
                    "distinguantur", "domesticarum", "efflorescere", "eruditionem",
                    "exquisitaque", "exercitation", "familiaritatem", "fidelissimae",
                    "firmissimum", "graviterque", "illustriora", "instituendarum",
                    "imitarentur", "philosophari", "praesentibus", "praetermissum",
                    "relinqueret", "reprehenderit", "sempiternum", "tractavissent",
                    "transferrem", "voluptatibus"
                };
            }
        }

        private static string[] AllWords
        {
            get
            {
                var allWords = new[] { ShortWords, MediumWords, LongWords, VeryLongWords };

                return allWords.SelectMany(array => array.Select(arr => arr)).ToArray();
            }
        }

        // pattern
        private static WordSize[][] FragmentPatterns
        {
            get
            {
                return new WordSize[][]
                {
                    // three words
                    new WordSize[] { WordSize.Short, WordSize.Medium, WordSize.Long },
                    new WordSize[] { WordSize.Short, WordSize.Medium, WordSize.VeryLong },
                    new WordSize[] { WordSize.Short, WordSize.Short, WordSize.VeryLong },
                    new WordSize[] { WordSize.Short, WordSize.Long, WordSize.VeryLong },
                    new WordSize[] { WordSize.Medium, WordSize.Long, WordSize.Long },
                    new WordSize[] { WordSize.Medium, WordSize.Long, WordSize.VeryLong },
                    new WordSize[] { WordSize.Medium, WordSize.Short, WordSize.Long },
                    new WordSize[] { WordSize.Long, WordSize.Short, WordSize.Medium },
                    new WordSize[] { WordSize.Long, WordSize.Short, WordSize.Long },
                    new WordSize[] { WordSize.Long, WordSize.Medium, WordSize.Long },

                    // four words
                    new WordSize[] { WordSize.Short, WordSize.Short, WordSize.Medium, WordSize.Long },
                    new WordSize[] { WordSize.Short, WordSize.Medium, WordSize.Short, WordSize.Medium },
                    new WordSize[] { WordSize.Short, WordSize.Medium, WordSize.Long, WordSize.Long },
                    new WordSize[] { WordSize.Short, WordSize.Medium, WordSize.Long, WordSize.VeryLong },
                    new WordSize[] { WordSize.Short, WordSize.Long, WordSize.Short, WordSize.Long },
                    new WordSize[] { WordSize.Medium, WordSize.Long, WordSize.Short, WordSize.Long },
                    new WordSize[] { WordSize.Medium, WordSize.Long, WordSize.Short, WordSize.VeryLong },
                    new WordSize[] { WordSize.Long, WordSize.Short, WordSize.Medium, WordSize.Long },
                    new WordSize[] { WordSize.Long, WordSize.Medium, WordSize.Long, WordSize.Long },
                    new WordSize[] { WordSize.Long, WordSize.VeryLong, WordSize.Short, WordSize.Long },

                    // five words
                    new WordSize[] { WordSize.Short, WordSize.Short, WordSize.Medium, WordSize.Medium, WordSize.Medium },
                    new WordSize[] { WordSize.Short, WordSize.Medium, WordSize.Medium, WordSize.Short, WordSize.Long },
                    new WordSize[] { WordSize.Short, WordSize.Medium, WordSize.Medium, WordSize.Medium, WordSize.Long },
                    new WordSize[] { WordSize.Medium, WordSize.Short, WordSize.Short, WordSize.Medium, WordSize.Long },
                    new WordSize[] { WordSize.Medium, WordSize.Short, WordSize.Long, WordSize.Short, WordSize.Medium },
                    new WordSize[] { WordSize.Medium, WordSize.Long, WordSize.Short, WordSize.Medium, WordSize.Medium },
                    new WordSize[] { WordSize.Medium, WordSize.VeryLong, WordSize.Long, WordSize.Medium, WordSize.Long },
                    new WordSize[] { WordSize.Long, WordSize.Medium, WordSize.Short, WordSize.Long, WordSize.VeryLong },
                    new WordSize[] { WordSize.Long, WordSize.Medium, WordSize.Medium, WordSize.Short, WordSize.Medium },
                    new WordSize[] { WordSize.Long, WordSize.Medium, WordSize.Medium, WordSize.Long, WordSize.Medium },
                };
            }
        }

        private static T GetRandomFromList<T>(T[] list)
        {
            return list[_random.Next(0, list.Length)];
        }

        private static string GetRandomWord(WordSize size)
        {
            string[] wordArray = null;

            switch (size)
            {
                case WordSize.Any:
                    wordArray = AllWords;
                    break;
                case WordSize.Short:
                    wordArray = ShortWords;
                    break;
                case WordSize.Medium:
                    wordArray = MediumWords;
                    break;
                case WordSize.Long:
                    wordArray = LongWords;
                    break;
                case WordSize.VeryLong:
                    wordArray = VeryLongWords;
                    break;
                default:
                    break;
            }

            return GetRandomFromList<string>(wordArray);
        }

        private static string GetSentenceConnector()
        {
            var result = new StringBuilder();

            if (_random.Next(0, 1) == 0)
            {
                result.Append(", ");
            }
            else
            {
                result.Append(" ");
                result.Append(GetRandomWord(WordSize.Short));
                result.Append(" ");
            }

            return result.ToString();
        }

        private static string GetRandomFragment()
        {
            var result = new StringBuilder();

            var pattern = GetRandomFromList(FragmentPatterns);

            foreach (var wordSize in pattern)
            {
                result.Append(" " + GetRandomWord(wordSize));
            }

            return result.ToString();
        }

        private static string GetRandomWords(int count)
        {
            var result = new StringBuilder();

            for (var i = 0; i < count; i++)
            {
                result.Append(" " + GetRandomWord(WordSize.Any));
            }

            return result.ToString();
        }

        private static string GetRandomSentence(WordSize size)
        {
            var result = new StringBuilder();

            switch (size)
            {
                case WordSize.Any:
                    var values = System.Enum.GetValues(typeof(WordSize)).Cast<WordSize>().ToArray();
                    var randomSize = GetRandomFromList<WordSize>(values);
                    result.Append(GetRandomSentence(randomSize));
                    break;
                case WordSize.Short:
                    result.Append(GetRandomFragment());
                    break;
                case WordSize.Medium:
                    result.Append(GetRandomSentence(WordSize.Short));
                    result.Append(GetSentenceConnector());
                    result.Append(GetRandomSentence(WordSize.Short));
                    break;
                case WordSize.Long:
                    result.Append(GetRandomSentence(WordSize.Medium));
                    result.Append(GetSentenceConnector());
                    result.Append(GetRandomSentence(WordSize.Medium));
                    break;
                case WordSize.VeryLong:
                    result.Append(GetRandomSentence(WordSize.Long));
                    result.Append(GetSentenceConnector());
                    result.Append(GetRandomSentence(WordSize.Long));
                    break;
            }

            return result.ToString();
        }

        public static string GetRandomSentences(WordSize size, int count)
        {
            var result = new StringBuilder();

            for (var i = 0; i < count; i++)
            {
                var sentence = GetRandomSentence(size);
                sentence = sentence.First().ToString().ToUpper() + sentence.Substring(1) + ". ";
                result.Append(sentence.Trim());
                result.Append("\n\n");
            }

            return result.ToString().Trim();
        }
    }
}