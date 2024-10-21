using System;
using System.Collections.Generic;
using System.Text;

namespace App.Signature
{
    public class PacoteSignature
    {
        public string Branch { get; set; }
        public int ChamadoId { get; set; }
        public int NegocioTesteId { get; set; }
        public int SituacaoId { get; set; }
        public string Dependencia { get; set; }
        public bool Apagar { get; set; }
    }
}
