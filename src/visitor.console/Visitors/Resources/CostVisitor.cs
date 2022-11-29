using visitor.console.Elements;
using visitor.console.Visitors;

namespace visitor.console.Visitors.Resources;


public class CostVisitor : IResourceVisitor
{

    public double  Cost { get; set; } = 0;
    public double Price { get; set; } = 0;

    public void Visit(Internal resource)
    {
        Price  = 1500;
        Cost = 1500;
    }

    public void Visit(External resource)
    {
       Price = 1000 * 1.5;
       Cost = 1000;
    }
}
