using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Entidade
{
    public class AmbienteQa
    {
        public int ReleaseId { get; set; }
        public string Nome { get; set; }
        public string Requisicao { get; set; }
        public int DesenvolvedorId { get; set; }
        public int NegocioId { get; set; }
        public string Desenvolvedor { get; set; }
        public string Negocio { get; set; }
        public string DataImplantacao { get; set; }
    }
}
