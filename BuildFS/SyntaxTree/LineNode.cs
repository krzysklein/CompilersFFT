using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildFS.SyntaxTree
{
    public class LineNode : SyntaxNodeBase
    {
        public IndentsNode Indents { get; private set; }
        public NamesNode Names { get; private set; }

        public LineNode(IndentsNode indents, NamesNode names)
        {
            Indents = indents;
            Names = names;
        }

        public override void Accept(ISyntaxNodeVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class IndentsNode : SyntaxNodeBase
    {
        private List<IndentNode> _indentNodes;

        public IReadOnlyList<IndentNode> IndentNodes => _indentNodes;

        public IndentsNode(IndentNode indentNode)
        {
            _indentNodes = new List<IndentNode>() { indentNode };
        }

        public IndentsNode AddIndentNode(IndentNode indentNode)
        {
            _indentNodes.Add(indentNode);
            return this;
        }

        public override void Accept(ISyntaxNodeVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class IndentNode : SyntaxNodeBase
    {
        public string Indent { get; private set; }

        public IndentNode(string indent)
        {
            Indent = indent;
        }

        public override void Accept(ISyntaxNodeVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class NamesNode : SyntaxNodeBase
    {
        private List<NameNode> _nameNodes;

        public IReadOnlyList<NameNode> NameNodes => _nameNodes;

        public NamesNode(NameNode nameNode)
        {
            _nameNodes = new List<NameNode>() { nameNode };
        }

        public NamesNode AddNameNode(NameNode nameNode)
        {
            _nameNodes.Add(nameNode);
            return this;
        }

        public override void Accept(ISyntaxNodeVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class NameNode : SyntaxNodeBase
    {
        public string Name { get; private set; }

        public NameNode(string name)
        {
            Name = name;
        }

        public override void Accept(ISyntaxNodeVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
