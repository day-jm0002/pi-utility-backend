using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Entidade
{
    public class Perfil
    {
        public string CGC_CPF { get; set; }
        public string CODCLIENTE { get; set; }        
        public string NOME { get; set; }
        public string PERFIL { get; set; }
        public int? CODPERFIL { get; set; }
        public DateTime? DATAATUALIZACAO { get; set; }        
        public string PERFILVENCIDO { get; set; }
        public string CODCLASSIF_GERENCIAL { get; set; }
        public string BASE { get; set; }
        public string NOMEPERFIL { get; set; }
        public string BASEPERFIL { get; set; }
        public int CODCATEGORIA { get; set; }
        public string NOMECATEGORIA { get; set; }
        public string BASECATEGORIA { get; set; }

    }
}
