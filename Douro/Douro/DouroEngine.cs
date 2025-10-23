using Douro.Statements;

public class DouroEngine {
	public void Run(Print statement) {
		var value = statement.Expr;
		Console.WriteLine(value);
	}
}
