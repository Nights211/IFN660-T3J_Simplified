// This code was generated by the Gardens Point Parser Generator
// Copyright (c) Wayne Kelly, John Gough, QUT 2005-2014
// (see accompanying GPPGcopyright.rtf)

// GPPG version 1.5.2
// Machine:  SHILPA
// DateTime: 6/4/2017 9:39:58 PM
// UserName: shilp
// Input file <parser.y - 6/4/2017 9:23:27 PM>

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
	public EnumBody enumBody;
	public List<EnumConstant> enumConstantList;

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
  // Verbatim content from parser.y - 6/4/2017 9:23:27 PM
#line 6 "parser.y"
public static CompilationUnit root;
#line default
  // End verbatim content from parser.y - 6/4/2017 9:23:27 PM

#pragma warning disable 649
  private static Dictionary<int, string> aliases;
#pragma warning restore 649
  private static Rule[] rules = new Rule[57];
  private static State[] states = new State[109];
  private static string[] nonTerms = new string[] {
      "CompilationUnit", "EnumDeclaration", "EnumConstant", "EnumBody", "EnumConstantList", 
      "ComaSeparatedEnumConstantList", "Expressions", "ArguementList", "ComaSeparatedExpressions", 
      "Expression", "Statement", "UnAnnType", "StatementList", "Modifier", "Modifiers", 
      "MethodDeclaration", "MethodDeclarations", "NormalClassDeclaration", "TypeDeclaration", 
      "ClassDeclaration", "TypeDeclarations", "FormalParameter", "FormalParameterList", 
      "Program", "$accept", "ClassBody", };

  static Parser() {
    states[0] = new State(-5,new int[]{-24,1,-1,3,-21,4});
    states[1] = new State(new int[]{128,2});
    states[2] = new State(-1);
    states[3] = new State(-2);
    states[4] = new State(new int[]{128,-3,140,-29,146,-29,139,-29,141,-29,142,-29},new int[]{-19,5,-20,6,-18,7,-15,8,-2,108});
    states[5] = new State(-4);
    states[6] = new State(-6);
    states[7] = new State(-7);
    states[8] = new State(new int[]{140,9,146,86,139,83,141,84,142,85},new int[]{-14,82});
    states[9] = new State(new int[]{130,10});
    states[10] = new State(new int[]{123,11});
    states[11] = new State(-23,new int[]{-17,12});
    states[12] = new State(new int[]{125,13,130,-29,139,-29,141,-29,142,-29},new int[]{-16,14,-15,15});
    states[13] = new State(-20);
    states[14] = new State(-22);
    states[15] = new State(new int[]{130,16,139,83,141,84,142,85},new int[]{-14,82});
    states[16] = new State(new int[]{40,17});
    states[17] = new State(-41,new int[]{-23,18});
    states[18] = new State(new int[]{41,19,135,57,136,58},new int[]{-22,79,-12,80});
    states[19] = new State(new int[]{133,21,123,28,129,46,130,47,131,48,132,49,147,50,148,52,135,57,136,58,143,59,144,64,145,70},new int[]{-11,20,-10,32,-12,54});
    states[20] = new State(-24);
    states[21] = new State(new int[]{40,22});
    states[22] = new State(new int[]{129,46,130,47,131,48,132,49,147,50,148,52},new int[]{-10,23});
    states[23] = new State(new int[]{41,24,61,34,43,36,60,38,42,40,45,42,147,44,148,45});
    states[24] = new State(new int[]{133,21,123,28,129,46,130,47,131,48,132,49,147,50,148,52,135,57,136,58,143,59,144,64,145,70},new int[]{-11,25,-10,32,-12,54});
    states[25] = new State(new int[]{134,26});
    states[26] = new State(new int[]{133,21,123,28,129,46,130,47,131,48,132,49,147,50,148,52,135,57,136,58,143,59,144,64,145,70},new int[]{-11,27,-10,32,-12,54});
    states[27] = new State(-30);
    states[28] = new State(-43,new int[]{-13,29});
    states[29] = new State(new int[]{125,30,133,21,123,28,129,46,130,47,131,48,132,49,147,50,148,52,135,57,136,58,143,59,144,64,145,70},new int[]{-11,31,-10,32,-12,54});
    states[30] = new State(-31);
    states[31] = new State(-42);
    states[32] = new State(new int[]{59,33,61,34,43,36,60,38,42,40,45,42,147,44,148,45});
    states[33] = new State(-32);
    states[34] = new State(new int[]{129,46,130,47,131,48,132,49,147,50,148,52},new int[]{-10,35});
    states[35] = new State(new int[]{61,-48,43,36,60,38,42,40,45,42,147,44,148,45,59,-48,41,-48,44,-48});
    states[36] = new State(new int[]{129,46,130,47,131,48,132,49,147,50,148,52},new int[]{-10,37});
    states[37] = new State(new int[]{61,-49,43,-49,60,-49,42,40,45,42,147,44,148,45,59,-49,41,-49,44,-49});
    states[38] = new State(new int[]{129,46,130,47,131,48,132,49,147,50,148,52},new int[]{-10,39});
    states[39] = new State(new int[]{61,-50,43,36,41,-50,42,40,45,42,147,44,148,45,59,-50,44,-50});
    states[40] = new State(new int[]{129,46,130,47,131,48,132,49,147,50,148,52},new int[]{-10,41});
    states[41] = new State(new int[]{61,-51,43,-51,60,-51,42,-51,45,42,147,44,148,45,59,-51,41,-51,44,-51});
    states[42] = new State(new int[]{129,46,130,47,131,48,132,49,147,50,148,52},new int[]{-10,43});
    states[43] = new State(new int[]{61,34,43,36,60,38,42,40,45,42,147,44,148,45,59,-52,41,-52,44,-52});
    states[44] = new State(-53);
    states[45] = new State(-54);
    states[46] = new State(-44);
    states[47] = new State(-45);
    states[48] = new State(-46);
    states[49] = new State(-47);
    states[50] = new State(new int[]{129,46,130,47,131,48,132,49,147,50,148,52},new int[]{-10,51});
    states[51] = new State(new int[]{61,-55,43,-55,60,-55,42,-55,45,42,44,-55,41,-55,59,-55});
    states[52] = new State(new int[]{129,46,130,47,131,48,132,49,147,50,148,52},new int[]{-10,53});
    states[53] = new State(new int[]{61,-56,43,-56,60,-56,42,-56,45,42,44,-56,41,-56,59,-56});
    states[54] = new State(new int[]{130,55});
    states[55] = new State(new int[]{59,56});
    states[56] = new State(-33);
    states[57] = new State(-37);
    states[58] = new State(-38);
    states[59] = new State(new int[]{40,60});
    states[60] = new State(new int[]{129,46,130,47,131,48,132,49,147,50,148,52},new int[]{-10,61});
    states[61] = new State(new int[]{41,62,61,34,43,36,60,38,42,40,45,42,147,44,148,45});
    states[62] = new State(new int[]{133,21,123,28,129,46,130,47,131,48,132,49,147,50,148,52,135,57,136,58,143,59,144,64,145,70},new int[]{-11,63,-10,32,-12,54});
    states[63] = new State(-34);
    states[64] = new State(new int[]{133,21,123,28,129,46,130,47,131,48,132,49,147,50,148,52,135,57,136,58,143,59,144,64,145,70},new int[]{-11,65,-10,32,-12,54});
    states[65] = new State(new int[]{143,66});
    states[66] = new State(new int[]{40,67});
    states[67] = new State(new int[]{129,46,130,47,131,48,132,49,147,50,148,52},new int[]{-10,68});
    states[68] = new State(new int[]{41,69,61,34,43,36,60,38,42,40,45,42,147,44,148,45});
    states[69] = new State(-35);
    states[70] = new State(new int[]{40,71});
    states[71] = new State(new int[]{129,46,130,47,131,48,132,49,147,50,148,52},new int[]{-10,72});
    states[72] = new State(new int[]{59,73,61,34,43,36,60,38,42,40,45,42,147,44,148,45});
    states[73] = new State(new int[]{129,46,130,47,131,48,132,49,147,50,148,52},new int[]{-10,74});
    states[74] = new State(new int[]{59,75,61,34,43,36,60,38,42,40,45,42,147,44,148,45});
    states[75] = new State(new int[]{129,46,130,47,131,48,132,49,147,50,148,52},new int[]{-10,76});
    states[76] = new State(new int[]{41,77,61,34,43,36,60,38,42,40,45,42,147,44,148,45});
    states[77] = new State(new int[]{133,21,123,28,129,46,130,47,131,48,132,49,147,50,148,52,135,57,136,58,143,59,144,64,145,70},new int[]{-11,78,-10,32,-12,54});
    states[78] = new State(-36);
    states[79] = new State(-40);
    states[80] = new State(new int[]{130,81});
    states[81] = new State(-39);
    states[82] = new State(-28);
    states[83] = new State(-25);
    states[84] = new State(-26);
    states[85] = new State(-27);
    states[86] = new State(new int[]{130,87});
    states[87] = new State(new int[]{123,88});
    states[88] = new State(new int[]{130,97,125,-12},new int[]{-4,89,-5,91,-3,92});
    states[89] = new State(new int[]{125,90});
    states[90] = new State(-9);
    states[91] = new State(-10);
    states[92] = new State(new int[]{44,94,125,-14},new int[]{-6,93});
    states[93] = new State(-11);
    states[94] = new State(new int[]{130,97},new int[]{-3,95});
    states[95] = new State(new int[]{44,94,125,-14},new int[]{-6,96});
    states[96] = new State(-13);
    states[97] = new State(new int[]{40,100},new int[]{-8,98});
    states[98] = new State(-23,new int[]{-17,99});
    states[99] = new State(new int[]{44,-15,125,-15,130,-29,139,-29,141,-29,142,-29},new int[]{-16,14,-15,15});
    states[100] = new State(new int[]{129,46,130,47,131,48,132,49,147,50,148,52},new int[]{-7,101,-10,103});
    states[101] = new State(new int[]{41,102});
    states[102] = new State(-16);
    states[103] = new State(new int[]{61,34,43,36,60,38,42,40,45,42,147,44,148,45,44,105,41,-19},new int[]{-9,104});
    states[104] = new State(-17);
    states[105] = new State(new int[]{129,46,130,47,131,48,132,49,147,50,148,52},new int[]{-10,106});
    states[106] = new State(new int[]{61,34,43,36,60,38,42,40,45,42,147,44,148,45,44,105,41,-19},new int[]{-9,107});
    states[107] = new State(-18);
    states[108] = new State(-8);

    for (int sNo = 0; sNo < states.Length; sNo++) states[sNo].number = sNo;

    rules[1] = new Rule(-25, new int[]{-24,128});
    rules[2] = new Rule(-24, new int[]{-1});
    rules[3] = new Rule(-1, new int[]{-21});
    rules[4] = new Rule(-21, new int[]{-21,-19});
    rules[5] = new Rule(-21, new int[]{});
    rules[6] = new Rule(-19, new int[]{-20});
    rules[7] = new Rule(-20, new int[]{-18});
    rules[8] = new Rule(-20, new int[]{-2});
    rules[9] = new Rule(-2, new int[]{-15,146,130,123,-4,125});
    rules[10] = new Rule(-4, new int[]{-5});
    rules[11] = new Rule(-5, new int[]{-3,-6});
    rules[12] = new Rule(-5, new int[]{});
    rules[13] = new Rule(-6, new int[]{44,-3,-6});
    rules[14] = new Rule(-6, new int[]{});
    rules[15] = new Rule(-3, new int[]{130,-8,-17});
    rules[16] = new Rule(-8, new int[]{40,-7,41});
    rules[17] = new Rule(-7, new int[]{-10,-9});
    rules[18] = new Rule(-9, new int[]{44,-10,-9});
    rules[19] = new Rule(-9, new int[]{});
    rules[20] = new Rule(-18, new int[]{-15,140,130,123,-17,125});
    rules[21] = new Rule(-26, new int[]{});
    rules[22] = new Rule(-17, new int[]{-17,-16});
    rules[23] = new Rule(-17, new int[]{});
    rules[24] = new Rule(-16, new int[]{-15,130,40,-23,41,-11});
    rules[25] = new Rule(-14, new int[]{139});
    rules[26] = new Rule(-14, new int[]{141});
    rules[27] = new Rule(-14, new int[]{142});
    rules[28] = new Rule(-15, new int[]{-15,-14});
    rules[29] = new Rule(-15, new int[]{});
    rules[30] = new Rule(-11, new int[]{133,40,-10,41,-11,134,-11});
    rules[31] = new Rule(-11, new int[]{123,-13,125});
    rules[32] = new Rule(-11, new int[]{-10,59});
    rules[33] = new Rule(-11, new int[]{-12,130,59});
    rules[34] = new Rule(-11, new int[]{143,40,-10,41,-11});
    rules[35] = new Rule(-11, new int[]{144,-11,143,40,-10,41});
    rules[36] = new Rule(-11, new int[]{145,40,-10,59,-10,59,-10,41,-11});
    rules[37] = new Rule(-12, new int[]{135});
    rules[38] = new Rule(-12, new int[]{136});
    rules[39] = new Rule(-22, new int[]{-12,130});
    rules[40] = new Rule(-23, new int[]{-23,-22});
    rules[41] = new Rule(-23, new int[]{});
    rules[42] = new Rule(-13, new int[]{-13,-11});
    rules[43] = new Rule(-13, new int[]{});
    rules[44] = new Rule(-10, new int[]{129});
    rules[45] = new Rule(-10, new int[]{130});
    rules[46] = new Rule(-10, new int[]{131});
    rules[47] = new Rule(-10, new int[]{132});
    rules[48] = new Rule(-10, new int[]{-10,61,-10});
    rules[49] = new Rule(-10, new int[]{-10,43,-10});
    rules[50] = new Rule(-10, new int[]{-10,60,-10});
    rules[51] = new Rule(-10, new int[]{-10,42,-10});
    rules[52] = new Rule(-10, new int[]{-10,45,-10});
    rules[53] = new Rule(-10, new int[]{-10,147});
    rules[54] = new Rule(-10, new int[]{-10,148});
    rules[55] = new Rule(-10, new int[]{147,-10});
    rules[56] = new Rule(-10, new int[]{148,-10});
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
#line 123 "parser.y"
                          {root = ValueStack[ValueStack.Depth-1].compilationUnit;}
#line default
        break;
      case 3: // CompilationUnit -> TypeDeclarations
#line 127 "parser.y"
                                {CurrentSemanticValue.compilationUnit = new CompilationUnit(ValueStack[ValueStack.Depth-1].typeDeclarations); }
#line default
        break;
      case 4: // TypeDeclarations -> TypeDeclarations, TypeDeclaration
#line 131 "parser.y"
                                                     {CurrentSemanticValue.typeDeclarations = ValueStack[ValueStack.Depth-2].typeDeclarations; CurrentSemanticValue.typeDeclarations.Add(ValueStack[ValueStack.Depth-1].typeDeclaration);}
#line default
        break;
      case 5: // TypeDeclarations -> /* empty */
#line 132 "parser.y"
                                      {CurrentSemanticValue.typeDeclarations = new List<TypeDeclaration>(); }
#line default
        break;
      case 6: // TypeDeclaration -> ClassDeclaration
#line 136 "parser.y"
                                         {CurrentSemanticValue.typeDeclaration = ValueStack[ValueStack.Depth-1].typeDeclaration;}
#line default
        break;
      case 7: // ClassDeclaration -> NormalClassDeclaration
#line 140 "parser.y"
                                             {CurrentSemanticValue.typeDeclaration = ValueStack[ValueStack.Depth-1].normalClassDeclaration;}
#line default
        break;
      case 8: // ClassDeclaration -> EnumDeclaration
#line 141 "parser.y"
                                                                                                            {CurrentSemanticValue.typeDeclaration=ValueStack[ValueStack.Depth-1].enumDeclaration;}
#line default
        break;
      case 9: // EnumDeclaration -> Modifiers, ENUM, IDENT, '{', EnumBody, '}'
#line 145 "parser.y"
                                          {CurrentSemanticValue.enumDeclaration=new EnumDeclaration(ValueStack[ValueStack.Depth-6].modifiers, ValueStack[ValueStack.Depth-4].name, ValueStack[ValueStack.Depth-2].enumBody);}
#line default
        break;
      case 10: // EnumBody -> EnumConstantList
#line 149 "parser.y"
                    {CurrentSemanticValue.enumBody=new EnumBody(ValueStack[ValueStack.Depth-1].enumConstantList);}
#line default
        break;
      case 11: // EnumConstantList -> EnumConstant, ComaSeparatedEnumConstantList
#line 153 "parser.y"
                                                 { CurrentSemanticValue.enumConstantList = ValueStack[ValueStack.Depth-1].enumConstantList; CurrentSemanticValue.enumConstantList.Add(ValueStack[ValueStack.Depth-2].enumConstant);}
#line default
        break;
      case 13: // ComaSeparatedEnumConstantList -> ',', EnumConstant, 
               //                                  ComaSeparatedEnumConstantList
#line 158 "parser.y"
                                                       {CurrentSemanticValue.enumConstantList=ValueStack[ValueStack.Depth-1].enumConstantList; CurrentSemanticValue.enumConstantList.Add(ValueStack[ValueStack.Depth-2].enumConstant);}
#line default
        break;
      case 14: // ComaSeparatedEnumConstantList -> /* empty */
#line 159 "parser.y"
                  {CurrentSemanticValue.enumConstantList=new List<EnumConstant>();}
#line default
        break;
      case 15: // EnumConstant -> IDENT, ArguementList, MethodDeclarations
#line 163 "parser.y"
                                          {CurrentSemanticValue.enumConstant=new EnumConstant(ValueStack[ValueStack.Depth-3].name, ValueStack[ValueStack.Depth-1].methodDeclarations, ValueStack[ValueStack.Depth-2].expressions);}
#line default
        break;
      case 16: // ArguementList -> '(', Expressions, ')'
#line 167 "parser.y"
                         {CurrentSemanticValue.expressions=ValueStack[ValueStack.Depth-2].expressions;}
#line default
        break;
      case 17: // Expressions -> Expression, ComaSeparatedExpressions
#line 171 "parser.y"
                                          { CurrentSemanticValue.expressions = ValueStack[ValueStack.Depth-1].expressions; CurrentSemanticValue.expressions.Add(ValueStack[ValueStack.Depth-2].expr);}
#line default
        break;
      case 18: // ComaSeparatedExpressions -> ',', Expression, ComaSeparatedExpressions
#line 175 "parser.y"
                                            {CurrentSemanticValue.expressions=ValueStack[ValueStack.Depth-1].expressions; CurrentSemanticValue.expressions.Add(ValueStack[ValueStack.Depth-2].expr);}
#line default
        break;
      case 19: // ComaSeparatedExpressions -> /* empty */
#line 176 "parser.y"
                         {CurrentSemanticValue.expressions=new List<Expression>();}
#line default
        break;
      case 20: // NormalClassDeclaration -> Modifiers, CLASS, IDENT, '{', MethodDeclarations, '}'
#line 180 "parser.y"
                                                      { CurrentSemanticValue.normalClassDeclaration = new NormalClassDeclaration(ValueStack[ValueStack.Depth-6].modifiers, ValueStack[ValueStack.Depth-4].name, ValueStack[ValueStack.Depth-2].methodDeclarations);}
#line default
        break;
      case 22: // MethodDeclarations -> MethodDeclarations, MethodDeclaration
#line 188 "parser.y"
                                            { CurrentSemanticValue.methodDeclarations = ValueStack[ValueStack.Depth-2].methodDeclarations; CurrentSemanticValue.methodDeclarations.Add(ValueStack[ValueStack.Depth-1].methodDeclaration);}
#line default
        break;
      case 23: // MethodDeclarations -> /* empty */
#line 189 "parser.y"
                            { CurrentSemanticValue.methodDeclarations = new List<MethodDeclaration>(); }
#line default
        break;
      case 24: // MethodDeclaration -> Modifiers, IDENT, '(', FormalParameterList, ')', Statement
#line 195 "parser.y"
                                                             { CurrentSemanticValue.methodDeclaration = new MethodDeclaration(ValueStack[ValueStack.Depth-6].modifiers,ValueStack[ValueStack.Depth-5].name,ValueStack[ValueStack.Depth-3].formalParameterList,ValueStack[ValueStack.Depth-1].stmt);}
#line default
        break;
      case 25: // Modifier -> PUBLIC
#line 201 "parser.y"
                     {CurrentSemanticValue.modifier = Modifier.PUBLIC;}
#line default
        break;
      case 26: // Modifier -> STATIC
#line 202 "parser.y"
                           {CurrentSemanticValue.modifier = Modifier.STATIC;}
#line default
        break;
      case 27: // Modifier -> VOID
#line 203 "parser.y"
                     {CurrentSemanticValue.modifier = Modifier.VOID;}
#line default
        break;
      case 28: // Modifiers -> Modifiers, Modifier
#line 207 "parser.y"
                           {CurrentSemanticValue.modifiers = ValueStack[ValueStack.Depth-2].modifiers; CurrentSemanticValue.modifiers.Add(ValueStack[ValueStack.Depth-1].modifier);}
#line default
        break;
      case 29: // Modifiers -> /* empty */
#line 208 "parser.y"
                      {CurrentSemanticValue.modifiers = new List<Modifier>();}
#line default
        break;
      case 30: // Statement -> IF, '(', Expression, ')', Statement, ELSE, Statement
#line 212 "parser.y"
                                                           { CurrentSemanticValue.stmt = new IfStatement(ValueStack[ValueStack.Depth-5].expr, ValueStack[ValueStack.Depth-3].stmt, ValueStack[ValueStack.Depth-1].stmt); }
#line default
        break;
      case 31: // Statement -> '{', StatementList, '}'
#line 213 "parser.y"
                                        { CurrentSemanticValue.stmt = new CompoundStatement(ValueStack[ValueStack.Depth-2].stmts);   }
#line default
        break;
      case 32: // Statement -> Expression, ';'
#line 214 "parser.y"
                             { CurrentSemanticValue.stmt = new ExpressionStatement(ValueStack[ValueStack.Depth-2].expr); }
#line default
        break;
      case 33: // Statement -> UnAnnType, IDENT, ';'
#line 215 "parser.y"
                                 { CurrentSemanticValue.stmt = new VariableDeclaration(ValueStack[ValueStack.Depth-3].type,ValueStack[ValueStack.Depth-2].name); }
#line default
        break;
      case 34: // Statement -> WHILE, '(', Expression, ')', Statement
#line 216 "parser.y"
                                            { CurrentSemanticValue.stmt = new WhileStatement(ValueStack[ValueStack.Depth-3].expr,ValueStack[ValueStack.Depth-1].stmt);}
#line default
        break;
      case 35: // Statement -> DO, Statement, WHILE, '(', Expression, ')'
#line 217 "parser.y"
                                              { CurrentSemanticValue.stmt = new DoStatement(ValueStack[ValueStack.Depth-5].stmt, ValueStack[ValueStack.Depth-2].expr); }
#line default
        break;
      case 36: // Statement -> FOR, '(', Expression, ';', Expression, ';', Expression, ')', 
               //              Statement
#line 218 "parser.y"
                                                                      { CurrentSemanticValue.stmt = new BasicForStatement(ValueStack[ValueStack.Depth-7].expr, ValueStack[ValueStack.Depth-5].expr, ValueStack[ValueStack.Depth-3].expr, ValueStack[ValueStack.Depth-1].stmt);}
#line default
        break;
      case 37: // UnAnnType -> INT
#line 223 "parser.y"
                            { CurrentSemanticValue.type = new IntType(); }
#line default
        break;
      case 38: // UnAnnType -> BOOL
#line 224 "parser.y"
                              { CurrentSemanticValue.type = new BoolType(); }
#line default
        break;
      case 39: // FormalParameter -> UnAnnType, IDENT
#line 228 "parser.y"
                      {CurrentSemanticValue.formalParameter = new FormalParameter(ValueStack[ValueStack.Depth-2].type, ValueStack[ValueStack.Depth-1].name);}
#line default
        break;
      case 40: // FormalParameterList -> FormalParameterList, FormalParameter
#line 232 "parser.y"
                                              { CurrentSemanticValue.formalParameterList = ValueStack[ValueStack.Depth-2].formalParameterList; CurrentSemanticValue.formalParameterList.Add(ValueStack[ValueStack.Depth-1].formalParameter); }
#line default
        break;
      case 41: // FormalParameterList -> /* empty */
#line 233 "parser.y"
                                  { CurrentSemanticValue.formalParameterList = new List<FormalParameter>(); }
#line default
        break;
      case 42: // StatementList -> StatementList, Statement
#line 237 "parser.y"
                                                { CurrentSemanticValue.stmts = ValueStack[ValueStack.Depth-2].stmts; CurrentSemanticValue.stmts.Add(ValueStack[ValueStack.Depth-1].stmt);    }
#line default
        break;
      case 43: // StatementList -> /* empty */
#line 238 "parser.y"
                                    { CurrentSemanticValue.stmts = new List<Statement>(); }
#line default
        break;
      case 44: // Expression -> NUMBER
#line 241 "parser.y"
                              { CurrentSemanticValue.expr = new NumberExpression(ValueStack[ValueStack.Depth-1].num);         }
#line default
        break;
      case 45: // Expression -> IDENT
#line 242 "parser.y"
                             { CurrentSemanticValue.expr = new IdentifierExpression(ValueStack[ValueStack.Depth-1].name);     }
#line default
        break;
      case 46: // Expression -> TRUE
#line 243 "parser.y"
                      { CurrentSemanticValue.expr = new BooleanExpression(ValueStack[ValueStack.Depth-1].boolAnswer);        }
#line default
        break;
      case 47: // Expression -> FALSE
#line 244 "parser.y"
                       { CurrentSemanticValue.expr = new BooleanExpression(ValueStack[ValueStack.Depth-1].boolAnswer);        }
#line default
        break;
      case 48: // Expression -> Expression, '=', Expression
#line 245 "parser.y"
                                      { CurrentSemanticValue.expr = new AssignmentExpression(ValueStack[ValueStack.Depth-3].expr, ValueStack[ValueStack.Depth-1].expr); }
#line default
        break;
      case 49: // Expression -> Expression, '+', Expression
#line 246 "parser.y"
                                      { CurrentSemanticValue.expr = new BinaryExpression(ValueStack[ValueStack.Depth-3].expr,'+',ValueStack[ValueStack.Depth-1].expr);  }
#line default
        break;
      case 50: // Expression -> Expression, '<', Expression
#line 247 "parser.y"
                                      { CurrentSemanticValue.expr = new BinaryExpression(ValueStack[ValueStack.Depth-3].expr,'<',ValueStack[ValueStack.Depth-1].expr);  }
#line default
        break;
      case 51: // Expression -> Expression, '*', Expression
#line 248 "parser.y"
                                      { CurrentSemanticValue.expr = new BinaryExpression(ValueStack[ValueStack.Depth-3].expr,'*',ValueStack[ValueStack.Depth-1].expr);  }
#line default
        break;
      case 52: // Expression -> Expression, '-', Expression
#line 249 "parser.y"
                                      { CurrentSemanticValue.expr = new BinaryExpression(ValueStack[ValueStack.Depth-3].expr,'-',ValueStack[ValueStack.Depth-1].expr);  }
#line default
        break;
      case 53: // Expression -> Expression, INCREMENT_OPERATOR
#line 250 "parser.y"
                                         { CurrentSemanticValue.expr = new SimpleIncrementExpression(ValueStack[ValueStack.Depth-2].expr, ValueStack[ValueStack.Depth-1].name);	 }
#line default
        break;
      case 54: // Expression -> Expression, DECREMENT_OPERATOR
#line 251 "parser.y"
                                         { CurrentSemanticValue.expr = new SimpleIncrementExpression(ValueStack[ValueStack.Depth-2].expr, ValueStack[ValueStack.Depth-1].name);	 }
#line default
        break;
      case 55: // Expression -> INCREMENT_OPERATOR, Expression
#line 252 "parser.y"
                                         { CurrentSemanticValue.expr = new SimpleIncrementExpression(ValueStack[ValueStack.Depth-1].expr, ValueStack[ValueStack.Depth-2].name);	 }
#line default
        break;
      case 56: // Expression -> DECREMENT_OPERATOR, Expression
#line 253 "parser.y"
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

#line 257 "parser.y"

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
