using BuildFS.SyntaxTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildFS.Generators
{
    public class PrettyPrintGenerator : ISyntaxNodeVisitor
    {
        private int _currentIndent;

        public void Visit(LineNode lineNode)
        {
            _currentIndent = 0;
            lineNode.Indents?.Accept(this);
            lineNode.Names?.Accept(this);
        }

        public void Visit(IndentsNode indentsNode)
        {
            if (indentsNode != null)
            {
                _currentIndent = indentsNode.IndentNodes.Count();
            }
            else
            {
                _currentIndent = 0;
            }
        }

        public void Visit(IndentNode indentNode)
        {
            // empty
        }

        public void Visit(NamesNode namesNode)
        {
            var name = namesNode.NameNodes.First().Name;
            var extensions = namesNode.NameNodes.Skip(1).Select(t => t.Name).ToList();

            for (int i = 0; i < _currentIndent; i++)
            {
                Console.Write('.');
            }
            Console.Write(name);

            if (extensions.Any())
            {
                Console.Write($" ({string.Join(",", extensions)})");
            }

            Console.WriteLine();
        }

        public void Visit(NameNode nameNode)
        {
            // empty
        }
    }
}
