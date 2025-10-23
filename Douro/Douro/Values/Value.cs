using System.Diagnostics;

namespace Douro.Values;

public abstract class Value : Expr {
	public static Value operator +(Value lhs, Value rhs) =>
		(lhs, rhs) switch {
			(Number n1, Number n2) => new Number(n1.Value + n2.Value),
			_ => throw new NotImplementedException($"Cannot add {lhs} and {rhs}")
		};
}
