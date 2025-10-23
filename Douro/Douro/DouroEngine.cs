using Douro.Statements;
using Douro.Values;

namespace Douro;

public class DouroEnvironment {
	private readonly Dictionary<string, Value> values = [];

	public Value Assign(string name, Value value)
		=> values[name] = value;

	public Value Lookup(string name)
		=> values[name];

	public DouroEnvironment Extend(List<string> argumentNames, List<Value> argumentValues) {
		var extendedEnvironment = new DouroEnvironment();
		foreach (KeyValuePair<string, Value> pair in values) {
			extendedEnvironment.Assign(pair.Key, pair.Value);
		}
		for (var i = 0; i < argumentNames.Count; i++) {
			extendedEnvironment.Assign(argumentNames[i], argumentValues[i]);
		}
		return extendedEnvironment;
	}
}

public class DouroEngine(DouroEnvironment env) {

	private Value Eval(Binary b) => b.Operator switch {
		Operator.Add => Eval(b.Lhs) + Eval(b.Rhs),
		_ => throw new NotImplementedException($"I don't know how to {b.Operator}")
	};

	public Value Call(FunctionCall call) {
		var function = env.Lookup(call.Name) as Function;
		var names = function.ArgumentNames;
		var values = call.Args.Select(Eval).ToList();
		var newEnvironment = env.Extend(names, values);
		var engine = new DouroEngine(newEnvironment);
		return engine.Run(function.Body);
	}

	public Value Eval(Expr expr) => expr switch {
		Binary binary => Eval(binary),
		Lookup lookup => env.Lookup(lookup.Name),
		Value v => v,
		FunctionCall f => Call(f),
		_ => throw new NotImplementedException($"I don't know how to evaluate {expr.GetType()}")
	};

	public Value Run(Statement statement) {
		switch (statement) {
			case Return r:
				return Eval(r.Expr);
			case Assign a:
				return env.Assign(a.Name, Eval(a.Expr));
			case Print p:
				var value = Eval(p.Expr);
				Console.WriteLine(value);
				return value;
			default:
				throw new NotImplementedException($"I don't know how to run {statement.GetType()}");
		}
	}

	public Value Run(IEnumerable<Statement> statements) {
		Value result = null;
		foreach (var statement in statements) result = Run(statement);
		return result;
	}

	public Value Run(DouroProgram program)
		=> Run(program.Statements);
}
