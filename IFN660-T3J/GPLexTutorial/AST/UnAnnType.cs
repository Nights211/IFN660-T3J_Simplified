using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPLexTutorial.AST
{
    public abstract class UnAnnType : Node
    {
        public bool Compatible(UnAnnType other)
        {
            return Equal(other);
        }

        public abstract string CLRName();

        public abstract bool Equal(UnAnnType other);
    }

    public enum type { INT, VOID, BooleanLiteral };

    public class IntType : UnAnnType
    {

        public IntType()
        {
        }
        public override void dump(int indent)
        {
            label(indent, "IntType\n");
        }

        public override void ResolveNames(LexicalScope scope)
        {
            
        }
        public override void TypeCheck()
        {
        }
        public override void GenCode(StreamWriter sw)
        {
            throw new NotImplementedException();
        }
        public override bool Equal(UnAnnType other)
        {
            return other as IntType != null;
        }

        public override string CLRName()
        {
            return "int32";
        }
    }
    public class BoolType : UnAnnType
    {
        public BoolType()
        {
        }
        public override void dump(int indent)
        {
            label(indent, "BoolType\n");
        }

        public override void ResolveNames(LexicalScope scope)
        {
            
        }
        public override void TypeCheck()
        {
        }
        public override void GenCode(StreamWriter sw)
        {
            throw new NotImplementedException();
        }

        public override bool Equal(UnAnnType other)
        {
            return other as BoolType != null;
        }

        public override string CLRName()
        {
            return "bool";
        }

        public string CLRNames()
        {
            return "bool";
        }
    }
}
