using Indt.Sistema.Seguros.Domain.Shared.Enums;

namespace Indt.Sistema.Seguros.App.API.Propostas.CriarProposta
{
    public class BemMovelDto
    {
        public string Marca { get;  set; }

        public string AnoFabricacao { get;  set; }

        public string Placa { get;  set; }

        public Categoria Categoria { get;  set; }

        public string Utilizacao { get;  set; }

        public string Cor { get;  set; }

        public string Chassi { get;  set; }

    }
}
