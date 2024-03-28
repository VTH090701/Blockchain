using Blockchain.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Linq.Dynamic.Core.Tokenizer;
using System.Net.Http.Json;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Xml.Linq;
namespace Blockchain.Services



{
    public class ApiService : IApiService
    {
        private readonly HttpClient httpClient;
        private readonly ApiSettings apiSettings;


        public ApiService(HttpClient http, IOptions<ApiSettings> apiSettingsOptions)
        {
            httpClient = http;
            apiSettings = apiSettingsOptions.Value;
        }
        public async Task<ResponseApi<List<string>>> RegisterNode(List<string> listnode)
        {
            try
            {
                var nodeData = new
                {
                    nodes = listnode
                };
                var response = await httpClient.PostAsJsonAsync($"{apiSettings.BaseUrl}:{apiSettings.PortUrl}/nodes/register", nodeData);
                return await response.Content.ReadFromJsonAsync<ResponseApi<List<string>>>();

            }
            catch (Exception ex)
            {
                throw new NotImplementedException();

            }
        }
        public async Task<ResponseApi<string>> CheckSign(string id, List<object> entries)
        {
            try
            {
                var requestData = new
                {
                    entry = entries,
                    id = id
                };

                var jsonContent = JsonConvert.SerializeObject(requestData);
                var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
                var request = new HttpRequestMessage(HttpMethod.Post, $"{apiSettings.BaseUrl}:{apiSettings.PortUrl}/verify_sinature");
                request.Content = content;
                var response = await httpClient.SendAsync(request);
                return await response.Content.ReadFromJsonAsync<ResponseApi<string>>();


                //var data = new
                //{
                //    entry = entries,
                //    id = id
                //};
                //var response = await httpClient.PostAsJsonAsync($"{apiSettings.BaseUrl}:{apiSettings.PortUrl}/verify_sinature", data);
                //return await response.Content.ReadFromJsonAsync<ResponseApi<string>>();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();

            }
        }
        public async Task<ResponseApi<string>> AddTran(string fileContent)
        {
            try
            {

                var content = new StringContent(fileContent, System.Text.Encoding.UTF8, "application/json");
                var request = new HttpRequestMessage(HttpMethod.Post, $"{apiSettings.BaseUrl}:{apiSettings.PortUrl}/transactions");
                request.Content = content;
                var response = await httpClient.SendAsync(request);
                return await response.Content.ReadFromJsonAsync<ResponseApi<string>>();
                

            }
            catch (Exception ex)
            {
                throw new NotImplementedException();

            }
        }

        public async Task<ResponseApi<string>> BackupData()
        {
            try
            {
                var response = await httpClient.GetAsync($"{apiSettings.BaseUrl}:{apiSettings.PortUrl}/backup_disconnect");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<ResponseApi<string>>();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();

            }
        }

        public async Task<ResponseApi<string>> BackupDataAll()
        {
            try
            {
                var response = await httpClient.GetAsync($"{apiSettings.BaseUrl}:{apiSettings.PortUrl}/backup_disconnect_all");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<ResponseApi<string>>();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();

            }
        }

        public async Task<ResponseApi<string>> DefaultNode()
        {
            try
            {
                var response = await httpClient.GetAsync($"{apiSettings.BaseUrl}:{apiSettings.PortUrl}/default_postgresql");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<ResponseApi<string>>();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();

            }
        }

      

        public async Task<ResponseApi<object>> CheckTran(string transaction)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, $"{apiSettings.BaseUrl}:{apiSettings.PortUrl}/chain/get_id_block/{transaction}");
                var response = await httpClient.SendAsync(request);
                return await response.Content.ReadFromJsonAsync<ResponseApi<object>>();

            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
                    
            }
        }

      
    }
}
