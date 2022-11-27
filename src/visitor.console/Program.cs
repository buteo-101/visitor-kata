// See https://aka.ms/new-console-template for more information
using visitor.console.Elements;
using visitor.console.Visitors;

var firstContract = new Consulting
{
    Name = "21345",
    Resources = new List<Resource>()
};
firstContract.Resources.Add(new Internal { Id = 1.ToString(), Name = "Pierre" });
firstContract.Resources.Add(new Internal { Id = 2.ToString(), Name = "Jean" });
firstContract.Resources.Add(new External { Id = 3.ToString(), Name = "Paul" });

var firstContractor = new Contractor { Resource = new Internal { Id = 4.ToString(), Name = "Tom" } };
var secondContractor = new Contractor { Resource = new External { Id = 5.ToString(), Name = "Jerry" } };

var allContracts = new List<Contract>{
    firstContract, firstContractor, secondContractor
};
var referenceVisitor = new ReferenceVisitor();
var descriptionVisitor = new DescriptionVisitor();
var priceVisitor = new PriceVisitor();

foreach (var contract in allContracts)
{
    referenceVisitor.Visit(contract);
    descriptionVisitor.Visit(contract);
    priceVisitor.Visit(contract);
    Console.WriteLine($"Contract Reference {referenceVisitor.Reference}");
    Console.WriteLine($"Contract Description {descriptionVisitor.Description}");
    Console.WriteLine($"Contract Description Alt {descriptionVisitor}");
    Console.WriteLine($"Contract cost {priceVisitor.Cost} and price {priceVisitor.Price}");
}