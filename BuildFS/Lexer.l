%namespace BuildFS
%scannertype Lexer

name					[a-zA-Z0-9\-.]+
indent					\t
newline					\n

%%

{name}					{ yylval.Name = yytext; return (int)Tokens.Name; }
{indent}				{ yylval.Indent += yytext; return (int)Tokens.Indent; }
{newline}				{ yylval.Indent = ""; return (int)Tokens.Newline; }

"|"                     { return '|'; }

%%

public override void yyerror(string format, params object[] args)
{
	Console.WriteLine("Error: Line {0}: {1}", yyline, format);
}
