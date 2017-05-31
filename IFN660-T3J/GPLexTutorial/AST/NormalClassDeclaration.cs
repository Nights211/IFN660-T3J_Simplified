﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPLexTutorial.AST
{
    public class NormalClassDeclaration : TypeDeclaration, Declaration
    {
        public LexicalScope LexicalScope { get; set; }
        public List<ClassModifier> classModifiers { get; set; }
        private List<Statement> classBody;
        private String name;
        

        public NormalClassDeclaration(List<ClassModifier> classModifiers, String name, List<Statement> classBody)
        {
            this.classModifiers = classModifiers;
            this.name = name;
            this.classBody = classBody;
        }


        public override void dump(int indent)
        {
            label(indent, "NormalClassDeclaration {0}\n", name);
        }

        public override bool ResolveNames(LexicalScope scope)
        {

            /* I have no idea how to do this lexical scope stuff - Seth

            scope.symbol_table.Add(GetName(), this);
            LexicalScope = new LexicalScope(scope);
            foreach (var Statement in classBody) 
                Statement.ResolveNames();

                */

            return true; // - Really needs to be fixed - Seth
        }

        public override void TypeCheck()
        {
            foreach (var Statement in classBody)
                Statement.TypeCheck();
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