// This code was generated by the Gardens Point Parser Generator
// Copyright (c) Wayne Kelly, John Gough, QUT 2005-2014
// (see accompanying GPPGcopyright.rtf)

// GPPG version 1.5.2
// Machine:  SHILPA
// DateTime: 6/4/2017 7:33:41 PM
// UserName: shilp
// Input file <parser.y - 6/4/2017 7:30:13 PM>

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
    error=127,EOF=128,NUMBER=129,IDENT=130,TRUE=131,FALSE=132,
    IF=133,ELSE=134,INT=135,BOOL=136,ABSTRACT=137,OPERATOR=138,
    PUBLIC=139,CLASS=140,STATIC=141,VOID=142,WHILE=143,DO=144,
    FOR=145,ENUM=146,INCREMENT_OPERATOR=147,DECREMENT_OPERATOR=148};

public struct ValueType
#line 10 "parser.y"
{
	public Expression expr;
	public Statement stmt;
	public UnAnnType type;
	public List<Statement> stmts;
	public bool boolAnswer;



    
    public string binary; // seth   
	public string bol;//XinRu
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
	
	public EnumDeclaration enumDeclaration;
	public EnumConstant enumConstant;

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
  // Verbatim content from parser.y - 6/4/2017 7:30:13 PM
#line 6 "parser.y"
public static CompilationUnit root;
#line default
  // End verbatim content from parser.y - 6/4/2017 7:30:13 PM

#pragma warning disable 649
  private static Dictionary<int, string> aliases;
#pragma warning restore 649
  private static Rule[] rules = new Rule[48];
  private static State[] states = new State[94];
  private static string[] nonTerms = new string[] {
      "CompilationUnit", "EnumDeclaration", "EnumConstant", "Expression", "Statement", 
      "UnAnnType", "StatementList", "Modifier", "Modifiers", "MethodDeclaration", 
      "MethodDeclarations", "NormalClassDeclaration", "TypeDeclaration", "ClassDeclaration", 
      "TypeDeclarations", "FormalParameter", "FormalParameterList", "Program", 
      "$accept", "ClassBody", };

  static Parser() {
    states[0] = new State(-5,new int[]{-18,1,-1,3,-15,4});
    states[1] = new State(new int[]{128,2});
    states[2] = new State(-1);
    states[3] = new State(-2);
    states[4] = new State(new int[]{128,-3,140,-20,146,-20,139,-20,141,-20,142,-20},new int[]{-13,5,-14,6,-12,7,-9,8,-2,93});
    states[5] = new State(-4);
    states[6] = new State(-6);
    states[7] = new State(-7);
    states[8] = new State(new int[]{140,9,146,86,139,83,141,84,142,85},new int[]{-8,82});
    states[9] = new State(new int[]{130,10});
    states[10] = new State(new int[]{123,11});
    states[11] = new State(-14,new int[]{-11,12});
    states[12] = new State(new int[]{125,13,130,-20,139,-20,141,-20,142,-20},new int[]{-10,14,-9,15});
    states[13] = new State(-11);
    states[14] = new State(-13);
    states[15] = new State(new int[]{130,16,139,83,141,84,142,85},new int[]{-8,82});
    states[16] = new State(new int[]{40,17});
    states[17] = new State(-32,new int[]{-17,18});
    states[18] = new State(new int[]{41,19,135,57,136,58},new int[]{-16,79,-6,80});
    states[19] = new State(new int[]{133,21,123,28,129,46,130,47,131,48,132,49,147,50,148,52,135,57,136,58,143,59,144,64,145,70},new int[]{-5,20,-4,32,-6,54});
    states[20] = new State(-15);
    states[21] = new State(new int[]{40,22});
    states[22] = new State(new int[]{129,46,130,47,131,48,132,49,147,50,148,52},new int[]{-4,23});
    states[23] = new State(new int[]{41,24,61,34,43,36,60,38,42,40,45,42,147,44,148,45});
    states[24] = new State(new int[]{133,21,123,28,129,46,130,47,131,48,132,49,147,50,148,52,135,57,136,58,143,59,144,64,145,70},new int[]{-5,25,-4,32,-6,54});
    states[25] = new State(new int[]{134,26});
    states[26] = new State(new int[]{133,21,123,28,129,46,130,47,131,48,132,49,147,50,148,52,135,57,136,58,143,59,144,64,145,70},new int[]{-5,27,-4,32,-6,54});
    states[27] = new State(-21);
    states[28] = new State(-34,new int[]{-7,29});
    states[29] = new State(new int[]{125,30,133,21,123,28,129,46,130,47,131,48,132,49,147,50,148,52,135,57,136,58,143,59,144,64,145,70},new int[]{-5,31,-4,32,-6,54});
    states[30] = new State(-22);
    states[31] = new State(-33);
    states[32] = new State(new int[]{59,33,61,34,43,36,60,38,42,40,45,42,147,44,148,45});
    states[33] = new State(-23);
    states[34] = new State(new int[]{129,46,130,47,131,48,132,49,147,50,148,52},new int[]{-4,35});
    states[35] = new State(new int[]{61,-39,43,36,60,38,42,40,45,42,147,44,148,45,59,-39,41,-39});
    states[36] = new State(new int[]{129,46,130,47,131,48,132,49,147,50,148,52},new int[]{-4,37});
    states[37] = new State(new int[]{61,-40,43,-40,60,-40,42,40,45,42,147,44,148,45,59,-40,41,-40});
    states[38] = new State(new int[]{129,46,130,47,131,48,132,49,147,50,148,52},new int[]{-4,39});
    states[39] = new State(new int[]{61,-41,43,36,41,-41,42,40,45,42,147,44,148,45,59,-41});
    states[40] = new State(new int[]{129,46,130,47,131,48,132,49,147,50,148,52},new int[]{-4,41});
    states[41] = new State(new int[]{61,-42,43,-42,60,-42,42,-42,45,42,147,44,148,45,59,-42,41,-42});
    states[42] = new State(new int[]{129,46,130,47,131,48,132,49,147,50,148,52},new int[]{-4,43});
    states[43] = new State(new int[]{61,34,43,36,60,38,42,40,45,42,147,44,148,45,59,-43,41,-43});
    states[44] = new State(-44);
    states[45] = new State(-45);
    states[46] = new State(-35);
    states[47] = new State(-36);
    states[48] = new State(-37);
    states[49] = new State(-38);
    states[50] = new State(new int[]{129,46,130,47,131,48,132,49,147,50,148,52},new int[]{-4,51});
    states[51] = new State(new int[]{61,-46,43,-46,60,-46,42,-46,45,42,41,-46,59,-46});
    states[52] = new State(new int[]{129,46,130,47,131,48,132,49,147,50,148,52},new int[]{-4,53});
    states[53] = new State(new int[]{61,-47,43,-47,60,-47,42,-47,45,42,41,-47,59,-47});
    states[54] = new State(new int[]{130,55});
    states[55] = new State(new int[]{59,56});
    states[56] = new State(-24);
    states[57] = new State(-28);
    states[58] = new State(-29);
    states[59] = new State(new int[]{40,60});
    states[60] = new State(new int[]{129,46,130,47,131,48,132,49,147,50,148,52},new int[]{-4,61});
    states[61] = new State(new int[]{41,62,61,34,43,36,60,38,42,40,45,42,147,44,148,45});
    states[62] = new State(new int[]{133,21,123,28,129,46,130,47,131,48,132,49,147,50,148,52,135,57,136,58,143,59,144,64,145,70},new int[]{-5,63,-4,32,-6,54});
    states[63] = new State(-25);
    states[64] = new State(new int[]{133,21,123,28,129,46,130,47,131,48,132,49,147,50,148,52,135,57,136,58,143,59,144,64,145,70},new int[]{-5,65,-4,32,-6,54});
    states[65] = new State(new int[]{143,66});
    states[66] = new State(new int[]{40,67});
    states[67] = new State(new int[]{129,46,130,47,131,48,132,49,147,50,148,52},new int[]{-4,68});
    states[68] = new State(new int[]{41,69,61,34,43,36,60,38,42,40,45,42,147,44,148,45});
    states[69] = new State(-26);
    states[70] = new State(new int[]{40,71});
    states[71] = new State(new int[]{129,46,130,47,131,48,132,49,147,50,148,52},new int[]{-4,72});
    states[72] = new State(new int[]{59,73,61,34,43,36,60,38,42,40,45,42,147,44,148,45});
    states[73] = new State(new int[]{129,46,130,47,131,48,132,49,147,50,148,52},new int[]{-4,74});
    states[74] = new State(new int[]{59,75,61,34,43,36,60,38,42,40,45,42,147,44,148,45});
    states[75] = new State(new int[]{129,46,130,47,131,48,132,49,147,50,148,52},new int[]{-4,76});
    states[76] = new State(new int[]{41,77,61,34,43,36,60,38,42,40,45,42,147,44,148,45});
    states[77] = new State(new int[]{133,21,123,28,129,46,130,47,131,48,132,49,147,50,148,52,135,57,136,58,143,59,144,64,145,70},new int[]{-5,78,-4,32,-6,54});
    states[78] = new State(-27);
    states[79] = new State(-31);
    states[80] = new State(new int[]{130,81});
    states[81] = new State(-30);
    states[82] = new State(-19);
    states[83] = new State(-16);
    states[84] = new State(-17);
    states[85] = new State(-18);
    states[86] = new State(new int[]{130,87});
    states[87] = new State(new int[]{123,88});
    states[88] = new State(new int[]{130,91},new int[]{-3,89});
    states[89] = new State(new int[]{125,90});
    states[90] = new State(-9);
    states[91] = new State(-14,new int[]{-11,92});
    states[92] = new State(new int[]{125,-10,130,-20,139,-20,141,-20,142,-20},new int[]{-10,14,-9,15});
    states[93] = new State(-8);

    for (int sNo = 0; sNo < states.Length; sNo++) states[sNo].number = sNo;

    rules[1] = new Rule(-19, new int[]{-18,128});
    rules[2] = new Rule(-18, new int[]{-1});
    rules[3] = new Rule(-1, new int[]{-15});
    rules[4] = new Rule(-15, new int[]{-15,-13});
    rules[5] = new Rule(-15, new int[]{});
    rules[6] = new Rule(-13, new int[]{-14});
    rules[7] = new Rule(-14, new int[]{-12});
    rules[8] = new Rule(-14, new int[]{-2});
    rules[9] = new Rule(-2, new int[]{-9,146,130,123,-3,125});
    rules[10] = new Rule(-3, new int[]{130,-11});
    rules[11] = new Rule(-12, new int[]{-9,140,130,123,-11,125});
    rules[12] = new Rule(-20, new int[]{});
    rules[13] = new Rule(-11, new int[]{-11,-10});
    rules[14] = new Rule(-11, new int[]{});
    rules[15] = new Rule(-10, new int[]{-9,130,40,-17,41,-5});
    rules[16] = new Rule(-8, new int[]{139});
    rules[17] = new Rule(-8, new int[]{141});
    rules[18] = new Rule(-8, new int[]{142});
    rules[19] = new Rule(-9, new int[]{-9,-8});
    rules[20] = new Rule(-9, new int[]{});
    rules[21] = new Rule(-5, new int[]{133,40,-4,41,-5,134,-5});
    rules[22] = new Rule(-5, new int[]{123,-7,125});
    rules[23] = new Rule(-5, new int[]{-4,59});
    rules[24] = new Rule(-5, new int[]{-6,130,59});
    rules[25] = new Rule(-5, new int[]{143,40,-4,41,-5});
    rules[26] = new Rule(-5, new int[]{144,-5,143,40,-4,41});
    rules[27] = new Rule(-5, new int[]{145,40,-4,59,-4,59,-4,41,-5});
    rules[28] = new Rule(-6, new int[]{135});
    rules[29] = new Rule(-6, new int[]{136});
    rules[30] = new Rule(-16, new int[]{-6,130});
    rules[31] = new Rule(-17, new int[]{-17,-16});
    rules[32] = new Rule(-17, new int[]{});
    rules[33] = new Rule(-7, new int[]{-7,-5});
    rules[34] = new Rule(-7, new int[]{});
    rules[35] = new Rule(-4, new int[]{129});
    rules[36] = new Rule(-4, new int[]{130});
    rules[37] = new Rule(-4, new int[]{131});
    rules[38] = new Rule(-4, new int[]{132});
    rules[39] = new Rule(-4, new int[]{-4,61,-4});
    rules[40] = new Rule(-4, new int[]{-4,43,-4});
    rules[41] = new Rule(-4, new int[]{-4,60,-4});
    rules[42] = new Rule(-4, new int[]{-4,42,-4});
    rules[43] = new Rule(-4, new int[]{-4,45,-4});
    rules[44] = new Rule(-4, new int[]{-4,147});
    rules[45] = new Rule(-4, new int[]{-4,148});
    rules[46] = new Rule(-4, new int[]{147,-4});
    rules[47] = new Rule(-4, new int[]{148,-4});
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
      case 2: // Program -> CompilationUnit
#line 118 "parser.y"
                          {root = ValueStack[ValueStack.Depth-1].compilationUnit;}
#line default
        break;
      case 3: // CompilationUnit -> TypeDeclarations
#line 122 "parser.y"
                                {CurrentSemanticValue.compilationUnit = new CompilationUnit(ValueStack[ValueStack.Depth-1].typeDeclarations); }
#line default
        break;
      case 4: // TypeDeclarations -> TypeDeclarations, TypeDeclaration
#line 126 "parser.y"
                                                     {CurrentSemanticValue.typeDeclarations = ValueStack[ValueStack.Depth-2].typeDeclarations; CurrentSemanticValue.typeDeclarations.Add(ValueStack[ValueStack.Depth-1].typeDeclaration);}
#line default
        break;
      case 5: // TypeDeclarations -> /* empty */
#line 127 "parser.y"
                                      {CurrentSemanticValue.typeDeclarations = new List<TypeDeclaration>(); }
#line default
        break;
      case 6: // TypeDeclaration -> ClassDeclaration
#line 131 "parser.y"
                                         {CurrentSemanticValue.typeDeclaration = ValueStack[ValueStack.Depth-1].typeDeclaration;}
#line default
        break;
      case 7: // ClassDeclaration -> NormalClassDeclaration
#line 135 "parser.y"
                                             {CurrentSemanticValue.typeDeclaration = ValueStack[ValueStack.Depth-1].normalClassDeclaration;}
#line default
        break;
      case 8: // ClassDeclaration -> EnumDeclaration
#line 136 "parser.y"
                                                                                                            {CurrentSemanticValue.typeDeclaration=ValueStack[ValueStack.Depth-1].enumDeclaration;}
#line default
        break;
      case 9: // EnumDeclaration -> Modifiers, ENUM, IDENT, '{', EnumConstant, '}'
#line 140 "parser.y"
                                              {CurrentSemanticValue.enumDeclaration=new EnumDeclaration(ValueStack[ValueStack.Depth-6].modifiers, ValueStack[ValueStack.Depth-4].name, ValueStack[ValueStack.Depth-2].enumConstant);}
#line default
        break;
      case 10: // EnumConstant -> IDENT, MethodDeclarations
#line 144 "parser.y"
                            {CurrentSemanticValue.enumConstant=new EnumConstant(ValueStack[ValueStack.Depth-2].name, ValueStack[ValueStack.Depth-1].methodDeclarations);}
#line default
        break;
      case 11: // NormalClassDeclaration -> Modifiers, CLASS, IDENT, '{', MethodDeclarations, '}'
#line 148 "parser.y"
                                                      { CurrentSemanticValue.normalClassDeclaration = new NormalClassDeclaration(ValueStack[ValueStack.Depth-6].modifiers, ValueStack[ValueStack.Depth-4].name, ValueStack[ValueStack.Depth-2].methodDeclarations);}
#line default
        break;
      case 13: // MethodDeclarations -> MethodDeclarations, MethodDeclaration
#line 156 "parser.y"
                                            { CurrentSemanticValue.methodDeclarations = ValueStack[ValueStack.Depth-2].methodDeclarations; CurrentSemanticValue.methodDeclarations.Add(ValueStack[ValueStack.Depth-1].methodDeclaration);}
#line default
        break;
      case 14: // MethodDeclarations -> /* empty */
#line 157 "parser.y"
                            { CurrentSemanticValue.methodDeclarations = new List<MethodDeclaration>(); }
#line default
        break;
      case 15: // MethodDeclaration -> Modifiers, IDENT, '(', FormalParameterList, ')', Statement
#line 163 "parser.y"
                                                             { CurrentSemanticValue.methodDeclaration = new MethodDeclaration(ValueStack[ValueStack.Depth-6].modifiers,ValueStack[ValueStack.Depth-5].name,ValueStack[ValueStack.Depth-3].formalParameterList,ValueStack[ValueStack.Depth-1].stmt);}
#line default
        break;
      case 16: // Modifier -> PUBLIC
#line 169 "parser.y"
                     {CurrentSemanticValue.modifier = Modifier.PUBLIC;}
#line default
        break;
      case 17: // Modifier -> STATIC
#line 170 "parser.y"
                           {CurrentSemanticValue.modifier = Modifier.STATIC;}
#line default
        break;
      case 18: // Modifier -> VOID
#line 171 "parser.y"
                     {CurrentSemanticValue.modifier = Modifier.VOID;}
#line default
        break;
      case 19: // Modifiers -> Modifiers, Modifier
#line 175 "parser.y"
                           {CurrentSemanticValue.modifiers = ValueStack[ValueStack.Depth-2].modifiers; CurrentSemanticValue.modifiers.Add(ValueStack[ValueStack.Depth-1].modifier);}
#line default
        break;
      case 20: // Modifiers -> /* empty */
#line 176 "parser.y"
                      {CurrentSemanticValue.modifiers = new List<Modifier>();}
#line default
        break;
      case 21: // Statement -> IF, '(', Expression, ')', Statement, ELSE, Statement
#line 180 "parser.y"
                                                           { CurrentSemanticValue.stmt = new IfStatement(ValueStack[ValueStack.Depth-5].expr, ValueStack[ValueStack.Depth-3].stmt, ValueStack[ValueStack.Depth-1].stmt); }
#line default
        break;
      case 22: // Statement -> '{', StatementList, '}'
#line 181 "parser.y"
                                        { CurrentSemanticValue.stmt = new CompoundStatement(ValueStack[ValueStack.Depth-2].stmts);   }
#line default
        break;
      case 23: // Statement -> Expression, ';'
#line 182 "parser.y"
                             { CurrentSemanticValue.stmt = new ExpressionStatement(ValueStack[ValueStack.Depth-2].expr); }
#line default
        break;
      case 24: // Statement -> UnAnnType, IDENT, ';'
#line 183 "parser.y"
                                 { CurrentSemanticValue.stmt = new VariableDeclaration(ValueStack[ValueStack.Depth-3].type,ValueStack[ValueStack.Depth-2].name); }
#line default
        break;
      case 25: // Statement -> WHILE, '(', Expression, ')', Statement
#line 184 "parser.y"
                                            { CurrentSemanticValue.stmt = new WhileStatement(ValueStack[ValueStack.Depth-3].expr,ValueStack[ValueStack.Depth-1].stmt);}
#line default
        break;
      case 26: // Statement -> DO, Statement, WHILE, '(', Expression, ')'
#line 185 "parser.y"
                                              { CurrentSemanticValue.stmt = new DoStatement(ValueStack[ValueStack.Depth-5].stmt, ValueStack[ValueStack.Depth-2].expr); }
#line default
        break;
      case 27: // Statement -> FOR, '(', Expression, ';', Expression, ';', Expression, ')', 
               //              Statement
#line 186 "parser.y"
                                                                      { CurrentSemanticValue.stmt = new BasicForStatement(ValueStack[ValueStack.Depth-7].expr, ValueStack[ValueStack.Depth-5].expr, ValueStack[ValueStack.Depth-3].expr, ValueStack[ValueStack.Depth-1].stmt);}
#line default
        break;
      case 28: // UnAnnType -> INT
#line 191 "parser.y"
                            { CurrentSemanticValue.type = new IntType(); }
#line default
        break;
      case 29: // UnAnnType -> BOOL
#line 192 "parser.y"
                              { CurrentSemanticValue.type = new BoolType(); }
#line default
        break;
      case 30: // FormalParameter -> UnAnnType, IDENT
#line 196 "parser.y"
                      {CurrentSemanticValue.formalParameter = new FormalParameter(ValueStack[ValueStack.Depth-2].type, ValueStack[ValueStack.Depth-1].name);}
#line default
        break;
      case 31: // FormalParameterList -> FormalParameterList, FormalParameter
#line 200 "parser.y"
                                              { CurrentSemanticValue.formalParameterList = ValueStack[ValueStack.Depth-2].formalParameterList; CurrentSemanticValue.formalParameterList.Add(ValueStack[ValueStack.Depth-1].formalParameter); }
#line default
        break;
      case 32: // FormalParameterList -> /* empty */
#line 201 "parser.y"
                                  { CurrentSemanticValue.formalParameterList = new List<FormalParameter>(); }
#line default
        break;
      case 33: // StatementList -> StatementList, Statement
#line 205 "parser.y"
                                                { CurrentSemanticValue.stmts = ValueStack[ValueStack.Depth-2].stmts; CurrentSemanticValue.stmts.Add(ValueStack[ValueStack.Depth-1].stmt);    }
#line default
        break;
      case 34: // StatementList -> /* empty */
#line 206 "parser.y"
                                    { CurrentSemanticValue.stmts = new List<Statement>(); }
#line default
        break;
      case 35: // Expression -> NUMBER
#line 209 "parser.y"
                              { CurrentSemanticValue.expr = new NumberExpression(ValueStack[ValueStack.Depth-1].num);         }
#line default
        break;
      case 36: // Expression -> IDENT
#line 210 "parser.y"
                             { CurrentSemanticValue.expr = new IdentifierExpression(ValueStack[ValueStack.Depth-1].name);     }
#line default
        break;
      case 37: // Expression -> TRUE
#line 211 "parser.y"
                      { CurrentSemanticValue.expr = new BooleanExpression(ValueStack[ValueStack.Depth-1].boolAnswer);        }
#line default
        break;
      case 38: // Expression -> FALSE
#line 212 "parser.y"
                       { CurrentSemanticValue.expr = new BooleanExpression(ValueStack[ValueStack.Depth-1].boolAnswer);        }
#line default
        break;
      case 39: // Expression -> Expression, '=', Expression
#line 213 "parser.y"
                                      { CurrentSemanticValue.expr = new AssignmentExpression(ValueStack[ValueStack.Depth-3].expr, ValueStack[ValueStack.Depth-1].expr); }
#line default
        break;
      case 40: // Expression -> Expression, '+', Expression
#line 214 "parser.y"
                                      { CurrentSemanticValue.expr = new BinaryExpression(ValueStack[ValueStack.Depth-3].expr,'+',ValueStack[ValueStack.Depth-1].expr);  }
#line default
        break;
      case 41: // Expression -> Expression, '<', Expression
#line 215 "parser.y"
                                      { CurrentSemanticValue.expr = new BinaryExpression(ValueStack[ValueStack.Depth-3].expr,'<',ValueStack[ValueStack.Depth-1].expr);  }
#line default
        break;
      case 42: // Expression -> Expression, '*', Expression
#line 216 "parser.y"
                                      { CurrentSemanticValue.expr = new BinaryExpression(ValueStack[ValueStack.Depth-3].expr,'*',ValueStack[ValueStack.Depth-1].expr);  }
#line default
        break;
      case 43: // Expression -> Expression, '-', Expression
#line 217 "parser.y"
                                      { CurrentSemanticValue.expr = new BinaryExpression(ValueStack[ValueStack.Depth-3].expr,'-',ValueStack[ValueStack.Depth-1].expr);  }
#line default
        break;
      case 44: // Expression -> Expression, INCREMENT_OPERATOR
#line 218 "parser.y"
                                         { CurrentSemanticValue.expr = new SimpleIncrementExpression(ValueStack[ValueStack.Depth-2].expr, ValueStack[ValueStack.Depth-1].name);	 }
#line default
        break;
      case 45: // Expression -> Expression, DECREMENT_OPERATOR
#line 219 "parser.y"
                                         { CurrentSemanticValue.expr = new SimpleIncrementExpression(ValueStack[ValueStack.Depth-2].expr, ValueStack[ValueStack.Depth-1].name);	 }
#line default
        break;
      case 46: // Expression -> INCREMENT_OPERATOR, Expression
#line 220 "parser.y"
                                         { CurrentSemanticValue.expr = new SimpleIncrementExpression(ValueStack[ValueStack.Depth-1].expr, ValueStack[ValueStack.Depth-2].name);	 }
#line default
        break;
      case 47: // Expression -> DECREMENT_OPERATOR, Expression
#line 221 "parser.y"
                                         { CurrentSemanticValue.expr = new SimpleIncrementExpression(ValueStack[ValueStack.Depth-1].expr, ValueStack[ValueStack.Depth-2].name);	 }
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

#line 225 "parser.y"

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
