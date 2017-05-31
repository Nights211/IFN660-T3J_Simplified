using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPLexTutorial.AST
{
    public class MethodDeclarator: Node, Declaration
    {
        private String name;
        public List<FormalParameter> formalParameters;
        public LexicalScope lexicalScope { get; set; }
        public String GetName() { return name; }
        public List<FormalParameter> GetFormalParameters() { return formalParameters; }

        /* public List<FormalParameter> FormalParameters { get; set; }

        I have a feeling this might be needed later */ 

        public MethodDeclarator(String name, List<FormalParameter> formalParameters)
        {
            this.name = name;
            this.formalParameters = formalParameters;
        }



        public override void dump(int indent)
        {
            label(indent, "MethodDeclarator {0}\n", name);
            
            foreach (var child in formalParameters)
                child.dump(indent + 1);
        }
        public override void ResolveNames(LexicalScope scope)
        {
            lexicalScope = new LexicalScope(scope);
            lexicalScope.symbol_table.Add(GetName(), this);
            foreach (var formalParameter in formalParameters)
            {
                formalParameter.ResolveNames(scope);
            }
        }
        public override void TypeCheck()
        {
            foreach (var formalParameter in formalParameters)
            {
                formalParameter.TypeCheck();
            }
        }
        public override void GenCode(StreamWriter sw)
        {
            throw new NotImplementedException();
        }

        UnAnnType Declaration.GetType()
        {
            throw new NotImplementedException();
        }

        public int GetNumber()
        {
            throw new NotImplementedException();
        }
    }
}
