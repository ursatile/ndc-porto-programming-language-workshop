namespace Douro.Values;

public class Number(string digits) : Value {
	private readonly decimal value = Decimal.Parse(digits);
	public decimal Value => value;

	public override string ToString() => this.ToString(0);

	public override string ToString(int depth)
		=> $"{String.Empty.PadLeft(depth)}number: {Value}";
}
