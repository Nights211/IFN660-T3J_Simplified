using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPLexTutorial.AST
{
    public class FormalParameter : Expression
    {
        private List<VariableModifier> variableModifiers;
        private string varDecId;
        private UnAnnArrayType type;
        public FormalParameter(List<VariableModifier> variableModifiers, UnAnnArrayType type, string varDecId)
        {
            this.variableModifiers = variableModifiers;
            this.varDecId = varDecId;
            this.type = type;
        }

        //public UnAnnArrayType GetUnAnnArrayType() { return type; }
       // public VariableDeclaratorId GetVarDecId() { return varDecId; }
        public override void dump(int indent)
        {
            
            label(indent, "FormalParameter\n");
           // varDecId.dump(indent + 1, "VariableDeclaratorId"); - Not working, - Seth
            type.dump(indent + 1, "UnAnnArrayType");
            
        }

        public override bool ResolveNames(LexicalScope scope)
        {
           // return type.ResolveNames(scope) && varDecId.ResolveNames(scope); - ResolveNames doesn't work with strings for some reason
            return true;
        }
        public override void TypeCheck()
        {
            type.TypeCheck();
        }
        public override void GenCode(StreamWriter sw)
        {
            throw new NotImplementedException();
        }

        public override void GenStoreCode(StreamWriter sw)
        {
            throw new NotImplementedException();
        }

        public string GetName()
        {
            return varDecId;
        }

        public int GetNumber()
        {
            throw new NotImplementedException(); // - This actually needs to be done for this one, I don't know why - Seth
        }
    }
}
