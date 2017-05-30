using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPLexTutorial.AST
{
   public class UnAnnArrayType:UnAnnType
    {
    
        public override void dump(int indent)
        {
            label(indent, "UnannArrayType\n");
        }

        public override bool ResolveNames(LexicalScope scope)
        {
            return true;
        }
        public override void TypeCheck()
        {
        }
        public override void GenCode(StreamWriter sw)
        {
            throw new NotImplementedException();
        }
        public override bool Equal(UnAnnType a)
        {
            throw new NotImplementedException();
        }
    }
}
