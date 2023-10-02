class Catalog
{
  public Catalog(string name)
  {
    Name = name;
  }
  private Dictionary<Product, List<int>> registrationProducts = new(){};
  public string Name { get; set; }

  public void AddProduct(Product product)
  {
    registrationProducts.Add(product, new List<int>());
  }

  public void ListProducts()
  {
    foreach (Product produto in registrationProducts.Keys)
    {
      produto.ViewProductDetails();
    }
  }

  public void ViewRegisteredProducts()
  {
    foreach (Product produto in registrationProducts.Keys)
    {
        Console.WriteLine($"Produto: {produto.Name}");
    }
  }

  public int GetProductCount()
  {
    return registrationProducts.Count;
  }

  public bool GetProduct(string input)
  {
    return registrationProducts.Keys.Any(product => product.Name.ToLower() == input);
  }
  
  public List<int> GetEvaluations(string input)
  {
    return registrationProducts.First(product => product.Key.Name.ToLower() == input).Value;
  }
}
