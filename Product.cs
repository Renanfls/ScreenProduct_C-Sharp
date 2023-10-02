class Product 
{
  public string Name { get; set; }
  public string Mark { get; set; }
  public int Quantity { get; set; } = 0;
  public string DescriptionProduct 
  { 
    get 
    {
      string verifyMark = (Mark == "") ? "Não registrada" : $"{Mark}";
      string available = (Quantity <= 0) ? "Esgotado" : $"Em estoque: {Quantity}";
      return $"Nome: {Name} | Marca: {verifyMark} | Disponibilidade: {available}";
    }
  }

  public void ViewProductDetails()
  {
    Console.WriteLine(DescriptionProduct);
  }
}