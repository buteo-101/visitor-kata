using System.Security.Cryptography;
using System.Text;
using visitor.console.Elements;

namespace visitor.console.Visitors.Contracts;

public class DescriptionVisitor : IContractVisitor
{
    public string Description { get; set; } = null!;
    public string PrintableDescription { get; set; } = null!;
    public ReferenceVisitor ReferenceVisitor { get; set; } = new ReferenceVisitor();

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
        element.Accept(ReferenceVisitor);
        Description = $"{ReferenceVisitor.Reference}/{element?.Resource?.Name}";
        PrintableDescription = Description.Length.ToString();
    }

    public void Visit(Consulting element)
    {
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