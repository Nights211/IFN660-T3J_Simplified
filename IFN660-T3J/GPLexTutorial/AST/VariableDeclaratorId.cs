using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPLexTutorial.AST
{
    /* Not sure why we needed this, maybe I'm stupid - Seth


    public class VariableDeclaratorId : Expression

    {

        Expression argName;
        public VariableDeclaratorId(Expression argName)
        {
            this.argName = argName;
        }

        public Expression GetArgName() { return argName; }
        public override void dump(int indent)
        {
            label(indent, "VariableDeclaratorId\n");
        }

        public override bool ResolveNames(LexicalScope scope)
        {
            return true;
        }
        public override void TypeCheck()
        {
            // this needs to be fixed
        }

        public void GenCode(StreamWriter sw)
        {
            throw new NotImplementedException();
        }

        public override void GenStoreCode(StreamWriter sw)
        {
            throw new NotImplementedException();
        }

    }*/
}
