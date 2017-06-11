using IdentityModel.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Client
{
    public class ApiHelperPasswords : ApiHelperBase
    {
        public async override void GetTokenAsync()
        {
            // request token
            tokenClient = new TokenClient(disco.TokenEndpoint, "ro.client", "secret");
            tokenResponse = await tokenClient.RequestResourceOwnerPasswordAsync("alice", "password", "api1");

            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                return;
            }

            Console.WriteLine(tokenResponse.Json);
            Console.WriteLine("\n\n");
        }
    }
}
