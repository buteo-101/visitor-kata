using visitor.console.Elements;

namespace visitor.console.Visitors.Contracts;
public class PriceVisitor : IContractVisitor
{
    public double Cost { get; set; }
    public double Price { get; set; }

    public void Visit(Contractor element)
    {
        Cost = 1200;
        Price = 1200;
    }

    public void Visit(Consulting element)
    {
        double price = 0;
        double cost = 0;
        var CostVisitor = new Resources.CostVisitor();


        foreach (var resource in element!.Resources)
        {
            resource.Accept(CostVisitor);
            price += CostVisitor.Cost;
            cost += CostVisitor.Price;
        }
        Cost = cost;
        Price = price;
    }
}