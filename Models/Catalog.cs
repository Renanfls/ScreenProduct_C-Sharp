namespace ScreenProduct.Models;

class Catalog
{
  private List<Product> products = new();

  public Catalog(string name)
  {
    Name = name;
  }
  // private Dictionary<Product, List<int>> registrationProducts = new(){};
  public string Name { get; }

  public void AddProduct(Product product)
  {
    // registrationProducts.Add(product, new List<int>());
    products.Add(product);
  }

  public void ListProducts()
  {
    // foreach (Product produto in registrationProducts.Keys)
    foreach (Product produto in products)
    {
      produto.ViewProductDetails();
    }
  }

  public void ViewRegisteredProducts()
  {
    // foreach (Product produto in registrationProducts.Keys)
    foreach (Product produto in products)
    {
      Console.WriteLine($"Produto: {produto.Name}");
    }
  }

  public int GetProductCount()
  {
    return products.Count;
  }

  public bool GetProduct(string input)
  {
    // return registrationProducts.Keys.Any(product => product.Name.ToLower() == input);
    return products.Any(product => product.Name.ToLower() == input);
  }
  
  public List<int> GetEvaluations(string input)
  {
    // return registrationProducts.First(product => product.Key.Name.ToLower() == input).Value;
    return products.First(product => product.Name.ToLower() == input);
  }
}
