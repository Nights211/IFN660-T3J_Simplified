﻿using System;
using System.Collections.Generic;
using System.IO;
using GPLexTutorial.AST;

namespace GPLexTutorial.AST
{

    public abstract class Statement : Node
    {
        public abstract override void GenCode(StreamWriter sw);
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

        public override void ResolveNames(LexicalScope scope)
        {
            cond.ResolveNames(scope);
            thenStmt.ResolveNames(scope);
            elseStmt.ResolveNames(scope);
        }
        public override void TypeCheck()
        {

            cond.TypeCheck();
            if (!cond.type.Equal(new BoolType()))
            {
                Console.WriteLine("Invalid type for if statement condition\n");
                throw new Exception("TypeCheck Error");
                    
            }
            thenStmt.TypeCheck();
            elseStmt.TypeCheck();
        }
        public override void GenCode(StreamWriter sw)
        {
            int elseLabel = Globals.LastLabel++;
            cond.GenCode(sw);
            emit(sw, "brtrue L{0}" + Environment.NewLine, elseLabel);
            elseStmt.GenCode(sw);
            emit(sw, "br M{0} " + Environment.NewLine, elseLabel);
            emit(sw, "L{0}:", elseLabel);
            thenStmt.GenCode(sw);
            emit(sw, "M{0}: ", elseLabel);
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
        public override void ResolveNames(LexicalScope scope)
        {
            cond.ResolveNames(scope);
            whileThen.ResolveNames(scope);
        }
        public override void TypeCheck()
        {
            cond.TypeCheck();
            if (!cond.type.Equal(new BoolType()))
            {
                Console.WriteLine("Invalid type for if statement condition\n");
                throw new Exception("TypeCheck Error");

            }
            whileThen.TypeCheck();
        }
        public override void GenCode(StreamWriter sw)
        {
            int elseLabel = Globals.LastLabel++;
            emit(sw, "L{0}: ", elseLabel);
            cond.GenCode(sw);
            emit(sw, "brfalse M{0} " +Environment.NewLine, elseLabel);
            whileThen.GenCode(sw);
            emit(sw, "br L{0}" + Environment.NewLine, elseLabel);
            emit(sw, "M{0}: ", elseLabel);
        }
    }

    public class DoStatement : Statement
    {
        private Expression cond;
        private Statement doThen;
        public DoStatement(Statement doThen, Expression cond)
        {
            this.cond = cond; this.doThen = doThen;
        }

        public override void dump(int indent)
        {
            label(indent, "DoStatement\n");
            cond.dump(indent + 1, "cond");
            doThen.dump(indent + 1, "then");
        }

        public override void ResolveNames(LexicalScope scope)
        {
            cond.ResolveNames(scope);
            doThen.ResolveNames(scope);
        }
        public override void TypeCheck()
        {
            cond.TypeCheck();
            if (!cond.type.Equal(new BoolType()))
            {
                Console.WriteLine("Invalid type for if statement condition\n");
                throw new Exception("TypeCheck Error");

            }
            doThen.TypeCheck();
        }
        public override void GenCode(StreamWriter sw)
        {
            int elseLabel = Globals.LastLabel++;
            emit(sw, "L{0}: ", elseLabel);
            doThen.GenCode(sw);
            cond.GenCode(sw);
            emit(sw, "brtrue L{0}" + Environment.NewLine, elseLabel);
        }
    }

    public class BasicForStatement : Statement
    {
        private Expression cond, forInit, forUpdate;
        private Statement forThen;

        public BasicForStatement(Expression forInit, Expression cond, Expression forUpdate, Statement forThen)
        {
            this.cond = cond; this.forThen = forThen;
            this.forInit = forInit; this.forUpdate = forUpdate;
        }

        public override void dump(int indent)
        {
            label(indent, "BasicForStatement\n");
            forInit.dump(indent + 1, "forInit");
            cond.dump(indent + 1, "cond");
            forUpdate.dump(indent + 1, "forUpdate");
            forThen.dump(indent + 1, "then");
        }

        public override void ResolveNames(LexicalScope scope)
        {
            cond.ResolveNames(scope);
            forInit.ResolveNames(scope);
            forUpdate.ResolveNames(scope);
            forThen.ResolveNames(scope);
        }
        public override void TypeCheck()
        {
            forInit.TypeCheck();
            cond.TypeCheck();
            if (!cond.type.Equal(new BoolType()))
            {
                Console.WriteLine("Invalid type for if statement condition\n");
                throw new Exception("TypeCheck Error");

            }
            forUpdate.TypeCheck();
            forThen.TypeCheck();
        }
        public override void GenCode(StreamWriter sw)
        {
            int elseLabel = Globals.LastLabel++;
            emit(sw, "L{0}: ", elseLabel);
            cond.GenCode(sw);
            emit(sw, "brfalse M{0} " + Environment.NewLine, elseLabel);
            forThen.GenCode(sw);
            emit(sw, "br L{0}" + Environment.NewLine, elseLabel);
            emit(sw, "M{0}: ", elseLabel);
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

        public override void ResolveNames(LexicalScope scope)
        {
            expr.ResolveNames(scope);
        }
        public override void TypeCheck()
        {
            expr.TypeCheck();
        }
        public override void GenCode(StreamWriter sw)
        {
            expr.GenCode(sw);
            emit(sw, "pop" + Environment.NewLine);
        }
    };

    public class VariableDeclaration : Statement , Declaration
    {
        private UnAnnType type;
        private string name;
        int num;

        public VariableDeclaration(UnAnnType type, string name)
        {
            this.type = type;
            this.name = name;
            num = Globals.LastLocal++;
        }

        public UnAnnType GetType()
        {
            return type;
        }

        public string GetName()
        {
            return name;
        }

        public int GetNumber()
        {
            return num;
        }

        public override void dump(int indent)
        {
            label(indent, "{0} VariableDeclaration {1}\n", (Declaration)this,  name);
            type.dump(indent + 1, "type");
        }

        public override void ResolveNames(LexicalScope scope)
        {
            type.ResolveNames(scope);
        }
        public override void TypeCheck()
        {
            type.TypeCheck();
        }

        public override void GenCode(StreamWriter sw)
        {
            emit(sw, ".locals init ([{0}] {1} {2})" + Environment.NewLine, num, type.CLRName(), name.ToString());
        }
    };

    public class CompoundStatement : Statement 
    {
        private List<Statement> stmts;
        public LexicalScope lexicalScope { get; set; }
        public Declaration declaration { get; set; }
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

        public override void ResolveNames(LexicalScope scope)
        {
            lexicalScope = new LexicalScope(scope);

            foreach (Statement statement in stmts)
            {
                declaration = statement as Declaration;
                if (declaration != null)
                {
                    lexicalScope.symbol_table[declaration.GetName()] = declaration;
                }
            }
            foreach (Statement statement in stmts)
            {
                statement.ResolveNames(lexicalScope);                    
            }
            
        }
        public override void TypeCheck()
        {
            foreach (Statement statement in stmts)
            {
                statement.TypeCheck();
            }
        }
        public override void GenCode(StreamWriter sw)
        {
            foreach (Statement statement in stmts)
            {
                statement.GenCode(sw);
            }
        }
    }

  

}