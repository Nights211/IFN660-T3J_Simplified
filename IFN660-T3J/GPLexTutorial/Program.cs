using System;
using System.IO;
using GPLexTutorial.AST;
using System.Collections.Generic;
namespace GPLexTutorial
{
    class Program
    {
        
        
        public static void SemanticAnalysis(Node root)
        {
            root.ResolveNames(null);
            root.TypeCheck();
        }
        static void Main(string[] args)
        {

            Scanner scanner = new Scanner(new FileStream(args[0], FileMode.Open));
            /*
            Tokens token;
            do
            {
                token = (Tokens)scanner.yylex();
                Console.WriteLine("token {0}", token);
            }
            while (token != Tokens.EOF);
            */

            Parser parser = new Parser(scanner);
            parser.Parse();

            if (Parser.root == null)
            {
                Console.WriteLine("Root is Null");
            } else
            {
                Parser.root.dump(0);
            }
            

            /*
            Parser.root.dump(0);
            CompilationUnit compilationUnit = new CompilationUnit(null, null,
            new List<TypeDeclaration>{
            new NormalClassDeclaration(
            new List<Modifier> (){Modifier.PUBLIC}, "HelloWorld",
            new ClassBody(
                new List<MethodDeclaration>{
                    new MethodDeclaration(
                        new List<MethodModifier>(){MethodModifier.PUBLIC,MethodModifier.STATIC},
                        new MethodHeader(
                            new Result(
                                new PrimitiveType(type.VOID)),
                            new MethodDeclarator( "main",
                            new List<FormalParameter>{
                                new FormalParameter(
                                    new List<VariableModifier>(),
                                    new UnAnnArrayType(),
                                    new VariableDeclaratorId("args"))})),
                        new MethodBody(
                            new Block(
                                new CompoundStatement(
                                    new List<Statement>{
                                        new VariableDeclaration(
                                            new PrimitiveType(type.INT), "x"),
                                        new ExpressionStatement(
                                            new AssignmentExpression(
                                                new IdentifierExpression("x"),
                                                new NumberExpression(42)))}))))}))});
                                                */

            //if (Parser.root != null)
            {
            //root->dump(0);
            //SemanticAnalysis(Parser.root);
            //compilationUnit.dump(0);
            //var outfile = new StreamWriter(args[0] + ".il");
            //Parser.root.GenCode(outfile);
            //outfile.Close();
            }
            //compilationUnit.dump(1);
        }
    }
}