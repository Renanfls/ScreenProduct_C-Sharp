class Mark
{
  public Mark(string name)
  {
    Name = name;
  }
  private List<Catalog> catalogs = new();
  public string Name { get; set; }

  public void ViewCatalogs()
  {
    Console.WriteLine($"Catalogo da marca {Name}");
    foreach (Catalog catalog in catalogs)
    {
      Console.WriteLine($"Catalogo: {catalog.Name}");
    }
  }
}