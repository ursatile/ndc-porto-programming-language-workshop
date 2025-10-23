namespace Douro.Values;

public class Number(string digits) {
	private readonly decimal value = Decimal.Parse(digits);
	public override string ToString()
		=> $"number: {value}";
}
