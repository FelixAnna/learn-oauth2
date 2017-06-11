using IdentityModel.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Client
{
    public class ApiHelperClientCridentials : ApiHelperBase
    {
        public override async void GetTokenAsync()
        {
            // request token
            tokenClient = new TokenClient(disco.TokenEndpoint, "client", "secret");
            tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");

            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                return;
            }

            Console.WriteLine(tokenResponse.Json);
        }
    }
}
