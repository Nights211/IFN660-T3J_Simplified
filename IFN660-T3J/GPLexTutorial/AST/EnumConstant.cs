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
        public List<MethodDeclaration> classBody;

        public EnumConstant(string name, List<MethodDeclaration> classBody)
        {
            this.name = name;
            this.classBody = classBody;
        }

        public override void ResolveNames(LexicalScope scope)
        {
            foreach (MethodDeclaration Method in classBody)
                Method.ResolveNames(scope);
        }

        public override void dump(int indent)
        {
            label(indent, "EnumConstant {0}\n", name);
           foreach (MethodDeclaration child in classBody)
            {
                child.dump(indent + 1);
            }
        }

        public override void TypeCheck()
        {
            foreach (MethodDeclaration Method in classBody)
            {
                Method.TypeCheck();
            }
        }

        public override void GenCode(StreamWriter sw)
        {
            throw new NotImplementedException();
        }
    }
}
