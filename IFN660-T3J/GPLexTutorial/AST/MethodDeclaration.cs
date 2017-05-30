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

        public List<Statement> methodBody;
        public List<MethodModifier> methodModifiers { get; set; }
        private MethodHeader methodHeader;

        public MethodDeclaration(List<MethodModifier> methodModifiers, MethodHeader methodHeader, List<Statement> methodBody)
        {
            this.methodModifiers = methodModifiers;
            this.methodHeader = methodHeader;
            this.methodBody = methodBody;
        }




        public override void dump(int indent)
        { }

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
            foreach (var Statement in methodBody)
                Statement.TypeCheck();
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

        public string GetName()
        {
            throw new NotImplementedException();  // I have no idea how to do this - Seth
        }

        UnAnnType Declaration.GetType()
        {
            throw new NotImplementedException(); // I can't figure this out - Seth

        }

        public int GetNumber()
        {
            return 0;
        }
    }
}
