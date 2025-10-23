namespace Douro.Values;

public class Binary(
	Expression lhs,
	Expression rhs,
	Operator op)
	: Expression {
	public override string ToString(int depth = 0) {
		var indent = new string(' ', depth);
		var sb = new System.Text.StringBuilder();
		sb.AppendLine($"{indent}binary:");
		sb.AppendLine($"{indent} op: {op}");
		sb.AppendLine($"{indent}lhs:");
		sb.AppendLine(lhs.ToString(depth + 2));
		sb.AppendLine($"{indent}rhs:");
		sb.AppendLine(rhs.ToString(depth + 2));
		return sb.ToString();
	} 
}
