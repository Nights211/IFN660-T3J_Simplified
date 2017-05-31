// This code was generated by the Gardens Point Parser Generator
// Copyright (c) Wayne Kelly, John Gough, QUT 2005-2014
// (see accompanying GPPGcopyright.rtf)

// GPPG version 1.5.2
// Machine:  RAGNOROS
// DateTime: 31/05/2017 6:30:21 PM
// UserName: Awal
// Input file <parser.y - 31/05/2017 6:27:50 PM>

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
  // Verbatim content from parser.y - 31/05/2017 6:27:50 PM
#line 6 "parser.y"
public static NormalClassDeclaration root;
#line default
  // End verbatim content from parser.y - 31/05/2017 6:27:50 PM

#pragma warning disable 649
  private static Dictionary<int, string> aliases;
#pragma warning restore 649
  private static Rule[] rules = new Rule[30];
  private static State[] states = new State[51];
  private static string[] nonTerms = new string[] {
      "CompilationUnit", "Expression", "Statement", "UnAnnType", "StatementList", 
      "Modifier", "Modifiers", "MethodDeclaration", "MethodDeclarations", "NormalClassDeclaration", 
      "FormalParameter", "FormalParameterList", "Program", "$accept", "ClassBody", 
      };

  static Parser() {
    states[0] = new State(-13,new int[]{-13,1,-1,3,-10,4,-7,5});
    states[1] = new State(new int[]{128,2});
    states[2] = new State(-1);
    states[3] = new State(-2);
    states[4] = new State(-3);
    states[5] = new State(new int[]{138,6,137,48,139,49,140,50},new int[]{-6,47});
    states[6] = new State(new int[]{130,7});
    states[7] = new State(new int[]{123,8});
    states[8] = new State(-7,new int[]{-9,9});
    states[9] = new State(new int[]{125,10,130,-13,137,-13,139,-13,140,-13},new int[]{-8,11,-7,12});
    states[10] = new State(-4);
    states[11] = new State(-6);
    states[12] = new State(new int[]{130,13,137,48,139,49,140,50},new int[]{-6,47});
    states[13] = new State(new int[]{40,14});
    states[14] = new State(-22,new int[]{-12,15});
    states[15] = new State(new int[]{41,16,133,42,134,43},new int[]{-11,44,-4,45});
    states[16] = new State(new int[]{131,18,123,25,129,37,130,38,133,42,134,43},new int[]{-3,17,-2,29,-4,39});
    states[17] = new State(-8);
    states[18] = new State(new int[]{40,19});
    states[19] = new State(new int[]{129,37,130,38},new int[]{-2,20});
    states[20] = new State(new int[]{41,21,61,31,43,33,60,35});
    states[21] = new State(new int[]{131,18,123,25,129,37,130,38,133,42,134,43},new int[]{-3,22,-2,29,-4,39});
    states[22] = new State(new int[]{132,23});
    states[23] = new State(new int[]{131,18,123,25,129,37,130,38,133,42,134,43},new int[]{-3,24,-2,29,-4,39});
    states[24] = new State(-14);
    states[25] = new State(-24,new int[]{-5,26});
    states[26] = new State(new int[]{125,27,131,18,123,25,129,37,130,38,133,42,134,43},new int[]{-3,28,-2,29,-4,39});
    states[27] = new State(-15);
    states[28] = new State(-23);
    states[29] = new State(new int[]{59,30,61,31,43,33,60,35});
    states[30] = new State(-16);
    states[31] = new State(new int[]{129,37,130,38},new int[]{-2,32});
    states[32] = new State(new int[]{61,-27,43,33,60,35,59,-27,41,-27});
    states[33] = new State(new int[]{129,37,130,38},new int[]{-2,34});
    states[34] = new State(-28);
    states[35] = new State(new int[]{129,37,130,38},new int[]{-2,36});
    states[36] = new State(new int[]{61,-29,43,33,41,-29,59,-29});
    states[37] = new State(-25);
    states[38] = new State(-26);
    states[39] = new State(new int[]{130,40});
    states[40] = new State(new int[]{59,41});
    states[41] = new State(-17);
    states[42] = new State(-18);
    states[43] = new State(-19);
    states[44] = new State(-21);
    states[45] = new State(new int[]{130,46});
    states[46] = new State(-20);
    states[47] = new State(-12);
    states[48] = new State(-9);
    states[49] = new State(-10);
    states[50] = new State(-11);

    for (int sNo = 0; sNo < states.Length; sNo++) states[sNo].number = sNo;

    rules[1] = new Rule(-14, new int[]{-13,128});
    rules[2] = new Rule(-13, new int[]{-1});
    rules[3] = new Rule(-1, new int[]{-10});
    rules[4] = new Rule(-10, new int[]{-7,138,130,123,-9,125});
    rules[5] = new Rule(-15, new int[]{});
    rules[6] = new Rule(-9, new int[]{-9,-8});
    rules[7] = new Rule(-9, new int[]{});
    rules[8] = new Rule(-8, new int[]{-7,130,40,-12,41,-3});
    rules[9] = new Rule(-6, new int[]{137});
    rules[10] = new Rule(-6, new int[]{139});
    rules[11] = new Rule(-6, new int[]{140});
    rules[12] = new Rule(-7, new int[]{-7,-6});
    rules[13] = new Rule(-7, new int[]{});
    rules[14] = new Rule(-3, new int[]{131,40,-2,41,-3,132,-3});
    rules[15] = new Rule(-3, new int[]{123,-5,125});
    rules[16] = new Rule(-3, new int[]{-2,59});
    rules[17] = new Rule(-3, new int[]{-4,130,59});
    rules[18] = new Rule(-4, new int[]{133});
    rules[19] = new Rule(-4, new int[]{134});
    rules[20] = new Rule(-11, new int[]{-4,130});
    rules[21] = new Rule(-12, new int[]{-12,-11});
    rules[22] = new Rule(-12, new int[]{});
    rules[23] = new Rule(-5, new int[]{-5,-3});
    rules[24] = new Rule(-5, new int[]{});
    rules[25] = new Rule(-2, new int[]{129});
    rules[26] = new Rule(-2, new int[]{130});
    rules[27] = new Rule(-2, new int[]{-2,61,-2});
    rules[28] = new Rule(-2, new int[]{-2,43,-2});
    rules[29] = new Rule(-2, new int[]{-2,60,-2});
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
      case 3: // CompilationUnit -> NormalClassDeclaration
#line 111 "parser.y"
                           {root = ValueStack[ValueStack.Depth-1].normalClassDeclaration;}
#line default
        break;
      case 4: // NormalClassDeclaration -> Modifiers, CLASS, IDENT, '{', MethodDeclarations, '}'
#line 116 "parser.y"
                                                      { CurrentSemanticValue.normalClassDeclaration = new NormalClassDeclaration(ValueStack[ValueStack.Depth-6].modifiers, ValueStack[ValueStack.Depth-4].name, ValueStack[ValueStack.Depth-2].methodDeclarations);}
#line default
        break;
      case 6: // MethodDeclarations -> MethodDeclarations, MethodDeclaration
#line 124 "parser.y"
                                            { CurrentSemanticValue.methodDeclarations = ValueStack[ValueStack.Depth-2].methodDeclarations; CurrentSemanticValue.methodDeclarations.Add(ValueStack[ValueStack.Depth-1].methodDeclaration);}
#line default
        break;
      case 7: // MethodDeclarations -> /* empty */
#line 125 "parser.y"
                            { CurrentSemanticValue.methodDeclarations = new List<MethodDeclaration>(); }
#line default
        break;
      case 8: // MethodDeclaration -> Modifiers, IDENT, '(', FormalParameterList, ')', Statement
#line 131 "parser.y"
                                                             { CurrentSemanticValue.methodDeclaration = new MethodDeclaration(ValueStack[ValueStack.Depth-6].modifiers,ValueStack[ValueStack.Depth-5].name,ValueStack[ValueStack.Depth-3].formalParameterList,ValueStack[ValueStack.Depth-1].stmt);}
#line default
        break;
      case 9: // Modifier -> PUBLIC
#line 137 "parser.y"
                     {CurrentSemanticValue.modifier = Modifier.PUBLIC;}
#line default
        break;
      case 10: // Modifier -> STATIC
#line 138 "parser.y"
                           {CurrentSemanticValue.modifier = Modifier.STATIC;}
#line default
        break;
      case 11: // Modifier -> VOID
#line 139 "parser.y"
                     {CurrentSemanticValue.modifier = Modifier.VOID;}
#line default
        break;
      case 12: // Modifiers -> Modifiers, Modifier
#line 143 "parser.y"
                           {CurrentSemanticValue.modifiers = ValueStack[ValueStack.Depth-2].modifiers; CurrentSemanticValue.modifiers.Add(ValueStack[ValueStack.Depth-1].modifier);}
#line default
        break;
      case 13: // Modifiers -> /* empty */
#line 144 "parser.y"
                      {CurrentSemanticValue.modifiers = new List<Modifier>();}
#line default
        break;
      case 14: // Statement -> IF, '(', Expression, ')', Statement, ELSE, Statement
#line 148 "parser.y"
                                                           { CurrentSemanticValue.stmt = new IfStatement(ValueStack[ValueStack.Depth-5].expr, ValueStack[ValueStack.Depth-3].stmt, ValueStack[ValueStack.Depth-1].stmt); }
#line default
        break;
      case 15: // Statement -> '{', StatementList, '}'
#line 149 "parser.y"
                                        { CurrentSemanticValue.stmt = new CompoundStatement(ValueStack[ValueStack.Depth-2].stmts);   }
#line default
        break;
      case 16: // Statement -> Expression, ';'
#line 150 "parser.y"
                             { CurrentSemanticValue.stmt = new ExpressionStatement(ValueStack[ValueStack.Depth-2].expr); }
#line default
        break;
      case 17: // Statement -> UnAnnType, IDENT, ';'
#line 151 "parser.y"
                                 { CurrentSemanticValue.stmt = new VariableDeclaration(ValueStack[ValueStack.Depth-3].type,ValueStack[ValueStack.Depth-2].name); }
#line default
        break;
      case 18: // UnAnnType -> INT
#line 156 "parser.y"
                            { CurrentSemanticValue.type = new IntType(); }
#line default
        break;
      case 19: // UnAnnType -> BOOL
#line 157 "parser.y"
                              { CurrentSemanticValue.type = new BoolType(); }
#line default
        break;
      case 20: // FormalParameter -> UnAnnType, IDENT
#line 161 "parser.y"
                      {CurrentSemanticValue.formalParameter = new FormalParameter(ValueStack[ValueStack.Depth-2].type, ValueStack[ValueStack.Depth-1].name);}
#line default
        break;
      case 21: // FormalParameterList -> FormalParameterList, FormalParameter
#line 165 "parser.y"
                                              { CurrentSemanticValue.formalParameterList = ValueStack[ValueStack.Depth-2].formalParameterList; CurrentSemanticValue.formalParameterList.Add(ValueStack[ValueStack.Depth-1].formalParameter); }
#line default
        break;
      case 22: // FormalParameterList -> /* empty */
#line 166 "parser.y"
                                  { CurrentSemanticValue.formalParameterList = new List<FormalParameter>(); }
#line default
        break;
      case 23: // StatementList -> StatementList, Statement
#line 170 "parser.y"
                                                { CurrentSemanticValue.stmts = ValueStack[ValueStack.Depth-2].stmts; CurrentSemanticValue.stmts.Add(ValueStack[ValueStack.Depth-1].stmt);    }
#line default
        break;
      case 24: // StatementList -> /* empty */
#line 171 "parser.y"
                                    { CurrentSemanticValue.stmts = new List<Statement>(); }
#line default
        break;
      case 25: // Expression -> NUMBER
#line 174 "parser.y"
                              { CurrentSemanticValue.expr = new NumberExpression(ValueStack[ValueStack.Depth-1].num);         }
#line default
        break;
      case 26: // Expression -> IDENT
#line 175 "parser.y"
                             { CurrentSemanticValue.expr = new IdentifierExpression(ValueStack[ValueStack.Depth-1].name);     }
#line default
        break;
      case 27: // Expression -> Expression, '=', Expression
#line 176 "parser.y"
                                      { CurrentSemanticValue.expr = new AssignmentExpression(ValueStack[ValueStack.Depth-3].expr, ValueStack[ValueStack.Depth-1].expr); }
#line default
        break;
      case 28: // Expression -> Expression, '+', Expression
#line 177 "parser.y"
                                      { CurrentSemanticValue.expr = new BinaryExpression(ValueStack[ValueStack.Depth-3].expr,'+',ValueStack[ValueStack.Depth-1].expr);  }
#line default
        break;
      case 29: // Expression -> Expression, '<', Expression
#line 178 "parser.y"
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

#line 182 "parser.y"

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
