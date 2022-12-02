using visitor.console.Elements;

namespace visitor.console.Visitors.Contracts;
public class ReferenceVisitor : IContractVisitor
{
    public string Reference { get; set; } = null!;
    public void Visit(Contractor element)
    {
        // "REF00-"+ Resource._id, exemple REF00-12
        Reference = $"REF00-{element?.Resource?.Id}";
    }

    public void Visit(Consulting element)
    {
        // "C"+Consulting._name+"-"+ nombre de resource, exemple C21345-3
        Reference = $"C{element?.Name}-{element?.Resources?.Count}";
    }

    public void Visit(Delivery element)
    {
        throw new NotImplementedException();
    }
}