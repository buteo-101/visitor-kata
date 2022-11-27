using System.Security.Cryptography;
using System.Text;
using visitor.console.Elements;

namespace visitor.console.Visitors;

public class DescriptionVisitor : IVisitor
{
    public string Description { get; set; } = null!;
    public ReferenceVisitor ReferenceVisitor { get; set; } = new ReferenceVisitor();
    public string LastVisitedTypeName { get; set; } = null!;

    public override string? ToString()
    {
        return LastVisitedTypeName switch
        {
            nameof(Contractor) => $"{Description.Length}",
            nameof(Consulting) => GetDescriptionHash(),
            _ => "Undefined contract type",
        };
    }

    private string GetDescriptionHash()
    {
        var descriptionInBytes = Encoding.UTF8.GetBytes(Description);
        using var encoder = SHA256.Create();

        var hash = encoder.ComputeHash(descriptionInBytes);
        var result = string.Empty;
        foreach (var x in hash)
        {
            result += String.Format("{0:x2}", x);
        }
        return result;
    }
    private string GetName(Resource r)
    {
        return r.GetType().Name switch
        {
            nameof(Internal) => (r as Internal)!.Name,
            nameof(External) => (r as External)!.Name,
            _ => r.Name,
        };
    }
    public void Visit(Contract element)
    {
        switch (element.GetType().Name)
        {
            case nameof(Contractor):
                // Prestation._reference +'/'+ Resource._name, exemple REF00-12/Jacques
                var contractor = element as Contractor;
                LastVisitedTypeName = nameof(Contractor);
                ReferenceVisitor.Visit(contractor!);
                Description = $"{ReferenceVisitor.Reference}/{contractor?.Resource?.Name}";
                break;
            case nameof(Consulting):
                // Consulting._id + liste des couples name/id des Resource, exemple avec 2 Resource : C21345-3[Pierre-14, Jean-2, Paul-3]
                var consulting = element as Consulting;
                LastVisitedTypeName = nameof(Consulting);
                ReferenceVisitor.Visit(consulting!);
                var names = string.Join(',', consulting!
                    .Resources
                    .Select(r => GetName(r))
);
                Description = $"{ReferenceVisitor.Reference}[{names}]";
                break;
            default:
                break;
        }
    }
}