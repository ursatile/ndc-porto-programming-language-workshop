using Douro;

if (args.Length < 1) {
	Console.WriteLine("Usage: Douro <source-file>");
	Environment.Exit(1);
}

var filename = args[0];
var source = File.ReadAllText(filename);

var env = new DouroEnvironment();
var parser = new DouroParser();
var engine = new DouroEngine(env);

Console.WriteLine(source);
var program = parser.Parse(source);
Console.WriteLine(program);
Console.WriteLine("============");
engine.Run(program);
