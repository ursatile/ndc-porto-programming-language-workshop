namespace Douro.Values;

public abstract class Expr {
	public virtual string ToString(int depth)
		=> base.ToString()!;

}
