namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(placa))
            {
                Console.WriteLine("Placa inválida. Tente novamente.");
                return;
            }

            if (veiculos.Any(x => x.Equals(placa, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Este veículo já está estacionado.");
                return;
            }

            veiculos.Add(placa.ToUpper());
            Console.WriteLine("Veículo adicionado com sucesso!");
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(placa))
            {
                Console.WriteLine("Placa inválida. Tente novamente.");
                return;
            }

            if (veiculos.Any(x => x.Equals(placa, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                int horas;
                while (!int.TryParse(Console.ReadLine(), out horas) || horas < 0)
                {
                    Console.WriteLine("Valor inválido. Digite um número inteiro positivo para as horas:");
                }

                decimal valorTotal = precoInicial + precoPorHora * horas;

                veiculos.RemoveAll(x => x.Equals(placa, StringComparison.OrdinalIgnoreCase));

                Console.WriteLine($"O veículo {placa.ToUpper()} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}