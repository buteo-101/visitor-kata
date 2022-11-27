using visitor.console.Elements;
using visitor.console.Visitors;
namespace visitor.console.Visitors;
public class ReferenceVisitor : IVisitor
{
    public string Reference { get; set; } = null!;
    public void Visit(Contract element)
    {
        switch (element.GetType().Name)
        {
            case nameof(Contractor):
                // "REF00-"+ Resource._id, exemple REF00-12
                var contractor = element as Contractor;
                Reference = $"REF00-{contractor?.Resource?.Id}";
                break;
            case nameof(Consulting):
                // "C"+Consulting._name+"-"+ nombre de resource, exemple C21345-3
                var consulting = element as Consulting;
                Reference = $"C{consulting?.Name}-{consulting?.Resources?.Count}";
                break;
            default:
                break;
        }
    }
}