using System.Linq;
using System.Text;
using MussumIpsum.App.Enum;

namespace MussumIpsum.App.Auxiliary
{
    public static class Words
    {
        public static string[] ShortWords
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

        public static string[] MediumWords
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

        public static string[] LongWords
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

        public static string[] VeryLongWords
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

        public static string[] AllWords
        {
            get
            {
                var allWords = new[] { ShortWords, MediumWords, LongWords, VeryLongWords };

                return allWords.SelectMany(array => array.Select(arr => arr)).ToArray();
            }
        }

        public static string GetPreposition()
        {
            var result = new StringBuilder();

            if (Utils.Random.Next(0, 1) == 0)
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

        public static string GetRandomWord(WordSize size)
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

            return Utils.GetRandomFromList<string>(wordArray);
        }

        public static string GetRandomWords(int count)
        {
            var result = new StringBuilder();

            for (var i = 0; i < count; i++)
            {
                result.Append(" " + GetRandomWord(WordSize.Any));
            }

            return result.ToString();
        }
    }
}
