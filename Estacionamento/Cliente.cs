using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento
{
    internal class Cliente
    {
        public string Id { get; private set; }
        public DateTime HoraDeEntrada { get; private set; }
        
        public Cliente()
        {
            GerarID();
            HoraDeEntrada = DateTime.Now;
        }

        public void GerarID()
        {
            Random random = new Random();

            string caracteresPermitidos = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            string conjuntoAleatorio = "";

            for (int i = 0; i < 6; i++)
            {
                int indiceAleatorio = random.Next(caracteresPermitidos.Length);
                conjuntoAleatorio += caracteresPermitidos[indiceAleatorio];
            }
            Id = conjuntoAleatorio;
        }
      
        public static double SaidaDoCliente(DateTime horaDaEntrada)
        {
            TimeSpan tempoDePermanecia = DateTime.Now - horaDaEntrada;
            double periodo = tempoDePermanecia.TotalMinutes;

            return periodo;
        }
    }
}
