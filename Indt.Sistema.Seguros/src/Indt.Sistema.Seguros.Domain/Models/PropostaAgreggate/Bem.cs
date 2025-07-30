using Indt.Sistema.Seguros.Domain.Shared.Enums;

namespace Indt.Sistema.Seguros.Domain.Models.PropostaAgreggate
{
    public class Bem
    {
        public string Marca { get; set; }

        public string AnoFabricacao { get; set; }

        public string Placa { get; set; }

        public Categoria Categoria { get; set; }

        public string Utilizacao { get; set; }

        public string Cor { get; set; }

        public string Chassi { get; set; }
    }
}
