namespace Douro.Values;

public class Binary(
	Expr lhs,
	Expr rhs,
	Operator op)
	: Expr {
	public Operator Operator => op;
	public Expr Lhs => lhs;
	public Expr Rhs => rhs;
	
	public override string ToString(int depth = 0) {
		var indent = new string(' ', depth);
		var sb = new System.Text.StringBuilder();
		sb.AppendLine($"{indent}binary:");
		sb.AppendLine($"{indent} op: {op}");
        var lhsValue = lhs.ToString(depth + 2);
        var rhsValue = rhs.ToString(depth + 2);
        if (lhsValue.EndsWith(Environment.NewLine)) sb.Append($"{indent} lhs: " + lhsValue);
        else sb.AppendLine($"{indent} lhs: " + lhsValue);
        if (rhsValue.EndsWith(Environment.NewLine)) sb.Append($"{indent} rhs: " + rhsValue);
        else sb.AppendLine($"{indent} rhs: " + rhsValue);
		return sb.ToString();
	} 
}
