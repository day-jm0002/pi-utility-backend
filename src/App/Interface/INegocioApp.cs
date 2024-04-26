using App.Result;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Interface
{
    public interface INegocioApp
    {
        Task<List<NegocioResult>> ObterTodos();
    }
}
