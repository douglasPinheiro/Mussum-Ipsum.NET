using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MussumIpsum.Run
{
    class Program
    {
        static void Main(string[] args)
        {
            var paragraph = MussumHelper.GetRandomParagraphs(ParagraphSize.Short, 1);
            Console.WriteLine(paragraph);
            Console.ReadKey();
        }
    }
}
