using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPLexTutorial.AST
{
    public class MethodHeader : Node
    {
        public MethodHeader(Result returnType, MethodDeclarator methodDeclarator)
        {
            this.returnType = returnType;
            this.methodDeclarator = methodDeclarator;

        }
        
        private Result returnType;
        private MethodDeclarator methodDeclarator;

        public MethodDeclarator GetMethodDeclarator() { return methodDeclarator; }

        public override void dump(int indent)
        {
            label(indent, "MethodHeader\n");
           returnType.dump(indent + 1, "returnType");
            methodDeclarator.dump(indent + 1, "methodDeclarator");
        }

        public override bool ResolveNames(LexicalScope scope)
        {
            return returnType.ResolveNames(scope) && methodDeclarator.ResolveNames(scope);
        }
        public override void TypeCheck()
        {
            returnType.TypeCheck();
        }
        public override void GenCode(StreamWriter sw)
        {
            throw new NotImplementedException();
        }
    }
}
