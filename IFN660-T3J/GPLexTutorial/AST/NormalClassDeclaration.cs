using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPLexTutorial.AST
{
    public class NormalClassDeclaration : Statement, Declaration
    {
        public LexicalScope LexicalScope { get; set; }
        public List<Modifier> classModifiers { get; set; }
        private List<MethodDeclaration> classBody;
        private String name;
        

        public NormalClassDeclaration(List<Modifier> classModifiers, String name, List<MethodDeclaration> classBody)
        {
            this.classModifiers = classModifiers;
            this.name = name;
            this.classBody = classBody;
        }


        public override void dump(int indent)
        {
            foreach (Modifier modifier in classModifiers)
            {
                label(indent, "{0} ", modifier);
            }
            label(indent, "NormalClassDeclaration {0}\n", name);
            foreach (MethodDeclaration child in classBody)
            {
                child.dump(indent + 1);
            }
        }

        public override void ResolveNames(LexicalScope scope)
        {
            LexicalScope = new LexicalScope(scope);
            LexicalScope.symbol_table.Add(GetName(), this);
            foreach (var Statement in classBody)
                Statement.ResolveNames(scope);
        }

        public override void TypeCheck()
        {
            foreach (MethodDeclaration Method in classBody)
            {
                Method.TypeCheck();
            }

        }
        public override void GenCode(StreamWriter sw)
        {
            string modifier = "";
            foreach (ClassModifier m in classModifiers)
            {
                modifier += m.ToString();
            }
            emit(sw, ".class {0} {1} { {2} }", modifier, name, classBody);
        }
        

        public String GetName() { return name; }

               UnAnnType Declaration.GetType()
        {
            throw new NotImplementedException(); // I don't know how to do this - Seth
        }

        public int GetNumber()
        {
            return 0;
        }


        }


    }
