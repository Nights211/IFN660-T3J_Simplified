using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPLexTutorial.AST
{
    public class EnumConstant:Node
    {
        public string name;
        public List<Expression> arguements;
        public List<MethodDeclaration> classBody;

        public EnumConstant(string name, List<MethodDeclaration> classBody, List<Expression> arguements)
        {
            this.name = name;
            this.classBody = classBody;
            this.arguements = arguements;
        }

        public override void ResolveNames(LexicalScope scope)
        {
            foreach (MethodDeclaration Method in classBody)
                Method.ResolveNames(scope);
            foreach (Expression arguement in arguements)
                arguement.ResolveNames(scope);
        }

        public override void dump(int indent)
        {
            label(indent, "EnumConstant {0}\n", name);
           foreach (MethodDeclaration child in classBody)
            {
                child.dump(indent + 1);
            }
            foreach (Expression arguement in arguements)
            {
                arguement.dump(indent + 1);
            }
        }

        public override void TypeCheck()
        {
            foreach (Expression arguement in arguements)
            {
                arguement.TypeCheck();
            }
        }

        public override void GenCode(StreamWriter sw)
        {
            throw new NotImplementedException();
        }
    }
}
