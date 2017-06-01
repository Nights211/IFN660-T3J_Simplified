using System;
using System.Collections.Generic;
using System.IO;
using GPLexTutorial.AST;

namespace GPLexTutorial.AST
{


    public abstract class Statement : Node
    {
        public abstract override void GenCode(StreamWriter sw);
        public int LastLabel;

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
            cond.GenCode(sw);
            int elseLabel = LastLabel++;
            emit(sw, "brfalse {0}", elseLabel);
            thenStmt.GenCode(sw);
            emit(sw, "L{0}:", elseLabel);
            elseStmt.GenCode(sw);
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
            emit(sw, "pop");
        }
    };

    public class VariableDeclaration : Statement , Declaration
    {
        private UnAnnType type;
        private string name;


        public VariableDeclaration(UnAnnType type, string name)
        {
            this.type = type;
            this.name = name;
        }

        public UnAnnType GetType() { return type; }
        public string GetName() { return name; }
        public int GetNumber() { throw new NotImplementedException(); /* This needs to be done, AttributeNumbering or whatever it is called */}

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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }

  

}