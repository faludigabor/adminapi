using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
namespace CSharp
{
    public class RapidStart
    {
        internal static async Task GetRapidStartPackages(string accessToken, string environmentName, string apiVersion, string companyId)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            // POST https://api.businesscentral.dynamics.com/v2.0/{environment name}/api/microsoft/automation/{apiVersion}/companies({{companyId}})/configurationPackages('SAMPLE}')/Microsoft.NAV.import

            HttpResponseMessage response = await httpClient.GetAsync($"https://api.businesscentral.dynamics.com/v2.0/{environmentName}/api/microsoft/automation/{apiVersion}/companies({companyId})/configurationPackages");
            string responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(JsonConvert.SerializeObject(JsonConvert.DeserializeObject(responseBody), Formatting.Indented));
        }

        //PATCH https://api.businesscentral.dynamics.com/v2.0/{environment name}/api/microsoft/automation/{apiVersion}/companies({{companyId}})/configurationPackages('{SAMPLE}')/file('{SAMPLE}')/content

        //POST https://api.businesscentral.dynamics.com/v2.0/{environment name}/api/microsoft/automation/{apiVersion}/companies({companyId})/configurationPackages
        internal static async Task CreatePackage(string accessToken, string environmentName, string apiVersion, string companyId, string code, string packageName)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            // POST https://api.businesscentral.dynamics.com/v2.0/{environment name}/api/microsoft/automation/{apiVersion}/companies({{companyId}})/configurationPackages('SAMPLE}')/Microsoft.NAV.import
            // {
            //     "code":"{SAMPLE}",
            //     "packageName": "{SAMPLE}"
            // }
            var body = new
            {
                code = code,
                packageName = packageName
            };
            var content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await httpClient.PostAsync($"https://api.businesscentral.dynamics.com/v2.0/{environmentName}/api/microsoft/automation/{apiVersion}/companies({companyId})/configurationPackages", content);
            string responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(JsonConvert.SerializeObject(JsonConvert.DeserializeObject(responseBody), Formatting.Indented));
        }

        internal static  async Task DeletePackage(string accessToken,string environmentName, string apiVersion, string companyId, string code)
        {
           var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
           

            HttpResponseMessage response = await httpClient.DeleteAsync($"https://api.businesscentral.dynamics.com/v2.0/{environmentName}/api/microsoft/automation/{apiVersion}/companies({companyId})/configurationPackages({code})");
            string responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(JsonConvert.SerializeObject(JsonConvert.DeserializeObject(responseBody), Formatting.Indented));
        }

        internal static async Task UploadPackage(string accessToken, string environmentName, string apiVersion, string companyId, string FileName, string packageCode)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            httpClient.DefaultRequestHeaders.Add("If-Match","*");
            httpClient.DefaultRequestHeaders.Add("accept-encoding","gzip, deflate");
            // PATCH https://api.businesscentral.dynamics.com/v2.0/{environment name}/api/microsoft/automation/{apiVersion}/companies({{companyId}})/configurationPackages('{SAMPLE}')/file('{SAMPLE}')/content
            var FileStream = new FileStream(FileName, FileMode.Open);
            
            var content = new StreamContent(FileStream);
            await content.ReadAsStreamAsync();
            content.Headers.ContentType =
                new MediaTypeHeaderValue("application/octet-stream");
                // content.Headers.Add("If-Match","*");
                // content.Headers.Add("accept-encoding","gzip, deflate");
            HttpResponseMessage response = await httpClient
            .PatchAsync($"https://api.businesscentral.dynamics.com/v2.1/{environmentName}/api/microsoft/automation/{apiVersion}/companies({companyId})/configurationPackages('{packageCode}')/file('{packageCode}')/content", content);
            string responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(JsonConvert.SerializeObject(JsonConvert.DeserializeObject(responseBody), Formatting.Indented));
        }
    }     
}