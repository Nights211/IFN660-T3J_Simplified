using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPLexTutorial.AST
{

    public class CompilationUnit : Node
    {
        //private PackageDeclaration packageDeclaration;
        //private ImportDeclaration importDeclaration;
        public List<TypeDeclaration> typeDeclarations {get; set;}

        public CompilationUnit(/*PackageDeclaration packageDeclaration, ImportDeclaration importDeclaration,*/ List<TypeDeclaration> typeDeclarations)
        {
            //this.packageDeclaration = packageDeclaration;
            //this.importDeclaration = importDeclaration;
            this.typeDeclarations = typeDeclarations;
        }

        public override void dump(int indent)
        {
            label(indent, "CompilationUnit\n");
            //packageDeclaration.dump(indent + 1, "PackageDeclaration");
            //importDeclaration.dump(indent + 1, "ImportDeclaration");
            foreach (var child in typeDeclarations)
                child.dump(indent + 1);
        }

        public override void ResolveNames(LexicalScope scope)
        {

            foreach (var typeDeclaration in typeDeclarations)
            {
                typeDeclaration.ResolveNames(scope);


            }
        }
        public override void TypeCheck()
        {
            foreach (var typeDeclaration in typeDeclarations)
            {
                typeDeclaration.TypeCheck();
            }
        }
        public override void GenCode(StreamWriter sw)
        {
            
        }
    }
}
