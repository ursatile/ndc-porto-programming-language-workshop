using Douro;
// TODO:
// 1. Define grammar for output and numbers
// 2. define syntax nodes for output and numbers
// 3: build an interpreter which will evaluate those nodes
// 4: wrap the interpreter in an environment so it works

var parser = new DouroParser();
var result = parser.Parse("1000000000000000000000000000000000000000");
Console.WriteLine(result);

result = parser.Parse("8");
Console.WriteLine(result);

result = parser.Parse("9");
Console.WriteLine(result);
