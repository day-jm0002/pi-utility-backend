using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Entidade
{
    public class Ambiente
    {
        public int Id { get; set; }
        public string Nome  { get; set; }
        public string Branch { get; set; }
        public string NumeroChamado { get; set; }
        public string Descricao { get; set; }
        public int DevId { get; set; }
        public string Desenvolvedor { get; set; }
        public int NegId { get; set; }

        public int SituacaoId { get; set; }
        public string Negocio { get; set; }
        public string Link { get; set; }
        public string Situacao { get; set; }
        public string Dependencia { get; set; }
    }
}
