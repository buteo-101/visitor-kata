using visitor.console.Visitors;

namespace visitor.console.Elements;




public abstract class Resource
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;

    public abstract void Accept(IResourceVisitor visitor);
}

public class Internal : Resource
{
    public override void Accept(IResourceVisitor visitor)
    {
        visitor.Visit(this);
    }
}

public class External : Resource
{
    public override void Accept(IResourceVisitor visitor)
    {
        visitor.Visit(this);
    }
}
public class Other : Resource
{
    public override void Accept(IResourceVisitor visitor)
    {
        visitor.Visit(this);
    }
}
