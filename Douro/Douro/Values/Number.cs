using System.Globalization;
using System.Text;

namespace Douro.Values;

public class FunctionCall(string name, List<Expr> args) : Expr {
	public string Name => name;
	public List<Expr> Args => args;
	public override string ToString(int depth) {
		var sb = new StringBuilder();
		var indent = String.Empty.PadLeft(depth);
		sb.AppendLine(indent + $"call: {name}");
		foreach (var arg in args) {
			sb.AppendLine(arg.ToString(depth + 1));
		}
		return sb.ToString();
	}
}

public class Number(decimal value) : Value {

	public Number(string digits) : this(Decimal.Parse(digits, CultureInfo.InvariantCulture)) { }

	public decimal Value => value;

	public override string ToString()
		=> value.ToString(CultureInfo.InvariantCulture);

	public override string ToString(int depth)
		=> $"{String.Empty.PadLeft(depth)}number: {Value}";
}
