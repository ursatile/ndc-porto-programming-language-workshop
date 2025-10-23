using Douro;
using Douro.Values;

// TODO:
// 1. Define grammar for output and numbers
// 2. define syntax nodes for output and numbers
// 3: build an interpreter which will evaluate those nodes
// 4: wrap the interpreter in an environment so it works

var parser = new DouroParser();
var engine = new DouroEngine();
//var source = "print 1 + 2 + 3 + 4 + 5";
//var program = parser.Parse(source);
//Console.WriteLine(program);
//Console.WriteLine("============");
//engine.Run(program);


var program = new Binary(
	new Number("2"),
	new Number("4"),
	Operator.Add);
