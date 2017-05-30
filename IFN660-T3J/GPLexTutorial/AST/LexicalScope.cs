using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPLexTutorial.AST
{
    public class LexicalScope
    {
        public LexicalScope parentScope;
        public Dictionary<string, Declaration> symbol_table;

        public LexicalScope()
        {
            parentScope = null;
            symbol_table.Clear();
        }

        public Declaration ResolveHere(string symbol)
        {
            foreach (KeyValuePair<string, Declaration> it in symbol_table)
            {
                    return it.Value;
            }
            return null;
        }

        public Declaration Resolve(string symbol)
        {
            Declaration local = ResolveHere(symbol);
            if (local != null)
                return local;
            else if (parentScope != null)
                return parentScope.Resolve(symbol);
            else
                return null;
        }
    }
}
