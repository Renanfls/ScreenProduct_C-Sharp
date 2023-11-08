namespace ScreenProduct.Models;

class Mark
{
  public Mark(string name)
  {
    Name = name;
  }
  private List<Catalog> catalogs = new();
  private List<int> evaluations = new();
  public string Name { get; }

    public void AddEvaluation(int evaluation)
  {
    evaluations.Add(evaluation);
  }
  public void ViewCatalogs()
  {
    Console.WriteLine($"Catalogo da marca {Name}");
    foreach (Catalog catalog in catalogs)
    {
      Console.WriteLine($"Catalogo: {catalog.Name}");
    }
  }
}