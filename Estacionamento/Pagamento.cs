using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento
{
    internal class Pagamento
    {
        public double ValorDoPagamento { get; private set; }
        public double ValorDoCaixa { get; private set; }


        public bool cobranca(double valorDoPagamento)
        {
            Console.Clear();
            double valorDaCobranca = valorDoPagamento * 0.0833;

            Console.WriteLine("A conta foi paga? Sim[S] ou Não[N]");
            string opcao = Console.ReadKey(true).KeyChar.ToString().ToUpper();
            do
            {
                if(opcao == "S")
                {
                    ValorDoCaixa = valorDaCobranca;
                    return true;
                }
                else
                    return false;

            } while ((opcao != "N") || (opcao != "S"));
        }
    }
}
