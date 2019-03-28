%namespace BuildFS
%using BuildFS.SyntaxTree

%union { 
	public string Indent;
	public string Name;

	public LineNode LineNode;
	public IndentsNode IndentsNode;
	public IndentNode IndentNode;
	public NamesNode NamesNode;
	public NameNode NameNode;
}

%token <Name> Name
%token <Indent> Indent
%token Newline

%type <LineNode> line
%type <IndentsNode> indents_opt indents
%type <IndentNode> indent
%type <NamesNode> names
%type <NameNode> name

%start lines

%%

lines
	: /* empty */
	| lines line Newline
		{
			LineNodes.Add($2);
		}
	| lines error Newline
		{
			yyerrok();
		}
	;

line
	: indents_opt names
		{
			$$ = new LineNode($1, $2);
		}
	;

indents_opt
	: /* empty */
		{
			$$ = null;
		}
	| indents
		{
			$$ = $1;
		}
	;

indents
	: indents indent
		{
			$$ = $1.AddIndentNode($2);
		}
	| indent
		{
			$$ = new IndentsNode($1);
		}
	;

indent
	: Indent
		{
			$$ = new IndentNode($1);
		}
	;

names
	: names '|' name
		{
			$$ = $1.AddNameNode($3);
		}
	| name
		{
			$$ = new NamesNode($1);
		}
	;

name
	: Name
		{
			$$ = new NameNode($1);
		}
	;

%%

public List<LineNode> LineNodes;

public Parser(Lexer lexer) : base(lexer)
{
	LineNodes = new List<LineNode>();
}
