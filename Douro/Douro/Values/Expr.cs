namespace Douro.Values;

public abstract class Expr {
	public const string INDENT = " ";
	public virtual string ToString(int depth)
		=> base.ToString()!;

}
