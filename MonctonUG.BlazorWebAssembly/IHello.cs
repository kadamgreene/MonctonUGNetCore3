using System.Threading.Tasks;

namespace MonctonUG.BlazorWebAssembly
{
    public interface IHello
    {
        Task<string> SayHello(string name);
    }
}