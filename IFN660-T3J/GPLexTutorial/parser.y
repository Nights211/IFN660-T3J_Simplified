﻿%namespace GPLexTutorial
%using GPLexTutorial.AST


%{
public static MethodDeclaration root;
%}

%union
{
	public Expression expr;
	public Statement stmt;
	public UnAnnType type;
	public System.Collections.Generic.List<Statement> stmts;

    
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
	public MethodModifier methodModifier;
	public List<MethodModifier> methodModifiers;
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


%token <num> NUMBER
%token <name> IDENT
%token IF ELSE INT BOOL ABSTRACT OPERATOR PUBLIC CLASS STATIC VOID WHILE TRUE FALSE

%type <compilationUnit> CompilationUnit 



%type <expr> Expression
%type <stmt> Statement
%type <type> UnAnnType
%type <stmts> StatementList


%type <methodModifier> MethodModifier																			// seth
%type <methodModifiers> MethodModifiers
%type <methodDeclaration> MethodDeclaration

%left '='
%nonassoc '<'
%left '+'
%%

Program
	: CompilationUnit 
	;

CompilationUnit
	: MethodDeclaration					{root = $1;}				        
	;


MethodDeclaration
	: MethodModifiers IDENT Statement														{$$ = new MethodDeclaration($1,$2,$3);}
	;

MethodModifier
	: PUBLIC												{$$ = MethodModifier.PUBLIC;} 											     
	| STATIC        										{$$ = MethodModifier.STATIC;} 											
	;

MethodModifiers																					
	: MethodModifiers MethodModifier						{$$ = $1; $$.Add($2);}												
	| /* Empty */											{$$ = new List<MethodModifier>();}											
	;



Statement : IF '(' Expression ')' Statement ELSE Statement	{ $$ = new IfStatement($3, $5, $7); }
          | '{' StatementList '}'							{ $$ = new CompoundStatement($2);   }
		  | Expression ';'									{ $$ = new ExpressionStatement($1); }
		  | UnAnnType IDENT ';'								{ $$ = new VariableDeclaration($1,$2); }
		  ;

UnAnnType : INT											 	{ $$ = new IntType(); }
          | BOOL										    { $$ = new BoolType(); }
	      ;

StatementList : StatementList Statement				    	{ $$ = $1; $$.Add($2);    }
              | /* empty */									{ $$ = new List<Statement>(); }
			  ;

Expression : NUMBER											{ $$ = new NumberExpression($1);         }
           | IDENT											{ $$ = new IdentifierExpression($1);     }
		   | Expression '=' Expression						{ $$ = new AssignmentExpression($1, $3); }
		   | Expression '+' Expression						{ $$ = new BinaryExpression($1,'+',$3);  }
		   | Expression '<' Expression						{ $$ = new BinaryExpression($1,'<',$3);  }
		   ;

%%

int yywrap()
{
    return 1;
}

public Parser(Scanner scanner) : base(scanner)
{
}