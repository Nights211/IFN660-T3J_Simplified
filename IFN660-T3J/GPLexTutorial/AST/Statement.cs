﻿using System;
using System.Collections.Generic;
using System.IO;
using GPLexTutorial.AST;

namespace GPLexTutorial.AST
{
    public abstract class Statement : Node
    {

    }


    public class IfStatement : Statement
    {

        private Expression cond;
        private Statement thenStmt, elseStmt;

        public IfStatement(Expression cond, Statement thenStmt, Statement elseStmt)
        {
            this.cond = cond;
            this.thenStmt = thenStmt;
            this.elseStmt = elseStmt;
        }

        public override void dump(int indent)
        {
            label(indent, "IfStatement\n");
            cond.dump(indent + 1, "cond");
            thenStmt.dump(indent + 1, "then");
            elseStmt.dump(indent + 1, "else");
        }

        public override bool ResolveNames(LexicalScope scope)
        {
            return cond.ResolveNames(scope) && thenStmt.ResolveNames(scope) && elseStmt.ResolveNames(scope);
        }
        public override void TypeCheck()
        {

            cond.TypeCheck();
            thenStmt.TypeCheck();
            elseStmt.TypeCheck();
        }
        public override void GenCode(StreamWriter sw)
        {
            throw new NotImplementedException();
        }
    }

    public class WhileStatement : Statement
    {
        private Expression cond;
        private Statement whileThen;
        public WhileStatement(Expression cond, Statement whileThen)
        {
            this.cond = cond; this.whileThen = whileThen;
        }

        public override void dump(int indent)
        {
            label(indent, "WhileStatement\n");
            cond.dump(indent + 1, "cond");
            whileThen.dump(indent + 1, "then");
        }
        public override bool ResolveNames(LexicalScope scope)
        {
            return cond.ResolveNames(scope) && whileThen.ResolveNames(scope);
        }
        public override void TypeCheck()
        {
            cond.TypeCheck();
            whileThen.TypeCheck();
        }
        public override void GenCode(StreamWriter sw)
        {
            throw new NotImplementedException();
        }
    }

    public class DoStatement : Statement
    {
        private Expression cond;
        private Statement doThen;
        public DoStatement(Expression cond, Statement doThen)
        {
            this.cond = cond; this.doThen = doThen;
        }

        public override void dump(int indent)
        {
            label(indent, "DoStatement\n");
            cond.dump(indent + 1, "cond");
            doThen.dump(indent + 1, "then");
        }

        public override bool ResolveNames(LexicalScope scope)
        {
            return cond.ResolveNames(scope) && doThen.ResolveNames(scope);
        }
        public override void TypeCheck()
        {
            cond.TypeCheck();
            doThen.TypeCheck();
        }
        public override void GenCode(StreamWriter sw)
        {
            throw new NotImplementedException();
        }
    }

    public class ExpressionStatement : Statement
    {
        private Expression expr;

        public ExpressionStatement(Expression expr)
        {
            this.expr = expr;
        }

        public override void dump(int indent)
        {
            label(indent, "ExpressionStatement\n");
            expr.dump(indent + 1);
        }

        public override bool ResolveNames(LexicalScope scope)
        {
            return expr.ResolveNames(scope);
        }
        public override void TypeCheck()
        {
            expr.TypeCheck();
        }
        public override void GenCode(StreamWriter sw)
        {
            throw new NotImplementedException();
        }
    };

    public class VariableDeclaration : Statement 
    {
        private UnAnnType type;
        private string name;


        public VariableDeclaration(UnAnnType type, string name)
        {
            this.type = type;
            this.name = name;
        }

        public string GetName() { return name; }


        public int GetNumber() { throw new NotImplementedException(); /* This needs to be done, AttributeNumbering or whatever it is called */}

        public override void dump(int indent)
        {
            label(indent, "VariableDeclaration {0}\n", name);
            type.dump(indent + 1);
        }

        public override bool ResolveNames(LexicalScope scope)
        {
            return true; // This needs to be fixed - Seth
        }
        public override void TypeCheck()
        {
            type.TypeCheck();
        }

        public override void GenCode(StreamWriter sw)
        {
            throw new NotImplementedException();
        }
    };

    public class CompoundStatement : Statement
    {
        private List<Statement> stmts;

        public CompoundStatement(List<Statement> stmts)
        {
            this.stmts = stmts;
        }

        public override void dump(int indent)
        {
            label(indent, "CompoundStatement\n");
            foreach (var child in stmts)
                child.dump(indent + 1);
        }

        public override bool ResolveNames(LexicalScope scope)
        {
            bool allOK = true;
            foreach (var statements in stmts)
            {
                if (!statements.ResolveNames(scope))
                    allOK = false;
            }
            return allOK;
        }
        public override void TypeCheck()
        {
            foreach (var statements in stmts)
            {
                statements.TypeCheck();
            }
        }
        public override void GenCode(StreamWriter sw)
        {
            throw new NotImplementedException();
        }
    }
    
}