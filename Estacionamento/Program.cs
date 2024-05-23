using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento
{
    internal class Program
    {
        /*Orientação do desenvolvedor:
            Para fazer o teste de funcionalidade ou execultar o sistema,
            devera ser realizado faazendo a utilização de BreakPoints para 
            obter as informações aarmazenadas na lista de Clientes.
        */
        public static void Main(string[] args)
        {
            var armazenamento = new Armazenamento();
            Pagamento pagamento = new Pagamento();

            void mensagem(string mensagem)
            {
                ConsoleKeyInfo chave = new ConsoleKeyInfo();
                do
                {
                    Console.Clear();
                    Console.WriteLine(mensagem);
                    Console.WriteLine("Pressione [ENTER] para continuar...");
                    chave = Console.ReadKey(true);
                } while (chave.Key != ConsoleKey.Enter);
                Console.Clear();
            }

            string opcao;
            do
            {
                Console.Clear();
                Console.WriteLine("Pressione [N] para adicionar um novo cliente");
                Console.WriteLine("-");
                Console.WriteLine("Pressione [P] para pesquisar no sistema");
                Console.WriteLine("-");
                Console.WriteLine("Pressione [D] para deletar cliente do sistema");
                Console.WriteLine("-");
                Console.WriteLine("Pressione [S] para sair do sistema");
                Console.WriteLine("-");

                opcao = Console.ReadKey(true).KeyChar.ToString().ToUpper();
                switch (opcao)
                {
                    case "N":
                        Cliente cliente = new Cliente();
                        armazenamento.AdicionarClienteNaLista(cliente);
                        break;

                    case "P":
                        Console.Clear();
                        Console.WriteLine("Código: ");
                        string verificadorDeCliente = Console.ReadLine();
                        
                        var clienteSalvo = armazenamento.PesquisarNaLista(verificadorDeCliente);

                        if (clienteSalvo == null)
                            mensagem("O cliente " + verificadorDeCliente + " não existe no sistema.");
                        else
                            mensagem("Cliente " + clienteSalvo.Id + " encontrado com sucesso no sistema.");

                        break;

                    case "D":
                        Console.Clear();
                        Console.WriteLine("Código: ");
                        string removedor = Console.ReadLine();
                         
                        var verificador = armazenamento.PesquisarNaLista(removedor);

                        if (verificador == null)
                            mensagem("O cliente " + removedor + " não existe no sistema.");
                        else
                        { 
                            double valorDaCobranca = Cliente.SaidaDoCliente(verificador.HoraDeEntrada);
                            bool condicao = pagamento.cobranca(valorDaCobranca);

                            if (condicao == true)
                            {
                                Console.Clear();
                                armazenamento.RemoverNaLista(removedor);
                                mensagem("Pagamento foi efetuado com sucesso!");
                            }
                            else
                            {
                                Console.Clear();
                                mensagem("Pagamento não foi efetuado com sucesso!");
                            }   
                        }
                        break;
                    
                }
            } while (opcao != "e");
        }
    }
}