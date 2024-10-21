using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Entidade
{
    public class Pacote
    {
        public int ReleaseId { get; set; }
        public string Branch { get; set; }
        public int NegocioId { get; set; }
        public string Nome { get; set; }
        public int ChamadoId { get; set; }

        public int SituacaoId { get; set; }
        public string Descricao { get; set; }
        public string Dependencia { get; set; }
    }
}
