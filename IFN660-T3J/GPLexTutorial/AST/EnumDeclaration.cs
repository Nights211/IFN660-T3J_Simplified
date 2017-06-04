using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPLexTutorial.AST
{
    public class EnumDeclaration : TypeDeclaration, Declaration
    {
        public LexicalScope LexicalScope { get; set; }
        public List<Modifier> enumModifiers { get; set; }
        public string name;
        public EnumBody enumBody;
        


        public EnumDeclaration(List<Modifier> enumModifiers, String name, EnumBody enumBody)
        {
            this.enumModifiers = enumModifiers;
            this.name = name;
            this.enumBody = enumBody;
        }


        public override void dump(int indent)
        {
            foreach (Modifier modifier in enumModifiers)
            {
                label(indent, "{0} ", modifier);
            }
            label(indent, "EnumDeclaration {0}\n", name);
            enumBody.dump(indent + 1);
            
        }

        public override void ResolveNames(LexicalScope scope)
        {
               enumBody.ResolveNames(scope);
        }

        public override void TypeCheck()
        {
                enumBody.TypeCheck();

        }
        public override void GenCode(StreamWriter sw)
        {
            
            emit(sw, ".assembly {0} {{ }}" + Environment.NewLine, name);
            emit(sw, ".class ");
            foreach (Modifier modifier in enumModifiers)
            {
                emit(sw, makeLowerCase("{0} ", modifier));
            }
            emit(sw, "{0} " + Environment.NewLine + "{{" + Environment.NewLine, name);

            
               enumBody.GenCode(sw);

            emit(sw, "}}");
            
        }


     

        UnAnnType Declaration.GetType()
        {
            throw new NotImplementedException(); // I don't know how to do this - Seth
        }

        public int GetNumber()
        {
            return 0;
        }

        public string GetName()
        {
            return name;
        }
    }

}
