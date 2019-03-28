using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildFS.SyntaxTree
{
    public interface ISyntaxNodeVisitor
    {
        void Visit(LineNode lineNode);
        void Visit(IndentsNode indentsNode);
        void Visit(IndentNode indentNode);
        void Visit(NamesNode namesNode);
        void Visit(NameNode nameNode);
    }
}
