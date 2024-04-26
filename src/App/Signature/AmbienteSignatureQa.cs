using System;
using System.Collections.Generic;
using System.Text;

namespace App.Signature
{
    public class AmbienteSignatureQa
    {
        public int Id { get; set; }
        public string Release { get; set; }
        public string Requisicao { get; set; }
        public List<PacoteSignature> Branch { get; set; } = new List<PacoteSignature>();
        public int DevId { get; set; }
        public int NegId { get; set; }
        public DateTime DataImplantacao { get; set; }
    }
}
