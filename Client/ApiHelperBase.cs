using IdentityModel.Client;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public abstract class ApiHelperBase
    {
        protected DiscoveryResponse disco;
        protected TokenClient tokenClient;
        protected TokenResponse tokenResponse;

        public async void Call()
        {
            // discover endpoints from metadata
            disco = await DiscoveryClient.GetAsync("http://localhost:5000");

            GetTokenAsync();
            callApi();
        }
        public abstract void GetTokenAsync();

        private async void callApi()
        {
            // call api
            var client = new HttpClient();
            client.SetBearerToken(tokenResponse.AccessToken);

            var response = await client.GetAsync("http://localhost:5001/identity");
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(JArray.Parse(content));
            }
        }
    }
}
