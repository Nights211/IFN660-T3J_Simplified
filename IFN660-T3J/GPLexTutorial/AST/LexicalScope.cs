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

        public LexicalScope(LexicalScope parentScope)
        {
            this.parentScope = parentScope;
            symbol_table = new Dictionary<string, Declaration>();
        }

        public Declaration ResolveHere(string symbol)
        {
            if (symbol_table.ContainsKey(symbol))
            {
                return symbol_table[symbol];
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
