using System.Threading.Tasks;

namespace example.signedurl.Services
{
    public interface IGetPresignedUrl
    {
        Task<string> Execute();
    }
}