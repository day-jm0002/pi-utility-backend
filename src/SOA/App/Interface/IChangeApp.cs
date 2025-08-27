using System.Threading.Tasks;
using PI.Utility.App.Result;
using PI.Utility.Models;

namespace PI.Utility.App.Interface
{
    public interface IChangeApp
    {
        Task<ChangeResult> ProcessarMudanca(ChangeRequest request);
    }
} 