using Proxy.DriveAMnet.Response;
using System.Net;
using System.Threading.Tasks;

namespace Proxy.DriveAMnet.Interface
{
    public interface IDriveAMnetProxy
    {
        Task<DriveAMnetResponse> Autenticar();
    }
}
