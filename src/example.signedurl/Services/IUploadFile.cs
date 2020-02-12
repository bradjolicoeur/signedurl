using System.Threading.Tasks;

namespace example.signedurl.Services
{
    public interface IUploadFile
    {
        Task<string> Execute();
    }
}