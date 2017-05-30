using System;
using System.IO;

namespace GPLexTutorial.AST
{
    public abstract class Expression : Node
    {
        public UnAnnType type;
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
            throw new NotImplementedException();
        }

        public override void GenStoreCode(StreamWriter sw)
        {
            throw new NotImplementedException();
        }

        public override bool ResolveNames(LexicalScope scope)
        {
            return lhs.ResolveNames(scope) && rhs.ResolveNames(scope);
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

        public override bool ResolveNames(LexicalScope scope)
        {
            return lhs.ResolveNames(scope) && rhs.ResolveNames(scope);
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
            throw new NotImplementedException();
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
        }

        public override bool ResolveNames(LexicalScope scope)
        {
            return true;
        }
        public override void TypeCheck()
        {
            // type.TypeCheck();
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

        public override bool ResolveNames(LexicalScope scope)
        {
            return lhs.ResolveNames(scope) && rhs.ResolveNames(scope);
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

                    break;
                case '+':
                    if (!lhs.type.Compatible(rhs.type))
                    {
                        Console.Error.WriteLine("invalid arguments for addition expression\n");
                        throw new Exception("TypeCheck error");
                    }

                    break;
                default:
                        Console.Error.WriteLine("Unexpected binary operator '%c'\n", op);
                        throw new Exception("TypeCheck error");
            }

        }

        public override void GenCode(StreamWriter sw)
        {
            throw new NotImplementedException();
        }
        public override void GenStoreCode(StreamWriter sw)
        {
            throw new NotImplementedException();
        }
    }
    public class IdentifierExpression : Expression
    {
        private String name;
        public IdentifierExpression(String name)
        {
            this.name = name;
        }
        public override void dump(int indent)
        {
            label(indent, "IdentifierExpression {0}\n", name);
        }

        public override bool ResolveNames(LexicalScope scope)
        {
            return true;
        }
        public override void TypeCheck()
        {
        }
        public override void GenCode(StreamWriter sw)
        {
            throw new NotImplementedException();
        }
        public override void GenStoreCode(StreamWriter sw)
        {
            throw new NotImplementedException();
        }
    }
}