using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPLexTutorial.AST
{
    public class EnumConstant : Node
    {
        public string name;
        public List<MethodDeclaration> classBody;
        public List<Expression> arguementList;

        public EnumConstant(string name, List<MethodDeclaration> classBody, List<Expression> arguementList)
        {
            this.name = name;
            this.classBody = classBody;
            this.arguementList = arguementList;
        }
        public override void dump(int indent)
        {
            label(indent, "EnumConstant {0}\n", name);
            foreach(Expression child in arguementList)
            {
                child.dump(indent + 1);
            }
            foreach (MethodDeclaration child in classBody)
            {
                child.dump(indent + 1);
            }
        }

        public override void GenCode(StreamWriter sw)
        {
            foreach (Expression child in arguementList)
            {
                child.GenCode(sw);
            }
            foreach (MethodDeclaration child in classBody)
            {
                child.GenCode(sw);
            }
        }

        public override void ResolveNames(LexicalScope scope)
        {
            foreach (Expression child in arguementList)
            {
                child.ResolveNames(scope);
            }
            foreach (MethodDeclaration child in classBody)
            {
                child.ResolveNames(scope);
            }
        }

        public override void TypeCheck()
        {
            foreach (Expression child in arguementList)
            {
                child.TypeCheck();
            }
            foreach (MethodDeclaration child in classBody)
            {
                child.TypeCheck();
            }
        }
    }
}
