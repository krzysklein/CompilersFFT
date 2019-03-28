using BuildFS.Generators;
using BuildFS.SyntaxTree;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildFS
{
    class Program
    {
        static void Main(string[] args)
        {
            var filePath = @"..\..\Test.bfs";

            var reader = new StreamReader(filePath);
            var lexer = new Lexer(reader.BaseStream);
            var parser = new Parser(lexer);

            parser.Parse();

            ISyntaxNodeVisitor generator = new PrettyPrintGenerator();
            foreach (var line in parser.LineNodes)
            {
                line.Accept(generator);
            }

#if DEBUG

            Console.ReadKey();
#endif
        }
    }
}
