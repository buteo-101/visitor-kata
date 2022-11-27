using visitor.console.Elements;

namespace visitor.console.Visitors;

public interface IVisitor
{
    void Visit(Contract element);
}
