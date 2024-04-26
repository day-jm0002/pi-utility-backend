using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Signature
{
    public class EditarAmbienteQaRepositorySignature
    {
        public int AmbienteId { get; set; }
        public string Release { get; set; }
        public string Requisicao { get; set; }
        public List<PacoteRepositorySignature> Branch { get; set; } = new List<PacoteRepositorySignature>();
        public int DevId { get; set; }
        public int NegId { get; set; }
        public DateTime DataImplatacao { get; set; }
    }
}
