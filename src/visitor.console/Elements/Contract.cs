
using visitor.console.Visitors;

namespace visitor.console.Elements;



public interface IContract 
{
 void Accept(IContractVisitor visitor);
}
public class Consulting : IContract
{
    public string Name { get; set; } = null!;
    public List<Resource> Resources { get; set; } = null!;

    public void Accept(IContractVisitor visitor)
    {
        visitor.Visit(this);
    }
}

public class Contractor : IContract
{
    public Resource Resource { get; set; } = null!;
    public void Accept(IContractVisitor visitor)
    {
        visitor.Visit(this);
    }

}

public class Delivery : IContract
{
    public void Accept(IContractVisitor visitor)
    {
        visitor.Visit(this);
    }
}