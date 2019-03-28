// This code was generated by the Gardens Point Parser Generator
// Copyright (c) Wayne Kelly, John Gough, QUT 2005-2014
// (see accompanying GPPGcopyright.rtf)

// GPPG version 1.5.2
// Machine:  LAPTOP-MSI
// DateTime: 28.03.2019 01:31:28
// UserName: krzys
// Input file <Parser.y - 26.03.2019 23:47:49>

// options: conflicts lines gplex conflicts

using System;
using System.Collections.Generic;
using System.CodeDom.Compiler;
using System.Globalization;
using System.Text;
using QUT.Gppg;
using BuildFS.SyntaxTree;

namespace BuildFS
{
public enum Tokens {error=126,
    EOF=127,Name=128,Indent=129,Newline=130};

public struct ValueType
#line 4 "Parser.y"
       { 
	public string Indent;
	public string Name;

	public LineNode LineNode;
	public IndentsNode IndentsNode;
	public IndentNode IndentNode;
	public NamesNode NamesNode;
	public NameNode NameNode;
}
#line default
// Abstract base class for GPLEX scanners
[GeneratedCodeAttribute( "Gardens Point Parser Generator", "1.5.2")]
public abstract class ScanBase : AbstractScanner<ValueType,LexLocation> {
  private LexLocation __yylloc = new LexLocation();
  public override LexLocation yylloc { get { return __yylloc; } set { __yylloc = value; } }
  protected virtual bool yywrap() { return true; }
}

// Utility class for encapsulating token information
[GeneratedCodeAttribute( "Gardens Point Parser Generator", "1.5.2")]
public class ScanObj {
  public int token;
  public ValueType yylval;
  public LexLocation yylloc;
  public ScanObj( int t, ValueType val, LexLocation loc ) {
    this.token = t; this.yylval = val; this.yylloc = loc;
  }
}

[GeneratedCodeAttribute( "Gardens Point Parser Generator", "1.5.2")]
public class Parser: ShiftReduceParser<ValueType, LexLocation>
{
#pragma warning disable 649
  private static Dictionary<int, string> aliases;
#pragma warning restore 649
  private static Rule[] rules = new Rule[14];
  private static State[] states = new State[17];
  private static string[] nonTerms = new string[] {
      "line", "indents_opt", "indents", "indent", "names", "name", "lines", "$accept", 
      };

  static Parser() {
    states[0] = new State(-2,new int[]{-7,1});
    states[1] = new State(new int[]{127,2,126,5,129,15,128,-6},new int[]{-1,3,-2,7,-3,13,-4,16});
    states[2] = new State(-1);
    states[3] = new State(new int[]{130,4});
    states[4] = new State(-3);
    states[5] = new State(new int[]{130,6});
    states[6] = new State(-4);
    states[7] = new State(new int[]{128,11},new int[]{-5,8,-6,12});
    states[8] = new State(new int[]{124,9,130,-5});
    states[9] = new State(new int[]{128,11},new int[]{-6,10});
    states[10] = new State(-11);
    states[11] = new State(-13);
    states[12] = new State(-12);
    states[13] = new State(new int[]{129,15,128,-7},new int[]{-4,14});
    states[14] = new State(-8);
    states[15] = new State(-10);
    states[16] = new State(-9);

    for (int sNo = 0; sNo < states.Length; sNo++) states[sNo].number = sNo;

    rules[1] = new Rule(-8, new int[]{-7,127});
    rules[2] = new Rule(-7, new int[]{});
    rules[3] = new Rule(-7, new int[]{-7,-1,130});
    rules[4] = new Rule(-7, new int[]{-7,126,130});
    rules[5] = new Rule(-1, new int[]{-2,-5});
    rules[6] = new Rule(-2, new int[]{});
    rules[7] = new Rule(-2, new int[]{-3});
    rules[8] = new Rule(-3, new int[]{-3,-4});
    rules[9] = new Rule(-3, new int[]{-4});
    rules[10] = new Rule(-4, new int[]{129});
    rules[11] = new Rule(-5, new int[]{-5,124,-6});
    rules[12] = new Rule(-5, new int[]{-6});
    rules[13] = new Rule(-6, new int[]{128});
  }

  protected override void Initialize() {
    this.InitSpecialTokens((int)Tokens.error, (int)Tokens.EOF);
    this.InitStates(states);
    this.InitRules(rules);
    this.InitNonTerminals(nonTerms);
  }

  protected override void DoAction(int action)
  {
#pragma warning disable 162, 1522
    switch (action)
    {
      case 3: // lines -> lines, line, Newline
#line 32 "Parser.y"
  {
			LineNodes.Add(ValueStack[ValueStack.Depth-2].LineNode);
		}
#line default
        break;
      case 4: // lines -> lines, error, Newline
#line 36 "Parser.y"
  {
			yyerrok();
		}
#line default
        break;
      case 5: // line -> indents_opt, names
#line 43 "Parser.y"
  {
			CurrentSemanticValue.LineNode = new LineNode(ValueStack[ValueStack.Depth-2].IndentsNode, ValueStack[ValueStack.Depth-1].NamesNode);
		}
#line default
        break;
      case 6: // indents_opt -> /* empty */
#line 50 "Parser.y"
  {
			CurrentSemanticValue.IndentsNode = null;
		}
#line default
        break;
      case 7: // indents_opt -> indents
#line 54 "Parser.y"
  {
			CurrentSemanticValue.IndentsNode = ValueStack[ValueStack.Depth-1].IndentsNode;
		}
#line default
        break;
      case 8: // indents -> indents, indent
#line 61 "Parser.y"
  {
			CurrentSemanticValue.IndentsNode = ValueStack[ValueStack.Depth-2].IndentsNode.AddIndentNode(ValueStack[ValueStack.Depth-1].IndentNode);
		}
#line default
        break;
      case 9: // indents -> indent
#line 65 "Parser.y"
  {
			CurrentSemanticValue.IndentsNode = new IndentsNode(ValueStack[ValueStack.Depth-1].IndentNode);
		}
#line default
        break;
      case 10: // indent -> Indent
#line 72 "Parser.y"
  {
			CurrentSemanticValue.IndentNode = new IndentNode(ValueStack[ValueStack.Depth-1].Indent);
		}
#line default
        break;
      case 11: // names -> names, '|', name
#line 79 "Parser.y"
  {
			CurrentSemanticValue.NamesNode = ValueStack[ValueStack.Depth-3].NamesNode.AddNameNode(ValueStack[ValueStack.Depth-1].NameNode);
		}
#line default
        break;
      case 12: // names -> name
#line 83 "Parser.y"
  {
			CurrentSemanticValue.NamesNode = new NamesNode(ValueStack[ValueStack.Depth-1].NameNode);
		}
#line default
        break;
      case 13: // name -> Name
#line 90 "Parser.y"
  {
			CurrentSemanticValue.NameNode = new NameNode(ValueStack[ValueStack.Depth-1].Name);
		}
#line default
        break;
    }
#pragma warning restore 162, 1522
  }

  protected override string TerminalToString(int terminal)
  {
    if (aliases != null && aliases.ContainsKey(terminal))
        return aliases[terminal];
    else if (((Tokens)terminal).ToString() != terminal.ToString(CultureInfo.InvariantCulture))
        return ((Tokens)terminal).ToString();
    else
        return CharToString((char)terminal);
  }

#line 96 "Parser.y"

public List<LineNode> LineNodes;

public Parser(Lexer lexer) : base(lexer)
{
	LineNodes = new List<LineNode>();
}
#line default
}
}
