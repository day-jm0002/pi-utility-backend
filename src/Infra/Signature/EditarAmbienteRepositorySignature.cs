using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Signature
{
    public class EditarAmbienteRepositorySignature
    {
        public int Id { get; set; }
        public string Branch { get; set; }
        public string NumeroChamado { get; set; }
        public string Descricao { get; set; }
        public int DevId { get; set; }
        public int NegId { get; set; }
        public int SitId { get; set; }
        public string Dependencia { get; set; }
    }
}
