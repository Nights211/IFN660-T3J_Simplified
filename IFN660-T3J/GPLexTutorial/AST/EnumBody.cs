using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPLexTutorial.AST
{
    public class EnumBody:Node
    {
        public List<EnumConstant> enumConstantList;
        //public List<MethodDeclaration> classBody;

        public EnumBody(/*string name, List<MethodDeclaration> classBody,*/ List<EnumConstant> enumConstantList)
        {
            //this.classBody = classBody;
           this.enumConstantList = enumConstantList;
        }

        public override void ResolveNames(LexicalScope scope)
        {
            foreach (EnumConstant arguement in enumConstantList)
                arguement.ResolveNames(scope);
        }

        public override void dump(int indent)
        {
            label(indent, "EnumBody");
            foreach (EnumConstant arguement in enumConstantList)
            {
                arguement.dump(indent + 1);
            }
        }

        public override void TypeCheck()
        {
            foreach (EnumConstant arguement in enumConstantList)
            {
                arguement.TypeCheck();
            }
        }

        public override void GenCode(StreamWriter sw)
        {
           
            foreach (EnumConstant modifier in enumConstantList)
            {
                    modifier.GenCode(sw);
                
            }
            
        }
    }
}
