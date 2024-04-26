using App.Result;
using App.Signature;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Interface
{
    public interface IInfoBancApp
    {
        Task<List<GerenteResult>> ObterListaGerentes();
        Task<GerenteResult> ObterGerente(GerenteSignature gerenteSignature);
    }
}
