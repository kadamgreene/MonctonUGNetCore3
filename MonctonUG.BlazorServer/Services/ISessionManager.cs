using MonctonUG.BlazorServer.Data;
using System.Threading.Tasks;

namespace MonctonUG.BlazorServer.Services
{
    public interface ISessionManager
    {
        Task<SessionState> GetState();
    }
}