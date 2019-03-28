using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildFS.SyntaxTree
{
    public abstract class SyntaxNodeBase
    {
        public abstract void Accept(ISyntaxNodeVisitor visitor);
    }
}
