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

public class Print(Expr expr) : Statement {

	public Expr Expr => expr;

	public override string ToString(int depth = 0) {
		var sb = new StringBuilder();
		sb.AppendLine("print:");
		sb.AppendLine(expr.ToString(depth + 1));
		return sb.ToString();
	}
}
