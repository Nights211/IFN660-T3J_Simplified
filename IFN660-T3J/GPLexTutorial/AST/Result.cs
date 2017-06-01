using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPLexTutorial.AST
{
    public class Result : Node
    {
        private UnAnnType returnType;
        public Result(UnAnnType returnType)
        {
            this.returnType = returnType;
        }
        public override void dump(int indent)
        {
            label(indent, "Result\n");
        }
        
        public override void ResolveNames(LexicalScope scope)
        {
            
        }
        public override void TypeCheck()
        {
            //this needs to be fixed - does it? Why would we type check a type? - Seth
        }
        public override void GenCode(StreamWriter sw)
        {
            throw new NotImplementedException();
        }
    }
}
