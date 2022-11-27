


using visitor.console.Elements;

namespace visitor.console.Visitors;


public class PriceVisitor : IVisitor
{
    public double Cost { get; set; }
    public double Price { get; set; }
    public void Visit(Contract element)
    {
        switch (element.GetType().Name)
        {
            case nameof(Contractor):
                // 1200 for both
                var contractor = element as Contractor;
                Cost = 1200;
                Price = 1200;
                break;
            case nameof(Consulting):
                // 1000 external - 1500 internal
                var consulting = element as Consulting;
                double price = 0;
                double cost = 0;
                foreach (var resource in consulting!.Resources)
                {
                    if( resource is Internal)
                    {
                        price += 1500;
                        cost += 1500;

                    }
                    if (resource is External)
                    {
                        price += (1000 * 1.5);
                        cost += 1000;
                    }
                }
                Cost = cost;
                Price = price;
                break;
            default:
                break;
        }
    }
}