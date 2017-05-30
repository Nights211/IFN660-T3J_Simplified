%namespace GPLexTutorial

%{
int lines = 0;
%}


digit [0-9]
letter [a-zA-Z]
OctalDigit  [0-7]
HexNumeral 0x|0X
HexDigit [0-9A-Fa-f]
hexdigitunderscore _{HexDigit}
BinaryDigit [0|1]
BinaryNumeral [b|B]
quote [\"']
stringcharacter [^\"]
underscore [_]
floattypesuffix [fFdD]
sign +|-
exponentIndicator [eE]
binaryexponentindicator [pP]
InputCharacter [^\n\r]
dot [.]

signedInteger {sign}?{digit}+
oneL [lL]

%%

if                           { return (int)Tokens.IF; }
else                         { return (int)Tokens.ELSE; }
class						 { return (int)Tokens.CLASS; }
public						 { return (int)Tokens.PUBLIC; }
int                          { return (int)Tokens.INT; }
bool						 { return (int)Tokens.BOOL; }
static						 { return (int)Tokens.STATIC; }		
void						 { return (int)Tokens.VOID; }
	

{letter}({letter}|{digit})*																	{ yylval.name = yytext; return (int)Tokens.IDENT; }								    //with underscore
{digit}+																					{ yylval.num = int.Parse(yytext); return (int)Tokens.NUMBER; }

"//"{InputCharacter}*					/* EndOfLineComment */											
"/*"({InputCharacter}|\n\r)*"*/"		/* TraditionalComment */																														//comments Awal
																							
"("                            { return '('; }
")"                            { return ')'; }
"{"                            { return '{'; }
"}"                            { return '}'; }
"["                            { return '['; }
"]"                            { return ']'; }
","                            { return ','; }
"@"                            { return '@'; }
";"                            { return ';'; }

/* Original working operators by Alex */

"="                            { return '='; }																																			//Operators Alex
">"                            { return '>'; }
"<"                            { return '<'; }
"!"                            { return '!'; }
"~"                            { return '~'; }
"?"							   { return '?'; }
"+"                            { return '+'; }
"-"                            { return '-'; }
"*"                            { return '*'; }
"/"                            { return '/'; }
"&"                            { return '&'; }
"|"                            { return '|'; }
"^"                            { return '^'; }
"%"                            { return '%'; }
":"                            { return ':'; }


[\n]		{ lines++;    }
[ \t\r]		/* ignore whitespace */ 
.			{ System.Console.Error.WriteLine("Unexpected character '{0}'", yytext); }

%%

void yyerror(string message)
{
    System.Console.Error.WriteLine("Error: line {0}, {1}", lines, message);
}
