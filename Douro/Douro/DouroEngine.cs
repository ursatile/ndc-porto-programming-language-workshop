using Douro.Statements;
using Douro.Values;

namespace Douro;

public class DouroEngine {

	private Value Eval(Binary b) => b.Operator switch {
		Operator.Add => Eval(b.Lhs) + Eval(b.Rhs),
		_ => throw new NotImplementedException($"I don't know how to {b.Operator}")
	};

	public Value Eval(Expr expr) => expr switch {
		Binary binary => Eval(binary),
		Value v => v,
		_ => throw new NotImplementedException($"I don't know how to evaluate {expr.GetType()}")
	};
	public void Run(Statement statement) {
		switch (statement) {
			case Print p:
				var value = Eval(p.Expr);
				Console.WriteLine(value);
				break;
			default:
				throw new NotImplementedException($"I don't know how to run {statement.GetType()}");
		}
	}

	public void Run(Statement[] statements) {
		foreach (var statement in statements) {
			Run(statement);
		}
	}
}
