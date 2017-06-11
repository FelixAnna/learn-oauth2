using IdentityModel.Client;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            ApiHelperBase h1 = new ApiHelperClientCridentials();
            h1.Call();

            ApiHelperBase h2 = new ApiHelperPasswords();
            h2.Call();
        }
    }
}