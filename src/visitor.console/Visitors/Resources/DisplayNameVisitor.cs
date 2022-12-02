
using visitor.console.Elements;

namespace visitor.console.Visitors.Resources;


public class DisplayNameVisitor : IResourceVisitor
{
    public string  DisplayName { get; set; } = null!;
    public void Visit(Internal resource)
    {
       DisplayName = $"{resource.Name}.{resource.Id}";
    }

    public void Visit(External resource)
    {
       DisplayName = resource.Name;
    }

    public void Visit(Other resource)
    {
        throw new NotImplementedException();
    }
}