using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPLexTutorial.AST
{
    public class MethodBody : Statement
    {
        List<Statement> BlockStatements { get; set; }

        public MethodBody(List<Statement> blockStatements)
        {
            this.BlockStatements = blockStatements;
        }


 

        public override void dump(int indent)
        {
            label(indent, "MethodBody\n");
        }

        public override bool ResolveNames(LexicalScope scope)
        {
            return true; //need to fix this - Seth
        }
        public override void TypeCheck()
        {
            foreach (var Statement in BlockStatements)
                Statement.TypeCheck();
        }
        public override void GenCode(StreamWriter sw)
        {
            throw new NotImplementedException();
        }














        /* old

        private Block block;
        public MethodBody(Block block)
        {
            this.block = block;
        }
        public override void dump(int indent)
        {
            label(indent, "MethodBody\n");
        }

    


        public override bool ResolveNames(LexicalScope scope)
        {
           return block.ResolveNames(scope);
        }

        public override void TypeCheck()
        {
            block.TypeCheck();
        }
        public void GenCode(StreamWriter sw)
        {
            emit(sw, ".entrypoint");
        } */
    }


}
