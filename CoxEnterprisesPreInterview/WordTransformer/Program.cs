using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordTransformer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter A String: ");
            string input = Console.ReadLine();
            Console.WriteLine(WordTransformer.TransformString(input));
            Console.ReadKey();
        }
    }
}
