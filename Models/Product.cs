namespace ScreenProduct.Models;

class Product 
{
  public Product(string name, Mark mark , int quantify)
  {
    Name = name;
    Mark = mark;
    Quantity = quantify;
  }
  public string Name { get; }
  public Mark Mark { get; }
  public int Quantity { get; } = 0;
  public string DescriptionProduct 
  { 
    get 
    {
      string verifyMark = (Mark.Name == " ") ? "Não registrada" : $"{Mark.Name}";
      string available = (Quantity <= 0) ? "Esgotado" : $"Em estoque: {Quantity}";
      return $"Nome: {Name} | Marca: {verifyMark} | Disponibilidade: {available}";
    }
  }

  public void ViewProductDetails()
  {
    Console.WriteLine(DescriptionProduct);
  }
}