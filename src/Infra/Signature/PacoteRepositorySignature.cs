using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Signature
{
    public class PacoteRepositorySignature
    {
        public int ReleaseId { get; set; }
        public string Branch { get; set; }
        public int ChamadoId { get; set; }
        public int NegocioTesteId { get; set; }
        public int SituacaoId { get; set; }
        public string Dependencia { get; set; }
    }
}
