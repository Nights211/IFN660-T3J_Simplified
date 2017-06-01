using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPLexTutorial.AST
{
    public class MethodDeclaration : Node, Declaration
    {
        public List<FormalParameter> args;
        public Statement methodBody;
        public List<Modifier> Modifiers;
        private String name;
        public LexicalScope lexicalScope{get;set;}
        public MethodDeclaration(List<Modifier> modifiers, String methodHeader, List<FormalParameter> args, Statement methodBody)
        {
            this.Modifiers = modifiers;
            this.name = methodHeader;
            this.methodBody = methodBody;
            this.args = args;

        }




        public override void dump(int indent)
        {
            foreach (Modifier modifier in Modifiers)
            {
                label(indent,"{0}", modifier);
            }
            label(indent, "MethodDeclaration {0}", name);
            foreach (FormalParameter child in args)
                child.dump(indent + 1);
            methodBody.dump(indent + 1);
        }

        public override void ResolveNames(LexicalScope scope)
        {
;
            methodBody.ResolveNames(scope);
                    foreach(var arg in args)
            {
                arg.ResolveNames(scope);
            }
        }
        public override void TypeCheck()
        {
            methodBody.TypeCheck();
        }
        public override void GenCode(StreamWriter sw)
        {
            emit(sw, ".method ");
            foreach (Modifier modifier in Modifiers)
            {
                emit(sw,"{0} ", modifier);
            }
            emit(sw, "{0}(string[] args)" + Environment.NewLine + "{{" + Environment.NewLine, name);
            emit(sw, ".entrypoint" + Environment.NewLine);
            methodBody.GenCode(sw);
            emit(sw, "ret" + Environment.NewLine);
            emit(sw, "}}" + Environment.NewLine);

        }

        UnAnnType Declaration.GetType()
        {
            throw new NotImplementedException(); // I can't figure this out - Seth

        }

        public String GetName()
        {
            return name;  // I have no idea how to do this - Seth
        }

        public int GetNumber()
        {
            return 0;
        }
    }
}
