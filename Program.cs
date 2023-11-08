using ScreenProduct.Models;

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
Catalog catalogProducts = new("Produtos");

ViewMenu();

void ViewMenu()
{
    Console.Clear();
    Signature();
    Console.WriteLine("Opções:");
    Console.WriteLine("1 - Registrar produto");
    Console.WriteLine("2 - Listar produtos");
    Console.WriteLine("3 - Avaliar produto");
    Console.WriteLine("4 - Exibir média do produto");
    Console.WriteLine("-1 - Sair");

    int inputOption;
    
    bool isInt;

    do
    {
        Console.Write("\n Digite a sua opção: ");
        string input = Console.ReadLine()!;
        isInt = int.TryParse(input, out inputOption);
        ValidateInput("A opção tem que ser um número inteiro", isInt);
    } while (!isInt);

    switch (inputOption)
    {
        case 1:
            RegisterProduct();
            ViewMenu();
            break;
        case 2:
            ViewListProduct();
            ViewMenu();
            break;
        case 3:
            EvaluateProduct();
            ViewMenu();
            break;
        case 4:
            ViewMedia();
            ViewMenu();
            break;
        case -1:
            Console.WriteLine("Programa finalizado");
            return;
        default:
            Console.WriteLine("Opção inválida");
            Thread.Sleep(3000);
            ViewMenu();
            break;
    }
}

void RegisterProduct()
{
    int quantity;
    bool isInt;
    bool nameIsString;
    bool markIsString;
    string inputName;
    string inputMark;
    Mark mark;

    do
    {
        Console.Clear();
        ViewTitle("Registro de produtos");
        Console.Write("Digite o nome do produto que deseja registrar: ");
        inputName = Console.ReadLine()!.ToLower();
        nameIsString = inputName.All(char.IsDigit);
        ValidateInput("O nome deve ser um texto", !nameIsString);
    } while (nameIsString);

    do
    {
        Console.Clear();
        ViewTitle("Registro de produtos");
        Console.Write("Digite a marca do produto que deseja registrar: ");
        inputMark = Console.ReadLine()!.ToLower();
        markIsString = inputMark.All(char.IsDigit);
        mark = new(inputMark);
        ValidateInput("A marca deve ser um texto", !markIsString);
    } while (markIsString);

    do
    {
        Console.Clear();
        ViewTitle("Registro de produtos");
        Console.Write("Digite a quantidade em estoque: ");
        string inputQuantity = Console.ReadLine()!;
        isInt = int.TryParse(inputQuantity, out quantity);
        ValidateInput("A quantidade deve ser um número inteiro", isInt);
    } while (!isInt);

    Product product = new(inputName, mark, quantity);
    catalogProducts.AddProduct(product);
    Console.WriteLine($"\nO produto {inputName} foi registrado com sucesso!");
    Thread.Sleep(3000);
    return;
}

void ViewListProduct()
{
    Console.Clear();
    ViewTitle("Produtos registrados");
    bool validateVarible = catalogProducts.GetProductCount() != 0;
    if (validateVarible)
    {
        catalogProducts.ListProducts();
        Console.WriteLine("\nAperte qualquer tecla para voltar ao menu");
        Console.ReadKey();
    } else
    {
        Console.WriteLine("\nNenhum produto registrado, registre um produto");
        Thread.Sleep(3500);
        RegisterProduct();
        ViewListProduct();
    }
    return;
}

void EvaluateProduct()
{
    string inputName;
    bool nameAccepted;
    bool isInt;
    bool evaluationAccept;
    int evaluation;

    Console.Clear();
    ViewTitle("Avaliar produto");
    bool existingProduct = catalogProducts.GetProductCount() != 0;
    if (existingProduct)
    {
        do
        {   
            catalogProducts.ViewRegisteredProducts();
            Console.Write("\nDigite o nome do produto que deseja avaliar: ");
            inputName = Console.ReadLine()!.ToLower();
            nameAccepted = catalogProducts.GetProduct(inputName);
            ValidateInput("Produto não encontrado", nameAccepted);
        } while (!nameAccepted);

        do
        {
            Console.Write($"Dê a nota de 1 a 10 para o produto {inputName}: ");
            string inputEvaluation = Console.ReadLine()!;
            isInt = int.TryParse(inputEvaluation, out evaluation);
            ValidateInput("A nota deve ser um número inteiro", isInt);
            evaluationAccept = evaluation >= 1 && evaluation <= 10;
            ValidateInput("A nota deve estar entre 1 e 10", evaluationAccept);
        } while (!(isInt && evaluationAccept));
        
        catalogProducts.GetEvaluations(inputName).Add(evaluation);
        Console.WriteLine($"\nVocê deu nota {evaluation} para o produto {inputName}");
        Thread.Sleep(2000);
    } else
    {
        Console.WriteLine("\nNenhum produto registrado, registre um produto");
        Thread.Sleep(3500);
        RegisterProduct();
        EvaluateProduct();
    }
    return;
}

void ViewMedia()
{
    string inputName;
    bool validateVarible;

    Console.Clear();
    ViewTitle("Exibir média do produto");
    bool existingProduct = catalogProducts.GetProductCount() == 0;
    if (!existingProduct)
    {   
        do{
            catalogProducts.ViewRegisteredProducts();
            Console.Write("\nDigite o nome do produto que deseja exibir a média: ");
            inputName = Console.ReadLine()!.ToLower();
            validateVarible = catalogProducts.GetProduct(inputName);
            ValidateInput("Produto não encontrado", validateVarible);
        } while(!validateVarible);

        List<int> evaluationsProduct = catalogProducts.GetEvaluations(inputName);

        bool verifyEvaluation = evaluationsProduct.Count == 0;
        if (!verifyEvaluation)
        {
            Console.WriteLine($"\nA média do produto {inputName} é: {evaluationsProduct.Average()}");
            Console.WriteLine("\nAperte qualquer tecla para voltar ao menu");
            Console.ReadKey();
        } else 
        {
            Console.Clear();
            Console.WriteLine("\nEsse produto ainda não possui nenhuma nota, avalie esse produto com uma nota");
            Thread.Sleep(3500);
            EvaluateProduct();
            ViewMedia();
        }
    } else
    {
        Console.WriteLine("\nNenhum produto registrado, registre um produto");
        Thread.Sleep(3500);
        RegisterProduct();
        ViewMedia();
    }
    return;
}

void ViewTitle(string title) 
{
    int quantityLetters = title.Length;
    string pattern = string.Empty.PadLeft(quantityLetters, '*');
    Console.WriteLine(pattern);
    Console.WriteLine(title);
    Console.WriteLine(pattern + "\n");
}

void ValidateInput(string errorMessage, bool condition = false) {
    if (!condition)
    {
        Console.Clear();
        Console.WriteLine($"\n{errorMessage}");
        Thread.Sleep(3500);
        return;
    }
}
