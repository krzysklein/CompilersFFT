%namespace SimpleCalculator
%scannertype Lexer

digit					[0-9]
alpha					[a-zA-Z]

int_literal				{digit}+
decimal_literal			{digit}+"."{digit}+
identifier				{alpha}({alpha}|{digit})*

%%

{int_literal}			{ yylval.IntValue = ParseInt(yytext); return (int)Tokens.IntLiteral; }
{decimal_literal}		{ yylval.DecimalValue = ParseDecimal(yytext); return (int)Tokens.DecimalLiteral; }
{identifier}            { yylval.IdentifierValue = ParseIdentifier(yytext); return (int)Tokens.Identifier; }

"("                     { return '('; }
")"                     { return ')'; }
"-"                     { return '-'; }
"+"                     { return '+'; }
"*"                     { return '*'; }
"/"                     { return '/'; }
"="                     { return '='; }
";"                     { return ';'; }

%%

public override void yyerror(string format, params object[] args)
{
	Console.WriteLine("Error: Line {0}: {1}", yyline, format);
}

public int ParseInt(string input)
{
	return int.Parse(input);
}

public decimal ParseDecimal(string input)
{
	return decimal.Parse(input, CultureInfo.InvariantCulture);
}

public string ParseIdentifier(string input)
{
	return input;
}
