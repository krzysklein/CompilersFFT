using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var reader = (args.Length > 0)
                ? new StreamReader(args[0]).BaseStream
                : new ConsoleInputStream();
            var lexer = new Lexer(reader);
            var parser = new Parser(lexer);

            parser.Parse();
        }
    }
}
