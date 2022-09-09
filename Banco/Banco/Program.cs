// See https://aka.ms/new-console-template for more information
#region Codigo
using Banco;

//Dica
List<Clente> Clientes = new List<Clente>();
ConsultarCliente();

// var codigo = Console.ReadLine();
//Se o código do cliente não existir, perguntar se deseja fazer o cadastro
void ConsultarCliente()
{
    Console.WriteLine("Bem-vindo ao seu banco!");
    Console.WriteLine("Digite o código da sua conta:");
    string codigo = Console.ReadLine();
    Cliente cliente = null;

    foreach (Cliente cli in Cliente)
    {
        if (cli.Codigo == codigo)
        {
            cliente = cli;
        }
    }
    if (cliente == null)
    {
        Console.WriteLine("Conta não localizada. Deseja se cadastrar? Digite S ou N");
        string cadastrarCliente = Console.ReadLine();
        if (cadastrarCliente == "S")
        {
            Console.WriteLine("Digite seu código:");
            string codigoClienteNovo = Console.ReadLine();
            Console.WriteLine("Digite seu nome:");
            string nomeClienteNovo = Console.ReadLine();
            Console.WriteLine("PF ou PJ:");
            string tipoPessoa = Console.ReadLine();
            if (tipoPessoa == "PF")
                cliente = new PessoaFisica(codigoClienteNovo, nomeClienteNovo);
            else
                cliente = new PessoaJuridica(codigoClienteNovo, nomeClienteNovo);
            Clientes.Add(cliente);
            ExibirMenu(cliente);
         }
         else
            ConsultarCliente();
    }    
    
}

//Exibir o menu com opçoes
void ExibirMenu(Cliente cliente)
{
    Console.WriteLine($"Olá {cliente.Nome}");
    Console.WriteLine("Digite a opção desejada:");
    Console.WriteLine("1 - Extrato");
    Console.WriteLine("2 - Saque");
    Console.WriteLine("3 - Depósito");

    string menu = Console.ReadLine();

    switch (menu)
    {
    case "1":
        ExibirExtrato(cliente);
        break;
    case "2":
        RealizarSaque(cliente);
        break;
    case "3":
        RealizarDeposito(cliente);
        break;
    default:
            Console.WriteLine("Digite a opção correta.");
            ExibirMenu(cliente);
            break;
    }
}

void ExibirExtrato(Cliente cliente)
{
    Console.WriteLine("------- Extrato --------");

    foreach (Movimentacao mov in cliente.Movimentacao)
    {
        Console.WriteLine($"{mov.Tipo} - {mov.Valor}");
    }

    Console.WriteLine("Deseja exibir o menu novamente? Digite S ou N");
    string exbirMenu  Console.ReadLine();
    if (exbirMenu == "S")
    {
        ExibirMenu(cliente);
    }
    else
    {
        Console.WriteLine("Deseja consultar outro cliente? Digite S ou N");
        string consultarCliente = Console.ReadLine();
        if (consultarCliente == "S")
            ConsultarCliente();
    }
}

void RealizarSaque(Cliente cliente)
{
    Console.WriteLine("Digite o valor que deseja sacar:");
    string valor = Console.ReadLine();
    cliente.RealizarSaque(Convert.ToDecimal(valor));
    Console.WriteLine("Deseja realizar outra transação? Digite S ou N");
    string realizarOutraTransacao = Console.ReadLine();
    if (realizarOutraTransacao == "S")
        ExibirMenu(cliente);
    else 
        Console.WriteLine("Fim da operação.");
}

void RealizarDeposito(Cliente cliente)
{
    Console.WriteLine("Digite o valor que deseja depositar:");
    string valor = Console.ReadLine();
    cliente.RealizarDeposito(Convert.ToDecimal(valor));
    Console.WriteLine("Deseja realizar outra transação? Digite S ou N");
    string realizarOutraTransacao = Console.ReadLine();
    if (realizarOutraTransacao == "S")
        ExibirMenu(cliente);
    else 
        Console.WriteLine("Fim da operação.");
}
