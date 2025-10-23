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
	
	public void Run(Print statement) {
		var value = Eval(statement.Expr);
		Console.WriteLine(value);
	}
}
