using System.Security.Cryptography;
using System.Text;
using visitor.console.Elements;

namespace visitor.console.Visitors.Contracts;

public class DescriptionVisitor : IContractVisitor
{
    public string Description { get; set; } = null!;
    public string PrintableDescription { get; set; } = null!;
    public ReferenceVisitor ReferenceVisitor { get; set; } = new ReferenceVisitor();
    // public string LastVisitedTypeName { get; set; } = null!;

    // public override string? ToString()
    // {
    //     return LastVisitedTypeName switch
    //     {
    //         nameof(Contractor) => $"{Description.Length}",
    //         nameof(Consulting) => GetDescriptionHash(),
    //         _ => "Undefined contract type",
    //     };
    // }

    private string GetDescriptionHash()
    {
        var descriptionInBytes = Encoding.UTF8.GetBytes(Description);
        using var encoder = SHA256.Create();

        var hash = encoder.ComputeHash(descriptionInBytes);
        var result = string.Empty;
        foreach (var x in hash)
        {
            result += string.Format("{0:x2}", x);
        }
        return result;
    }

    public void Visit(Contractor element)
    {
        // LastVisitedTypeName = nameof(Contractor);
        element.Accept(ReferenceVisitor);
        //ReferenceVisitor.Visit(element!);
        Description = $"{ReferenceVisitor.Reference}/{element?.Resource?.Name}";
        PrintableDescription = Description.Length.ToString();
    }

    public void Visit(Consulting element)
    {
        // Consulting._id + liste des couples name/id des Resource, exemple avec 2 Resource : C21345-3[Pierre-14, Jean-2, Paul-3]
        // LastVisitedTypeName = nameof(Consulting);
        // ReferenceVisitor.Visit(element!);
        element.Accept(ReferenceVisitor);
        var displayNameVisitor = new Resources.DisplayNameVisitor();
        var segments = new List<string>();
        foreach (var resource in element!.Resources)
        {
            resource.Accept(displayNameVisitor);
            segments.Add(displayNameVisitor.DisplayName);
        }
        Description = $"{ReferenceVisitor.Reference}[{string.Join(',', segments)}]";
        PrintableDescription = GetDescriptionHash();
    }
}