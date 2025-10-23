using System.Text;
using Douro.Values;

namespace Douro.Statements;

public abstract class Statement {
	public abstract string ToString(int depth);
	public override string ToString() => this.ToString(0);
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
