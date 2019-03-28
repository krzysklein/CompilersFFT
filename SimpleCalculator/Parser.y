%namespace SimpleCalculator

%union { 
	public decimal DecimalValue; 
	public int IntValue;
	public string IdentifierValue; 
}

%token <IntValue> IntLiteral
%token <DecimalValue> DecimalLiteral
%token <IdentifierValue> Identifier

%type <DecimalValue> expression number decimal_literal
%type <IntValue> int_literal
%type <IdentifierValue> identifier

%left '+' '-'
%left '*' '/'
%left UMINUS

%start statements

%%

statements
	: /* empty */
	| statements statement ';'
	| statements error ';'
		{
			yyerrok();
		}
	;

statement
	: /* empty */
	| expression
		{
			System.Console.WriteLine($1);
		}
	| identifier '=' expression
		{
			WriteMemory($1, $3);
		}
	;

expression
	: '(' expression ')'
		{
			$$ = $2;
		}
    | expression '*' expression
        {
            $$ = $1 * $3;
        }
    | expression '/' expression
        {
            $$ = $1 / $3;
        }
    | expression '+' expression
        {
            $$ = $1 + $3;
        }
    | expression '-' expression
        {
            $$ = $1 - $3;
        }
    | '-' expression %prec UMINUS
        {
            $$ = -$2;
        }
    | identifier
		{
			$$ = ReadMemory($1);
		}
    | number
		{
			$$ = $1;
		}
    ;

number
	: int_literal  
		{ 
			$$ = (decimal)$1;
		}
    | decimal_literal
        { 
            $$ = $1;
        }
    ;

int_literal
	: IntLiteral
		{
			$$ = $1;
		}
	;

decimal_literal
	: DecimalLiteral
		{
			$$ = $1;
		}
	;

identifier
	: Identifier
		{
			$$ = $1;
		}
	;

%%

private Dictionary<string, decimal> _memory = new Dictionary<string, decimal>();

public Parser(Lexer lexer) : base(lexer)
{
}

public decimal ReadMemory(string identifier)
{
	if (_memory.ContainsKey(identifier)) {
		return _memory[identifier];
	} else {
		Console.WriteLine($"Error: Unrecognized variable '{identifier}'");
		return 0;
	}
}

public void WriteMemory(string identifier, decimal value)
{
	_memory[identifier] = value;
}
