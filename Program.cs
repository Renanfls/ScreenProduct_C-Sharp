void Signature() 
{
    Console.WriteLine($@"
    ░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗
    ██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║
    ╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║
    ░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║
    ██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║
    ╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝

    ██████╗░██████╗░░█████╗░██████╗░██╗░░░██╗░█████╗░████████╗
    ██╔══██╗██╔══██╗██╔══██╗██╔══██╗██║░░░██║██╔══██╗╚══██╔══╝
    ██████╔╝██████╔╝██║░░██║██║░░██║██║░░░██║██║░░╚═╝░░░██║░░░
    ██╔═══╝░██╔══██╗██║░░██║██║░░██║██║░░░██║██║░░██╗░░░██║░░░
    ██║░░░░░██║░░██║╚█████╔╝██████╔╝╚██████╔╝╚█████╔╝░░░██║░░░
    ╚═╝░░░░░╚═╝░░╚═╝░╚════╝░╚═════╝░░╚═════╝░░╚════╝░░░░╚═╝░░░ 
    {"\n"}");
}

Dictionary<string, List<int>> registrationProducts = new Dictionary<string, List<int>>();
registrationProducts.Add("a", new List<int> { 7, 9, 8 });
registrationProducts.Add("b", new List<int>{});

void ViewMenu()
{
    Console.Clear();
    Signature();
    Console.WriteLine("Digite 1 - Registrar produto");
    Console.WriteLine("Digite 2 - Listar produtos");
    Console.WriteLine("Digite 3 - Avaliar produto");
    Console.WriteLine("Digite 4 - Exibir média do produto");
    Console.WriteLine("Digite -1 - Para sair");

    Console.Write("\n Digite a sua opção: ");
    int inputOption = int.Parse(Console.ReadLine()!);

    switch (inputOption)
    {
        case 1:
            RegisterProduct();
            break;
        case 2:
            ViewListProduct();
            break;
        case 3:
            EvaluateProduct();
            break;
        case 4:
            ViewMedia();
            break;
        case -1:
            Console.WriteLine("Programa finalizado");
            break;
        default:
            Console.WriteLine("Opção inválida");
            break;
    }
}

void RegisterProduct()
{
    Console.Clear();
    ViewTitle("Registro de produtos");
    Console.Write("Digite o nome do produto que deseja registrar: ");
    string nameProduct = Console.ReadLine()!.ToLower();
    registrationProducts.Add(nameProduct, new List<int>());
    Console.WriteLine($"\nO produto {nameProduct} foi registrado com sucesso!");
    Thread.Sleep(2000);
    Console.Clear();
    ViewMenu();
}

void ViewListProduct()
{
    Console.Clear();
    ViewTitle("Produtos registrados");
    ViewRegisteredProducts();
    Console.WriteLine("\nAperte qualquer tecla para voltar ao menu");
    Console.ReadKey();
    Console.Clear();
    ViewMenu();
}

void EvaluateProduct()
{
    Console.Clear();
    ViewTitle("Avaliar produto");
    ViewRegisteredProducts();

    Console.Write("\nDigite o nome do produto que deseja avaliar: ");
    string nameProduct = Console.ReadLine()!.ToLower();
    ValidateInput(registrationProducts.ContainsKey(nameProduct), "Produto não encontrado", EvaluateProduct);

    Console.Write($"Dê a nota de 1 a 10 para o produto {nameProduct}: ");
    string input = Console.ReadLine()!;
    bool isInt = int.TryParse(input, out int evaluation);
    ValidateInput(isInt, "A nota deve ser um número inteiro", EvaluateProduct);
    bool evaluationAccept = evaluation >= 1 && evaluation <= 10;
    ValidateInput(evaluationAccept, "A nota deve estar entre 1 e 10", EvaluateProduct);

    registrationProducts[nameProduct].Add(evaluation);
    Console.WriteLine($"\nVocê deu nota {evaluation} para o produto {nameProduct}");
    Thread.Sleep(2000);
    Console.Clear();
    ViewMenu();
}

void ViewMedia()
{
    Console.Clear();
    ViewTitle("Exibir média do produto");
    ViewRegisteredProducts();

    Console.Write("\nDigite o nome do produto que deseja exibir a média: ");
    string nameProduct = Console.ReadLine()!.ToLower();
    ValidateInput(registrationProducts.ContainsKey(nameProduct), "Produto não encontrado", ViewMedia);
    
    List<int> evaluationsProduct = registrationProducts[nameProduct];
    Console.WriteLine($"\nA média do produto {nameProduct} é: {evaluationsProduct.Average()}");
    Console.WriteLine("\nAperte qualquer tecla para voltar ao menu");
    Console.ReadKey();
    Console.Clear();
    ViewMenu();
}

void ViewRegisteredProducts()
{
    foreach (string produto in registrationProducts.Keys)
    {
        Console.WriteLine($"Produto: {produto}");
    }
}

void ViewTitle(string title) 
{
    int quantityLetters = title.Length;
    string pattern = string.Empty.PadLeft(quantityLetters, '*');
    Console.WriteLine(pattern);
    Console.WriteLine(title);
    Console.WriteLine(pattern + "\n");
}

void ValidateInput(bool variable, string mensageError, Action functionReturn) {
    if (!variable)
    {
        Console.WriteLine($"\n{mensageError}");
        Thread.Sleep(2000);
        Console.Clear();
        functionReturn.Invoke();
    }
}

ViewMenu();