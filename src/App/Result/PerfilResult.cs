using System;
using System.Collections.Generic;
using System.Text;

namespace App.Result
{
    public class PerfilResult
    {
        public string Documento { get; set; }
        public string CodCliente { get; set; }
        public int? CodPerfil { get; set; }
        public string DataAtualizacao { get; set; }
        public bool PerfilVencido { get; set; }
        public string CodGerencial { get; set; }
        public string Base { get; set; }
    }
}
