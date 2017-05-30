using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AST_Testing
{
    public abstract class Node
    {
        void Indent(int n)
        {
            for (int i = 0; i < n; i++)
                Console.Write("    ");
        }

        public void DumpValue(int indent)
        {
            Indent(indent);
            Console.WriteLine("{0}", GetType().ToString());

            Indent(indent);
            Console.WriteLine("{");

            foreach (var field in GetType().GetFields(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance))
            {
                object value = field.GetValue(this);
                Indent(indent + 1);
                if (value is Node)
                {
                    Console.WriteLine("{0}: ", field.Name);
                    ((Node)value).DumpValue(indent + 2);
                }
                else if (value is IEnumerable && !(value is String))
                {
                    Console.WriteLine("{0}: [", field.Name);
                    var list = (IEnumerable)value;
                    foreach (var item in list)
                    {
                        if (item is Node)
                            ((Node)item).DumpValue(indent + 2);
                        else
                        {
                            Indent(indent + 2);
                            Console.WriteLine(item);
                        }
                    }
                    Indent(indent + 1);
                    Console.WriteLine("]");
                }
                else
                    Console.WriteLine("{0}: {1}", field.Name, value);
            }

            Indent(indent);
            Console.WriteLine("}");
        }
    };

    public abstract class Expression : Node { };
    public abstract class Statement : Node { };

    public abstract class PackageDeclaration : Node { };

    public abstract class ImportDeclaration : Node { };

    public abstract class TypeDeclaration : Node { };

    public enum Modifier
    {
        PUBLIC,
        STATIC
    };
    public enum NumericType
    {
        Int,
        String,
        VOID
    };

    public class CompilationUnit : Node
    {

        public CompilationUnit(PackageDeclaration packageDeclaration, ImportDeclaration importDeclaration, List<TypeDeclaration> typeDeclarations)
        {
            this.packageDeclaration = packageDeclaration;
            this.importDeclaration = importDeclaration;
            this.typeDeclarations = typeDeclarations;
        }

        private PackageDeclaration packageDeclaration;

        private ImportDeclaration importDeclaration;

        private List<TypeDeclaration> typeDeclarations;

    };

    public class ClassDeclaration : TypeDeclaration
    {
        public ClassDeclaration(List<Modifier> modifiers, String name, List<MethodDeclaration> methods)
        {
            this.modifiers = modifiers;
            this.name = name;
            this.methods = methods;
        }
        private List<Modifier> modifiers;
        private List<MethodDeclaration> methods;
        private String name;



    }
    public class MethodDeclaration : Node
    {
        public MethodDeclaration(List<Modifier> modifiers, Type returnType, String name, List<FormalParameter> formalParameters, List<Statement> statements)
        {
            this.modifiers = modifiers;
            this.name = name;
            this.formalParameters = formalParameters;
            this.returnType = returnType;
            this.statements = statements;
        }

        private List<Modifier> modifiers;
        private String name;
        private List<FormalParameter> formalParameters;
        private Type returnType;
        private List<Statement> statements;

    }


    public class FormalParameter : Node
    {
        private String argName;
        private Type type;
        public FormalParameter(String argName, Type type)
        {
            this.argName = argName;
            this.type = type;
        }
    }
    public abstract class Type : Node
    {
    }
    public class ArrayType : Type
    {
        private String elementType;
        public ArrayType(String elementType)
        {
            this.elementType = elementType;
        }
    }
    public class NameType : Type
    {
        private List<NumericType> type;
        public NameType(List<NumericType> type)
        {
            this.type = type;
        }
    }
    public class IfStatement : Statement
    {
        private Expression Cond;
        private Statement Then, Else;
        public IfStatement(Expression Cond, Statement Then, Statement Else)
        {
            this.Cond = Cond; this.Then = Then; this.Else = Else;
        }
    };
    public class PlusExpression : Expression
    {
        private Expression lhs, rhs;
        public PlusExpression(Expression lhs, Expression rhs)
        {
            this.lhs = lhs;
            this.rhs = rhs;
        }
    };
    public class IntegerLiteral : Expression
    {
        private int value;
        public IntegerLiteral(int value)
        {
            this.value = value;
        }
    };
    public class LocalVariableDeclaration : Statement
    {

        private Type type;
        private Identifier identifier;
        public LocalVariableDeclaration(Type type, Identifier identifier)
        {
            this.identifier = identifier;
            this.type = type;
        }
    }
    public class AssignmentStatement : Statement
    {
        private Expression lhs, rhs;
        public AssignmentStatement(Expression lhs, Expression rhs)
        {
            this.lhs = lhs;
            this.rhs = rhs;
        }
    }
    public class Identifier : Expression
    {
        private string identifier;
        public Identifier(String identifier)
        {
            this.identifier = identifier;
        }
    }
    class Program


    {
        static void Main(string[] args)
        {
            CompilationUnit compilationUnit = new CompilationUnit(null, null,
                                                  new List<TypeDeclaration>{
                                                      new ClassDeclaration(
                                                          new List<Modifier> { Modifier.PUBLIC }, "HelloWorld",
                                                              new List<MethodDeclaration> {
                                                                   new MethodDeclaration(new List<Modifier> { Modifier.PUBLIC , Modifier.STATIC },                                         
                                                                        new NameType(new List<NumericType> { NumericType.VOID}),"main",
                                                                            new List<FormalParameter> { new FormalParameter("args", new ArrayType("String[]")) },
                                                                                    new List<Statement> { new LocalVariableDeclaration(new NameType(new List<NumericType> { NumericType.Int}), new Identifier("x")),
                                                                                        new AssignmentStatement(new Identifier("x"),new IntegerLiteral(42))}
                                                                                    )})});
            compilationUnit.DumpValue(1);

        }

    }

}
