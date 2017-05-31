using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPLexTutorial.AST
{
    public class ClassBody : Node
    {
        private List<MethodDeclaration> methodDeclarations;

        public ClassBody(List<MethodDeclaration> methodDeclarations)
        {
            this.methodDeclarations = methodDeclarations;
        }
        public override void dump(int indent)
        {

            foreach (var child in methodDeclarations)
                child.dump(indent + 1);

        }

        public override bool ResolveNames(LexicalScope scope)
        {
            bool allOK = true;
            foreach (var methodDeclaration in methodDeclarations)
            {
                if (!methodDeclaration.ResolveNames(scope))
                {
                    allOK = false;
                }

            }
            return allOK;
        }
        public override void TypeCheck()
        {
            foreach (var methodDeclaration in methodDeclarations)
            {
                methodDeclaration.TypeCheck();
            }
        }
        public override void GenCode(StreamWriter sw)
        {
            throw new NotImplementedException();
        }
    }
}
