using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Entidade
{
    public class Perfil
    {
        public string CGC_CPF { get; set; }
        public string CODCLIENTE { get; set; }
        public int? CODPERFIL { get; set; }
        public DateTime? DATAATUALIZACAO { get; set; }
        public bool PERFILVENCIDO { get; set; }
        public string CODCLASSIF_GERENCIAL { get; set; }
        public string BASE { get; set; }

    }
}
