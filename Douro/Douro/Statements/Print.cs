using System.Text;
using Douro.Values;

namespace Douro.Statements;

public class Print(Number number) {

	public Number Number => number;
	
	public override string ToString() => this.ToString(0);

	public string ToString(int depth = 0) {
		var sb = new StringBuilder();
		sb.AppendLine("print:");
		sb.AppendLine(number.ToString(depth + 1));
		return sb.ToString();
	}
}
