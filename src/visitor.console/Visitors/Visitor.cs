using visitor.console.Elements;

namespace visitor.console.Visitors;

public interface IContractVisitor
{
    void Visit(Contractor element);
    void Visit(Consulting element);
}

public interface IResourceVisitor
{
    void Visit(Internal resource);
    void Visit(External resource);
}

