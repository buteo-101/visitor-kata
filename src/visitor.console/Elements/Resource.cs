namespace visitor.console.Elements;




public class Resource
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
}


public class Internal : Resource
{
    new public string Name
    {
        get { return base.Name + "." + base.Id; }
        set { base.Name = value;}
    }
}

public class External : Resource {}
