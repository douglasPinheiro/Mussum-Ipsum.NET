using System;
using MussumIpsum.Enum;

namespace MussumIpsum.Run
{
    public class Program
    {
        static void Main(string[] args)
        {
            var paragraph = MussumGenerator.GetRandomParagraphs(ParagraphSize.Short, 1);
            Console.WriteLine(paragraph);
            Console.ReadKey();
        }
    }
}
