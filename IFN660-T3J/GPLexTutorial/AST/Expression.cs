using System;
using System.IO;

namespace GPLexTutorial.AST
{
    public abstract class Expression : Node
    {
        public UnAnnType type;
        public abstract override void GenCode(StreamWriter sw);
        public abstract void GenStoreCode(StreamWriter sw);
    }

    public class AssignmentExpression : Expression
    {
        private Expression lhs, rhs;

        public AssignmentExpression(Expression lhs, Expression rhs)
        {
            this.lhs = lhs;
            this.rhs = rhs;
        }

        public override void dump(int indent)
        {
            label(indent, "AssignmentExpression\n");
            lhs.dump(indent + 1, "lhs");
            rhs.dump(indent + 1, "rhs");
        }

        public override void GenCode(StreamWriter sw)
        {
            rhs.GenCode(sw);
            lhs.GenStoreCode(sw);
            lhs.GenCode(sw);
        }

        public override void GenStoreCode(StreamWriter sw)
        {
            throw new NotImplementedException();
        }

        public override void ResolveNames(LexicalScope scope)
        {
            lhs.ResolveNames(scope);
            rhs.ResolveNames(scope);
        }
        public override void TypeCheck()
        {
            lhs.TypeCheck();
            rhs.TypeCheck();
            if (!rhs.type.Compatible(lhs.type))
            {
                Console.Error.WriteLine("Type Error in Assignment\n");
                throw new Exception("TypeCheck Error");
            }
            type = rhs.type;
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

        public override void dump(int indent)
        {
            label(indent, "PlusExpression\n");
            lhs.dump(indent + 1, "lhs");
            rhs.dump(indent + 1, "rhs");
        }

        public override void ResolveNames(LexicalScope scope)
        {
            lhs.ResolveNames(scope);
            rhs.ResolveNames(scope);
        }
        public override void TypeCheck()
        {
            lhs.TypeCheck();
            rhs.TypeCheck();
            if (!rhs.type.Compatible(lhs.type))
            {
                Console.Error.WriteLine("Type Error in Plus\n");
                throw new Exception("TypeCheck Error");
            }
            type = rhs.type;
        }
        public override void GenCode(StreamWriter sw)
        {
            lhs.GenCode(sw);
            rhs.GenCode(sw);
            emit(sw, "add");

        }
        public override void GenStoreCode(StreamWriter sw)
        {
            throw new NotImplementedException();
        }
    }

    public class NumberExpression : Expression
    {
        private int value;
        public NumberExpression(int value)
        {
            this.value = value;
        }
        public override void dump(int indent)
        {
            label(indent, "NumberExpression {0}\n", value);
            type.dump(indent + 1);
        }

        public override void ResolveNames(LexicalScope scope)
        {

        }
        public override void TypeCheck()
        {
            type = new IntType();
        }
        public override void GenCode(StreamWriter sw)
        {
            emit(sw, "ldc.i4 {0}", value);
        }

        public override void GenStoreCode(StreamWriter sw)
        {
            throw new NotImplementedException();
        }
    };

    public class BinaryExpression : Expression
    {
        private char op;
        private Expression lhs, rhs;
        public BinaryExpression(Expression lhs, char op, Expression rhs)
        {
            this.op = op;
            this.lhs = lhs;
            this.rhs = rhs;
        }
        public override void dump(int indent)
        {
            label(indent, "BinaryExpression {0}\n", op);
            lhs.dump(indent + 1, "lhs");
            rhs.dump(indent + 1, "rhs");
        }

        public override void ResolveNames(LexicalScope scope)
        {
            lhs.ResolveNames(scope);
            rhs.ResolveNames(scope);
        }
        public override void TypeCheck()
        {
            lhs.TypeCheck();
            rhs.TypeCheck();

            switch (op)
            {
                case '<':
                    if (!lhs.type.Compatible(rhs.type))
                    {
                        Console.Error.WriteLine("invalid arguments for less than expression\n");
                        throw new Exception("TypeCheck error");
                    }
                    type = new BoolType(); 
                    break;
                case '+':
                    if (!lhs.type.Compatible(rhs.type))
                    {
                        Console.Error.WriteLine("invalid arguments for addition expression\n");
                        throw new Exception("TypeCheck error");
                    }
                    type = new IntType();
                    break;
                default:
                    Console.Error.WriteLine("Unexpected binary operator '%c'\n", op);
                    throw new Exception("TypeCheck error");
            }

        }

        public override void GenCode(StreamWriter sw)
        {
            lhs.GenCode(sw);
            rhs.GenCode(sw);

            switch (op)
            {
                case '<':
                    emit(sw, "clt");
                    break;
                case '+':
                    emit(sw, "add");
                    break;
                default:
                    Console.Error.WriteLine("Unexpected binary operator '%c'\n", op);
                    break;
            }
        }
        public override void GenStoreCode(StreamWriter sw)
        {
            throw new NotImplementedException();
        }
    }
    public class IdentifierExpression : Expression
    {
        private String name;
        public Declaration declaration { get; set; }

        public IdentifierExpression(String name)
        {
            this.name = name;
        }
        public override void dump(int indent)
        {
            label(indent, "IdentifierExpression {0}\n", name);
        }

        public override void ResolveNames(LexicalScope scope)
        {
            if (scope != null)
            {
                declaration = scope.Resolve(name);
                if (declaration == null)
                {
                    Console.Error.WriteLine("Error: Undeclared identifier {0}\n", name);
                    throw new Exception("Name Resolution error");
                }

            }
        }
        public override void TypeCheck()
        {
            type = declaration.GetType();
        }
        public override void GenCode(StreamWriter sw)
        {
            emit(sw, "ldloc {0}", name);
        }
        public override void GenStoreCode(StreamWriter sw)
        {
            emit(sw, "stloc {0}", name);
        }
    }
    public class BooleanExpression : Expression
    {
        private bool value;
        public BooleanExpression(bool value)
        {
            this.value = value;
        }
        public override void dump(int indent)
        {
            label(indent, "BooleanExpression {0}\n", value);
            type.dump(indent + 1);
        }
        public override void ResolveNames(LexicalScope scope)
        {

        }
        public override void TypeCheck()
        {
            type = new BoolType();
        }
        public override void GenCode(StreamWriter sw)
        {
            emit(sw, "{0}", value);
        }

        public override void GenStoreCode(StreamWriter sw)
        {
            throw new NotImplementedException();
        }
    }
}