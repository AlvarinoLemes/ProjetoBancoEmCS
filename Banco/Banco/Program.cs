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
}