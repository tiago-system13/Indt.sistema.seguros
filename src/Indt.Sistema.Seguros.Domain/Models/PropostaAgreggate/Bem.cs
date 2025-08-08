using Indt.Sistema.Seguros.Domain.Shared.Enums;

namespace Indt.Sistema.Seguros.Domain.Models.PropostaAgreggate
{
    public class Bem
    {
        public string Marca { get; private set; }

        public string AnoFabricacao { get; private set; }

        public string Placa { get; private set; }

        public Categoria Categoria { get; private set; }

        public string Utilizacao { get; private set; }

        public string Cor { get; private set; }

        public string Chassi { get; private set; }

        public Bem(string marca, string anoFabricacao, string placa, Categoria categoria, string utilizacao, string cor, string chassi)
        {
            Marca = marca;
            AnoFabricacao = anoFabricacao;
            Placa = placa;
            Categoria = categoria;
            Utilizacao = utilizacao;
            Cor = cor;
            Chassi = chassi;
        }
    }
}
