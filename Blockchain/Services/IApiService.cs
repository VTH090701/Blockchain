using Blockchain.Data;

namespace Blockchain.Services
{
    public interface IApiService
    {
        Task<ResponseApi<string>> DefaultNode(); 
        Task<ResponseApi<string>> BackupData();
        Task<ResponseApi<string>> BackupDataAll();

        Task<ResponseApi<List<string>>> RegisterNode(List<string> listnode);

        Task<ResponseApi<string>> AddTran(string transaction);
        Task<ResponseApi<string>> CheckSign(string id,List<object> entries);

        Task<ResponseApi<object>> CheckTran(string transaction);
    }


}
