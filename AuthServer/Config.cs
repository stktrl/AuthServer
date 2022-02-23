using IdentityServer4.Models;
using System.Collections.Generic;

namespace AuthServer
{
    static public class Config
    {
        //Apilarda kullanılacak yetkilerin tanımı
        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new List<ApiScope>
            {
                new ApiScope("TestApi.Write","TestApi yazma izni"),
                new ApiScope("TestApi.Read","TestApi okuma izni")
            };
        }
        //Apilar tanımlanır
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            { 
                new ApiResource("TestApi"){Scopes={"TestApi.Write","TestApi.Read"}}
            };
        }

        //Apiları kullanacak client'lar tanımlanır.
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            { 
                new Client
                {
                    ClientId ="TestApi",
                    ClientName ="TestApi",
                    ClientSecrets= {new Secret("test".Sha256())},
                    AllowedGrantTypes={ GrantType.ClientCredentials},
                    AllowedScopes={"TestApi.Write","TestApi.Read"}                    
                }
            };
        }
    }
}
