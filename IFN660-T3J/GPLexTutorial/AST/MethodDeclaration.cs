using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPLexTutorial.AST
{
    public class MethodDeclaration : Statement, Declaration
    {

        public Statement methodBody;
        public List<MethodModifier> methodModifiers;
        private string name;

        public MethodDeclaration(List<MethodModifier> methodModifiers, string methodHeader, Statement methodBody)
        {
            this.methodModifiers = methodModifiers;
            this.name = methodHeader;
            this.methodBody = methodBody;
        }




        public override void dump(int indent)
        {
            label(indent, "MethodDeclaration{0}\n", name);
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
