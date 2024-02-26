using locadoraSamDiego;
using System.Text.RegularExpressions;

decimal precoInicial = 6.0m; 
decimal precoPorHora = 3.0m; 

Estacionamento estacionamento = new Estacionamento(10, precoInicial, precoPorHora);

Console.WriteLine("Sejam bem vindos ao Estacionamento do SAM Diego!!!!");
Console.WriteLine("---------------------------------------------------");

Console.WriteLine("\nTabela de preços: \n. Preço Inicial: R$6,00 \n. Preco Por Hora: R$3,00");
Console.WriteLine("\nATENÇÂO!!! Nosso estacionamento só possui 10 vagas. Venha antes que acabe!!!");

while (true)
{
    Console.WriteLine("\nEscolha uma opção:");
    Console.WriteLine("1. Estacionar carro");
    Console.WriteLine("2. Retirar carro");
    Console.WriteLine("3. Editar placa");
    Console.WriteLine("4. Listar carros estacionados");
    Console.WriteLine("5. Sair");
    Console.WriteLine("\nOBS: Para selecionar uma das opções utilize a tecla ENTER.\n");

    string opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            Console.WriteLine("Digite a placa do carro (formato ABC1D23):");
            string placaEstacionar = LerPlaca();
            Carro novoCarro = new Carro(placaEstacionar);
            estacionamento.EstacionarCarro(novoCarro);
            break;

        case "2":
            Console.WriteLine("Digite a placa do carro a ser retirado (formato ABC1D23):");
            string placaRetirar = LerPlaca();

            Console.WriteLine("Digite a quantidade de horas que o carro permaneceu estacionado:");
            int horas = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a quantidade de minutos que o carro permaneceu estacionado:");
            int minutos = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a quantidade de segundos que o carro permaneceu estacionado:");
            int segundos = int.Parse(Console.ReadLine());

            estacionamento.RetirarCarro(placaRetirar, horas, minutos, segundos);
            break;

        case "3":
            Console.WriteLine("Digite a placa antiga do carro:");
            string placaAntiga = LerPlaca();
            Console.WriteLine("Digite a nova placa do carro:");
            string novaPlaca = LerPlaca();
            estacionamento.EditarPlaca(placaAntiga, novaPlaca);
            break;

        case "4":
            ListarCarrosEstacionados(estacionamento);
            break;

        case "5":
            Console.WriteLine("Saindo do programa...");
            return;

        default:
            Console.WriteLine("Opção inválida. Tente novamente.");
            break;
    }
}


static void ListarCarrosEstacionados(Estacionamento estacionamento)
{
    Console.WriteLine("\nCarros estacionados:");
    foreach (Carro carro in estacionamento.CarrosEstacionados)
    {
        Console.WriteLine($"Placa: {carro.Placa}");
    }
}

static string LerPlaca()
{
    string placa;
    do
    {
        placa = Console.ReadLine().ToUpper();
        if (!ValidarPlaca(placa))
        {
            Console.WriteLine("Placa inválida. Digite novamente (formato ABC1D23):");
        }
    } while (!ValidarPlaca(placa));
    return placa;
}

static bool ValidarPlaca(string placa)
{
    Regex regex = new Regex(@"^[A-Z]{3}\d[A-Z]\d{2}$");
    return regex.IsMatch(placa);
}