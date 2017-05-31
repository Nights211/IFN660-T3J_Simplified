// This code was generated by the Gardens Point Parser Generator
// Copyright (c) Wayne Kelly, John Gough, QUT 2005-2014
// (see accompanying GPPGcopyright.rtf)

// GPPG version 1.5.2
// Machine:  RAGNOROS
// DateTime: 31/05/2017 12:29:26 PM
// UserName: Awal
// Input file <parser.y - 31/05/2017 12:29:26 PM>

// options: lines gplex

using System;
using System.Collections.Generic;
using System.CodeDom.Compiler;
using System.Globalization;
using System.Text;
using QUT.Gppg;
using GPLexTutorial.AST;

namespace GPLexTutorial
{
public enum Tokens {
    error=127,EOF=128,NUMBER=129,IDENT=130,IF=131,ELSE=132,
    INT=133,BOOL=134,ABSTRACT=135,OPERATOR=136,PUBLIC=137,CLASS=138,
    STATIC=139,VOID=140,WHILE=141,TRUE=142,FALSE=143};

public struct ValueType
#line 10 "parser.y"
{
	public Expression expr;
	public Statement stmt;
	public UnAnnType type;
	public List<Statement> stmts;


    
    public string binary; // seth   
	public string bol;//XinRu
	public bool boolAnswer;
	public string charValue;  //Boyu
	public string fnum; // shilpa
	public string hex; // seth
	public string hnum;  //shilpa
	public string name;
	public string nul; // Shashank
    public int num;
    public string oct; // seth
	public string operat; //Alex
	public string seperator; // frank
    public string strValue;  //Qianyu
	
	public CompilationUnit compilationUnit;
	public ClassModifier classModifier;
	public List<ClassModifier> classModifiers;
	public Expression expression;
	public List<Expression> expressions;
	public ExpressionStatement expressionStatement;
	public FormalParameter formalParameter;
	public List<FormalParameter> formalParameterList;	
	public IdentifierExpression identifierExpression;
	public ImportDeclaration importDeclaration;
	
	public MethodDeclaration methodDeclaration;
	
	public List<MethodDeclaration> methodDeclarations;
	public MethodHeader methodHeader;
	public MethodDeclarator methodDeclarator;

	public Modifier modifier;
	public List<Modifier> modifiers;

	public NormalClassDeclaration normalClassDeclaration;
	public PackageDeclaration packageDeclaration;
	public IntType IntType;
	public Result result;
	public Statement statement;
	public TypeDeclaration typeDeclaration;																		// follow this if you are doing $$
	public List<TypeDeclaration> typeDeclarations;																// follow this if you are doing $$	
	public List<Statement> statements;
	public UnAnnArrayType arType;
	public UnAnnType unannType;
	public VariableDeclaration variableDeclaration;
	public List<VariableDeclaration> variableDeclarations;
	public VariableModifier variableModifier;
	public List<VariableModifier> variableModifiers;	
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
  // Verbatim content from parser.y - 31/05/2017 12:29:26 PM
#line 6 "parser.y"
public static MethodDeclaration root;
#line default
  // End verbatim content from parser.y - 31/05/2017 12:29:26 PM

#pragma warning disable 649
  private static Dictionary<int, string> aliases;
#pragma warning restore 649
  private static Rule[] rules = new Rule[24];
  private static State[] states = new State[41];
  private static string[] nonTerms = new string[] {
      "CompilationUnit", "Expression", "Statement", "UnAnnType", "StatementList", 
      "Modifier", "Modifiers", "MethodDeclaration", "Program", "$accept", "ClassBody", 
      };

  static Parser() {
    states[0] = new State(-9,new int[]{-9,1,-1,3,-8,4,-7,5});
    states[1] = new State(new int[]{128,2});
    states[2] = new State(-1);
    states[3] = new State(-2);
    states[4] = new State(-3);
    states[5] = new State(new int[]{130,6,137,38,139,39,140,40},new int[]{-6,37});
    states[6] = new State(new int[]{40,7});
    states[7] = new State(new int[]{131,11,123,18,129,30,130,31,133,35,134,36},new int[]{-3,8,-2,22,-4,32});
    states[8] = new State(new int[]{41,9});
    states[9] = new State(new int[]{131,11,123,18,129,30,130,31,133,35,134,36},new int[]{-3,10,-2,22,-4,32});
    states[10] = new State(-4);
    states[11] = new State(new int[]{40,12});
    states[12] = new State(new int[]{129,30,130,31},new int[]{-2,13});
    states[13] = new State(new int[]{41,14,61,24,43,26,60,28});
    states[14] = new State(new int[]{131,11,123,18,129,30,130,31,133,35,134,36},new int[]{-3,15,-2,22,-4,32});
    states[15] = new State(new int[]{132,16});
    states[16] = new State(new int[]{131,11,123,18,129,30,130,31,133,35,134,36},new int[]{-3,17,-2,22,-4,32});
    states[17] = new State(-11);
    states[18] = new State(-18,new int[]{-5,19});
    states[19] = new State(new int[]{125,20,131,11,123,18,129,30,130,31,133,35,134,36},new int[]{-3,21,-2,22,-4,32});
    states[20] = new State(-12);
    states[21] = new State(-17);
    states[22] = new State(new int[]{59,23,61,24,43,26,60,28});
    states[23] = new State(-13);
    states[24] = new State(new int[]{129,30,130,31},new int[]{-2,25});
    states[25] = new State(new int[]{61,-21,43,26,60,28,59,-21,41,-21});
    states[26] = new State(new int[]{129,30,130,31},new int[]{-2,27});
    states[27] = new State(-22);
    states[28] = new State(new int[]{129,30,130,31},new int[]{-2,29});
    states[29] = new State(new int[]{61,-23,43,26,41,-23,59,-23});
    states[30] = new State(-19);
    states[31] = new State(-20);
    states[32] = new State(new int[]{130,33});
    states[33] = new State(new int[]{59,34});
    states[34] = new State(-14);
    states[35] = new State(-15);
    states[36] = new State(-16);
    states[37] = new State(-8);
    states[38] = new State(-5);
    states[39] = new State(-6);
    states[40] = new State(-7);

    for (int sNo = 0; sNo < states.Length; sNo++) states[sNo].number = sNo;

    rules[1] = new Rule(-10, new int[]{-9,128});
    rules[2] = new Rule(-9, new int[]{-1});
    rules[3] = new Rule(-1, new int[]{-8});
    rules[4] = new Rule(-8, new int[]{-7,130,40,-3,41,-3});
    rules[5] = new Rule(-6, new int[]{137});
    rules[6] = new Rule(-6, new int[]{139});
    rules[7] = new Rule(-6, new int[]{140});
    rules[8] = new Rule(-7, new int[]{-7,-6});
    rules[9] = new Rule(-7, new int[]{});
    rules[10] = new Rule(-11, new int[]{});
    rules[11] = new Rule(-3, new int[]{131,40,-2,41,-3,132,-3});
    rules[12] = new Rule(-3, new int[]{123,-5,125});
    rules[13] = new Rule(-3, new int[]{-2,59});
    rules[14] = new Rule(-3, new int[]{-4,130,59});
    rules[15] = new Rule(-4, new int[]{133});
    rules[16] = new Rule(-4, new int[]{134});
    rules[17] = new Rule(-5, new int[]{-5,-3});
    rules[18] = new Rule(-5, new int[]{});
    rules[19] = new Rule(-2, new int[]{129});
    rules[20] = new Rule(-2, new int[]{130});
    rules[21] = new Rule(-2, new int[]{-2,61,-2});
    rules[22] = new Rule(-2, new int[]{-2,43,-2});
    rules[23] = new Rule(-2, new int[]{-2,60,-2});
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
      case 3: // CompilationUnit -> MethodDeclaration
#line 98 "parser.y"
                         {root = ValueStack[ValueStack.Depth-1].methodDeclaration;}
#line default
        break;
      case 4: // MethodDeclaration -> Modifiers, IDENT, '(', Statement, ')', Statement
#line 103 "parser.y"
                                                   {CurrentSemanticValue.methodDeclaration = new MethodDeclaration(ValueStack[ValueStack.Depth-6].modifiers,ValueStack[ValueStack.Depth-5].name,ValueStack[ValueStack.Depth-3].stmt,ValueStack[ValueStack.Depth-1].stmt);}
#line default
        break;
      case 5: // Modifier -> PUBLIC
#line 107 "parser.y"
                     {CurrentSemanticValue.modifier = Modifier.PUBLIC;}
#line default
        break;
      case 6: // Modifier -> STATIC
#line 108 "parser.y"
                           {CurrentSemanticValue.modifier = Modifier.STATIC;}
#line default
        break;
      case 7: // Modifier -> VOID
#line 109 "parser.y"
                     {CurrentSemanticValue.modifier = Modifier.VOID;}
#line default
        break;
      case 8: // Modifiers -> Modifiers, Modifier
#line 113 "parser.y"
                           {CurrentSemanticValue.modifiers = ValueStack[ValueStack.Depth-2].modifiers; CurrentSemanticValue.modifiers.Add(ValueStack[ValueStack.Depth-1].modifier);}
#line default
        break;
      case 9: // Modifiers -> /* empty */
#line 114 "parser.y"
                         {CurrentSemanticValue.modifiers = new List<Modifier>();}
#line default
        break;
      case 11: // Statement -> IF, '(', Expression, ')', Statement, ELSE, Statement
#line 121 "parser.y"
                                                           { CurrentSemanticValue.stmt = new IfStatement(ValueStack[ValueStack.Depth-5].expr, ValueStack[ValueStack.Depth-3].stmt, ValueStack[ValueStack.Depth-1].stmt); }
#line default
        break;
      case 12: // Statement -> '{', StatementList, '}'
#line 122 "parser.y"
                                        { CurrentSemanticValue.stmt = new CompoundStatement(ValueStack[ValueStack.Depth-2].stmts);   }
#line default
        break;
      case 13: // Statement -> Expression, ';'
#line 123 "parser.y"
                             { CurrentSemanticValue.stmt = new ExpressionStatement(ValueStack[ValueStack.Depth-2].expr); }
#line default
        break;
      case 14: // Statement -> UnAnnType, IDENT, ';'
#line 124 "parser.y"
                                 { CurrentSemanticValue.stmt = new VariableDeclaration(ValueStack[ValueStack.Depth-3].type,ValueStack[ValueStack.Depth-2].name); }
#line default
        break;
      case 15: // UnAnnType -> INT
#line 127 "parser.y"
                            { CurrentSemanticValue.type = new IntType(); }
#line default
        break;
      case 16: // UnAnnType -> BOOL
#line 128 "parser.y"
                              { CurrentSemanticValue.type = new BoolType(); }
#line default
        break;
      case 17: // StatementList -> StatementList, Statement
#line 131 "parser.y"
                                                { CurrentSemanticValue.stmts = ValueStack[ValueStack.Depth-2].stmts; CurrentSemanticValue.stmts.Add(ValueStack[ValueStack.Depth-1].stmt);    }
#line default
        break;
      case 18: // StatementList -> /* empty */
#line 132 "parser.y"
                                    { CurrentSemanticValue.stmts = new List<Statement>(); }
#line default
        break;
      case 19: // Expression -> NUMBER
#line 135 "parser.y"
                              { CurrentSemanticValue.expr = new NumberExpression(ValueStack[ValueStack.Depth-1].num);         }
#line default
        break;
      case 20: // Expression -> IDENT
#line 136 "parser.y"
                             { CurrentSemanticValue.expr = new IdentifierExpression(ValueStack[ValueStack.Depth-1].name);     }
#line default
        break;
      case 21: // Expression -> Expression, '=', Expression
#line 137 "parser.y"
                                      { CurrentSemanticValue.expr = new AssignmentExpression(ValueStack[ValueStack.Depth-3].expr, ValueStack[ValueStack.Depth-1].expr); }
#line default
        break;
      case 22: // Expression -> Expression, '+', Expression
#line 138 "parser.y"
                                      { CurrentSemanticValue.expr = new BinaryExpression(ValueStack[ValueStack.Depth-3].expr,'+',ValueStack[ValueStack.Depth-1].expr);  }
#line default
        break;
      case 23: // Expression -> Expression, '<', Expression
#line 139 "parser.y"
                                      { CurrentSemanticValue.expr = new BinaryExpression(ValueStack[ValueStack.Depth-3].expr,'<',ValueStack[ValueStack.Depth-1].expr);  }
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

#line 143 "parser.y"

int yywrap()
{
    return 1;
}

public Parser(Scanner scanner) : base(scanner)
{
}
#line default
}
}
