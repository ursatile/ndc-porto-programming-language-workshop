using System.Text;
using Douro.Values;

namespace Douro.Statements;

public abstract class Statement {
	public abstract string ToString(int depth);
	public override string ToString() => this.ToString(0);
}

public class DouroProgram {
	private List<Statement> statements = [];
	public List<Statement> Statements => statements;
	public DouroProgram Insert(Statement statement) {
		statements.Insert(0, statement);
		return this;
	}

	public override string ToString() {
		var sb = new StringBuilder();
		foreach (var s in Statements) sb.AppendLine(s.ToString());
		return sb.ToString();
	}
}

public abstract class ExprStatement(Expr expr) : Statement {
	public Expr Expr => expr;
	public override string ToString(int depth = 0) {
		var sb = new StringBuilder();
		sb.AppendLine($"{this.GetType().Name.ToLowerInvariant()}:");
		sb.AppendLine(expr.ToString(depth + 1));
		return sb.ToString();
	}
}

public class Print(Expr expr) : ExprStatement(expr) {
}

public class Lookup(string name) : Expr {
	public string Name => name;
	public override string ToString(int depth = 0) {
		var sb = new StringBuilder();
		sb.AppendLine("lookup:");
		sb.AppendLine($"{String.Empty.PadLeft(depth + 1)}name: {name}");
		sb.AppendLine(name);
		return sb.ToString();
	}
}

public class Assign(string name, Expr expr) : ExprStatement(expr) {
	public string Name => name;
}

public class Return(Expr expr) : ExprStatement(expr) { }

public class Function(List<string> argumentNames, List<Statement> body) : Value {

	public List<string> ArgumentNames => argumentNames;
	public List<Statement> Body => body;
	
	public override string ToString(int depth) {
		var sb = new StringBuilder();
		var indent = String.Empty.PadLeft(depth);
		sb.AppendLine(indent + $"function ({String.Join(",", argumentNames.ToArray())}) => ");
		foreach (var statement in body) {
			sb.AppendLine(statement.ToString(depth + 1));
		}
		return sb.ToString();
	}
}
