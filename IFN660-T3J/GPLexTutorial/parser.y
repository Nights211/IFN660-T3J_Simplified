﻿%namespace GPLexTutorial
%using GPLexTutorial.AST


%{
public static NormalClassDeclaration root;
%}

%union
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


%token <num> NUMBER
%token <name> IDENT
%token <boolAnswer> TRUE
%token <boolAnswer> FALSE

%token IF ELSE INT BOOL ABSTRACT OPERATOR PUBLIC CLASS STATIC VOID WHILE DO TRUE FALSE

%type <compilationUnit> CompilationUnit 



%type <expr> Expression
%type <stmt> Statement
%type <type> UnAnnType
%type <stmts> StatementList


%type <modifier> Modifier																			// seth
%type <modifiers> Modifiers

%type <methodDeclaration> MethodDeclaration
%type <methodDeclarations> MethodDeclarations

%type <normalClassDeclaration> NormalClassDeclaration

%type <formalParameter> FormalParameter
%type <formalParameterList> FormalParameterList

%left '='
%nonassoc '<'
%left '+'
%%

Program
	: CompilationUnit 
	;



CompilationUnit
	: NormalClassDeclaration		{root = $1;}						        
	;

	
NormalClassDeclaration
	: Modifiers CLASS IDENT '{' MethodDeclarations '}' 		{ $$ = new NormalClassDeclaration($1, $3, $5);}		
	;

ClassBody
	:
	;

MethodDeclarations
	: MethodDeclarations MethodDeclaration					{ $$ = $1; $$.Add($2);}				    	
    | /* empty */											{ $$ = new List<MethodDeclaration>(); }
    ;



MethodDeclaration
	: Modifiers IDENT '(' FormalParameterList ')' Statement					{ $$ = new MethodDeclaration($1,$2,$4,$6);}	 //I know having the argument as a statement is wrong but I can't be bothered fixing that now 
	;



Modifier
	: PUBLIC												{$$ = Modifier.PUBLIC;} 											     
	| STATIC        										{$$ = Modifier.STATIC;}
	| VOID 													{$$ = Modifier.VOID;}
	;

Modifiers																					
	: Modifiers Modifier						{$$ = $1; $$.Add($2);}												
	| /* Empty */								{$$ = new List<Modifier>();}											
	;


Statement : IF '(' Expression ')' Statement ELSE Statement	{ $$ = new IfStatement($3, $5, $7); }
          | '{' StatementList '}'							{ $$ = new CompoundStatement($2);   }
		  | Expression ';'									{ $$ = new ExpressionStatement($1); }
		  | UnAnnType IDENT ';'								{ $$ = new VariableDeclaration($1,$2); }
		  | WHILE '(' Expression ')' Statement				{ $$ = new WhileStatement($3,$5);}
		  | DO Statement WHILE '(' Expression ')'			{ $$ = new DoStatement($2, $5); }
		  ;



UnAnnType : INT											 	{ $$ = new IntType(); }
          | BOOL										    { $$ = new BoolType(); }
	      ;

FormalParameter
	: UnAnnType IDENT				{$$ = new FormalParameter($1, $2);}
	;

FormalParameterList
	: FormalParameterList FormalParameter				    { $$ = $1; $$.Add($2); }
    | /* empty */									        { $$ = new List<FormalParameter>(); }
	;
	 

StatementList : StatementList Statement				    	{ $$ = $1; $$.Add($2);    }
              | /* empty */									{ $$ = new List<Statement>(); }
			  ;

Expression : NUMBER											{ $$ = new NumberExpression($1);         }
           | IDENT											{ $$ = new IdentifierExpression($1);     }
		   | TRUE											{ $$ = new BooleanExpression($1);        }
		   | FALSE											{ $$ = new BooleanExpression($1);        }
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