using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace locadoraSamDiego
{
    public class Estacionamento
    {
        private int capacidadeMaxima;
        private List<Carro> carrosEstacionados;
        private decimal precoInicial;
        private decimal precoPorHora;

        public Estacionamento(int capacidade, decimal precoInicial, decimal precoPorHora)
        {
            capacidadeMaxima = capacidade;
            carrosEstacionados = new List<Carro>();
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public List<Carro> CarrosEstacionados
        {
            get { return carrosEstacionados; }
        }

        public bool EstacionarCarro(Carro carro)
        {
            if (carrosEstacionados.Exists(c => c.Placa == carro.Placa))
            {
                Console.WriteLine($"O carro com placa {carro.Placa} já está estacionado.");
                return false;
            }

            if (carrosEstacionados.Count < capacidadeMaxima)
            {
                carrosEstacionados.Add(carro);
                Console.WriteLine($"Carro com placa {carro.Placa} estacionado com sucesso!");
                return true;
            }
            else
            {
                Console.WriteLine("Estacionamento cheio! Não é possível estacionar.");
                return false;
            }
        }

        public bool EditarPlaca(string placaAntiga, string novaPlaca)
        {
            Carro carroExistente = carrosEstacionados.Find(c => c.Placa == novaPlaca);
            if (carroExistente != null)
            {
                Console.WriteLine($"A placa {novaPlaca} já está em uso. Escolha uma placa diferente.");
                return false;
            }

            Carro carro = carrosEstacionados.Find(c => c.Placa == placaAntiga);
            if (carro != null)
            {
                carro.Placa = novaPlaca;
                Console.WriteLine($"Placa do carro alterada de {placaAntiga} para {novaPlaca}.");
                return true;
            }
            else
            {
                Console.WriteLine($"Carro com placa {placaAntiga} não encontrado no estacionamento.");
                return false;
            }
        }

        public void RetirarCarro(string placa, int horas, int minutos, int segundos)
        {
            Carro carro = carrosEstacionados.Find(c => c.Placa == placa);
            if (carro != null)
            {
                decimal precoTotal = CalcularPrecoTotal(horas, minutos, segundos);
                carrosEstacionados.Remove(carro);
                Console.WriteLine($"Carro com placa {placa} retirado do estacionamento. Preço total: R${precoTotal}");
            }
            else
            {
                Console.WriteLine($"Carro com placa {placa} não encontrado no estacionamento.");
            }
        }

        private decimal CalcularPrecoTotal(int horas, int minutos, int segundos)
        {
            decimal precoTotal = precoInicial;
            int totalMinutos = horas * 60 + minutos + (segundos > 0 ? 1 : 0);
            if (totalMinutos > 60)
            {
                precoTotal += (int)Math.Ceiling((double)(totalMinutos - 60) / 60) * precoPorHora;
            }
            return precoTotal;
        }
    }
}
