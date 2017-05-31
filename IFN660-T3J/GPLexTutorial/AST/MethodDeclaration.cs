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
        public Statement args;
        public Statement methodBody;
        public List<Modifier> Modifiers;
        private string name;

        public MethodDeclaration(List<Modifier> modifiers, string methodHeader, Statement args, Statement methodBody)
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
                label(indent,"{0} ", modifier);
            }
            label(indent, "MethodDeclaration {0} (Argument: Right now is a Statment of some kind)\n", name);
            methodBody.dump(indent + 1);
        }

        public override bool ResolveNames(LexicalScope scope)
        {
            /* can't figure it out, commenting it out 

          

             bool check = true;
             if (methodBody != null)
             {
                 foreach (Statement i in methodsBody)
                 {
                     check = check & i.ResolveNames(scopestuffinhereShilpa);
                 }
             }
             return check;
            }
            */

            return true; // this really needs to be fixed by someone - Seth
        }
        public override void TypeCheck()
        {
            //foreach (var Statement in methodBody)
               // Statement.TypeCheck();
        }
        public override void GenCode(StreamWriter sw)
        {

            /* deal with this later - Seth

            string modifier = "";
            string parameter = "";
            MethodDeclarator methodDeclarator = methodHeader.GetMethodDeclarator();
            string methodName = methodDeclarator.GetName();
            List<FormalParameter> parameters = methodDeclarator.GetFormalParameters();
            foreach(FormalParameter p in parameters)
            {
                parameter += p.GetUnAnnArrayType() + p.GetVarDecId().GetArgName();
            }
            foreach (MethodModifier m in methodModifiers)
            {
                modifier += m.ToString();
            }
            emit(sw, ".method {0} {1} ( {2} ) { {3} }", modifier,methodName ,parameter, methodBody);

    */
        }

        UnAnnType Declaration.GetType()
        {
            throw new NotImplementedException(); // I can't figure this out - Seth

        }

        public string GetName()
        {
            throw new NotImplementedException();  // I have no idea how to do this - Seth
        }

        public int GetNumber()
        {
            return 0;
        }
    }
}
