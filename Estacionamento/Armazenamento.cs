using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento
{
    internal class Armazenamento
    {
        private List<Cliente> Clientes;

        public Armazenamento()
        {
            Clientes = new List<Cliente>();
        }

        public void AdicionarClienteNaLista(Cliente cliente)
        {
            if (ExisteCliente(cliente))
                throw new Exception("Cliente já está cadastrado no estacionamento!");

            Clientes.Add(cliente);
        }

        public bool ExisteCliente(Cliente cliente)
        {
            var clienteExistente = Clientes.Any(c => c.Id == cliente.Id);

            return clienteExistente;
        }

        public Cliente PesquisarNaLista(string individuo)
        {
            var cliente = Clientes.FirstOrDefault(x => x.Id == individuo);
            return cliente;
        }

        public void RemoverNaLista(string individuo)
        {
            Clientes.Remove(PesquisarNaLista(individuo));
        }
    }
}
