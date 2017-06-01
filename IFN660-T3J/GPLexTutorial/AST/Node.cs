using System;
using System.IO;
using GPLexTutorial.AST;

namespace GPLexTutorial.AST
{
    public abstract class Node
    {
        public abstract void ResolveNames(LexicalScope scope);

        public abstract void dump(int indent);


        private void indent(int N)
        {
            for (int i = 0; i < N; i++)
                Console.Write("    ");
        }
        public abstract void TypeCheck();

        public abstract void GenCode(StreamWriter sw);


        protected void label(int i, string fmt, params object[] args)
        {
            indent(i);
            Console.Write(fmt, args);
        }

        public void dump(int i, string name)
        {
            label(i, "{0}:\n", name);
            dump(i + 1);
        
        }

        public void emit(StreamWriter streamWriter, String format, params object[] args)
        {
            streamWriter.WriteLine(String.Format(format, args));
        }
    }
}
