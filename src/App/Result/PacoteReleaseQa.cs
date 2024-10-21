using System;
using System.Collections.Generic;
using System.Text;

namespace App.Result
{
    public class PacoteReleaseQa
    {
        public int ReleaseId { get; set; }  
        public string Branch { get; set; }
        public string NegocioTeste { get; set; }
        public int NegocioTesteId { get; set; }

        public int SituacaoId { get; set; }
        public string Situacao { get; set; }
        public int ChamadoId { get; set; }
        public string Dependencia { get; set; }
        public bool Apagar => false;
    }
}
