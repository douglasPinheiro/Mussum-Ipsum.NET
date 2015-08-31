using System.Text;
using MussumIpsum.Enum;

namespace MussumIpsum.App.Auxiliary
{
    public class Fragments
    {
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

        public static string GetRandomFragment()
        {
            var result = new StringBuilder();

            var pattern = Utils.GetRandomFromList(FragmentPatterns);

            foreach (var wordSize in pattern)
            {
                result.Append(" " + Words.GetRandomWord(wordSize));
            }

            return result.ToString();
        }
    }
}