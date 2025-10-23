namespace Douro.Values;

public class Number(string digits) {
	private readonly decimal value = Decimal.Parse(digits);
	public decimal Value => value;
	public override string ToString() => this.ToString(0);

	public string ToString(int depth)
		=> $"{String.Empty.PadLeft(depth)}number: {value}";
}
