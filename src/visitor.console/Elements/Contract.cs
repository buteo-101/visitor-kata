
using visitor.console.Visitors;

namespace visitor.console.Elements;

public abstract class Contract

{
    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}


public class Consulting : Contract
{
    public string Name { get; set; } = null!;
    public List<Resource> Resources { get; set; } = null!;

}

public class Contractor : Contract
{
    public Resource Resource { get; set; } = null!;

}