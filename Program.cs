using DadosComCSV.Models;
using DadosComCSV.Repositories;
using DadosComCSV.Services;

var repository = new JogoRepository();
var service = new JogoService(repository);

bool executando = true;

    Console.Clear();
while(executando)
{
    Console.WriteLine("\n===== Gestão de Jogos ======");
    Console.WriteLine("1 - Cadastrar Jogo");
    Console.WriteLine("2 - Listar Jogos");
    Console.WriteLine("0 - Sair");
    Console.WriteLine("\nEscolha uma opção: ");

    string? opcao = Console.ReadLine();

    try
    {
        switch (opcao)
        {
            case "1":
            Cadastrar();
            break;
             case "2":
           Listar();
            break;
            case "0":
            executando = false;
            break;
            default:
            Console.WriteLine("Opção invalida");
            break;
        }
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"\nErro: {ex.Message}");
        throw;
    }
}

void Listar()
{
    Console.Clear();
    Console.WriteLine("============== Jogos cadastrados =================");

    var jogos = service.Listar();

    if(jogos.Count == 0)
    {
        Console.WriteLine("Nenhum jogo cadastrado");
    }
    else
    {
        foreach (var jogo in jogos)
        {
            ExibirJogo(jogo);
        }
    }
    Pausar();
}

void ExibirJogo(Jogo jogo)
{
    Console.WriteLine($"""
    -------------------------
    ID: {jogo.Id}
    Nome: {jogo.Nome}
    Desenvolvedora: {jogo.Desenvolvedora}
    Genero: {jogo.Genero}
    Ano de Lançamento: {jogo.AnoLancamento}
    Preco: {jogo.Preco:C}
    """);
}

void Pausar()
{
    Console.WriteLine("\nPressione ENTER para continuar");
    Console.ReadLine();
}

void Cadastrar()
{
    Console.Clear();
    Console.WriteLine("====== Cadastrar Jogo =======");
    var jogo = LerDadosJogo();

    service.Cadastrar(jogo);

    Console.WriteLine("\nJogo cadastrado com sucesso");
    Pausar();
}

Jogo LerDadosJogo()
{
    Console.WriteLine("Nome: ");
    string nome = Console.ReadLine() ?? "";
    Console.WriteLine("Desenvolvedora: ");
    string desenvolvedora = Console.ReadLine() ?? "";
    Console.WriteLine("Genero: ");
    string genero = Console.ReadLine() ?? "";
    Console.WriteLine("Ano de lançamento: ");
    int ano  = int.Parse(Console.ReadLine() ?? "");
    Console.WriteLine("Preço: ");
    decimal preco  = decimal.Parse(Console.ReadLine() ?? "");

    return new Jogo
    {
        Nome = nome,
        Desenvolvedora = desenvolvedora,
        Genero = genero,
        AnoLancamento = ano,
        Preco = preco
    };
}
