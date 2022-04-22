using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;

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
                new ApiScope("TestApi.Read","TestApi okuma izni"),
                new ApiScope("ProductsApi.Read","ProductsApi okuma izni"),
                new ApiScope("ProductsApi.Write","ProductsApi yazma izni"),
                new ApiScope("NoyaxChat.Connect","Connect to Chat")
            };
        }
        //Apilar tanımlanır
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            { 
                new ApiResource("TestApi"){Scopes={"TestApi.Write","TestApi.Read"}},
                new ApiResource("ProductsApi"){Scopes={"ProductsApi.Write","ProductsApi.Read"}},
                new ApiResource("NoyaxChat"){Scopes={"NoyaxChat.Connect"}}
            };
        }
        //merkezi kullanıcı yönetimi için inmemory kullanıcı üretiyoruz
        public static IEnumerable<TestUser> GetTestUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId="test-user1",
                    Username="test-user1",
                    Password="159753",
                    Claims =
                    {
                        new Claim("name","test user1"),
                        new Claim("website","https://aynenkanka.com"),
                        new Claim("gender","1")
                    }
                },
                 new TestUser
                {
                    SubjectId="test-user2",
                    Username="test-user2",
                    Password="123456",
                    Claims =
                    {
                        new Claim("name","test user2"),
                        new Claim("website","https://bencedeoyle.com"),
                        new Claim("gender","0")
                    }
                }
            };
        }
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),//Üretilecek token içerisinde kesinlikle bir kullanıcı
                                               //id/user id/subject id olmalıdır.
                                               //OpenId kullanıcı id değerini ifade eder.
                                               //Token’da ‘subid’ olarak tutulacaktır.

                new IdentityResources.Profile()//Kullanıcı profil bilgilerini ve biryandan da kullanıcı
                                               //için var olan tüm claim’leri barındırır.
            };
        }

        //Apiları kullanacak client'lar tanımlanır.
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {    new Client
                {
                    ClientId="NoyaxChat",
                    ClientName="NoyaxChat",
                    ClientSecrets={new Secret("noyaxchatsecret".Sha256())},
                    AllowedGrantTypes={GrantType.ClientCredentials},
                    AllowedScopes={"NoyaxChat.Connect"}
                },

                new Client
                {
                    ClientId ="ClientExample",
                    ClientName="ClientExample",
                    ClientSecrets={new Secret("clientsecret".Sha256())},
                    AllowedGrantTypes = GrantTypes.Hybrid,
                    AllowedScopes = { IdentityServerConstants.StandardScopes.OpenId, IdentityServerConstants.StandardScopes.Profile },//‘AllowedGrantTypes’ property’sine atanan ‘GrantTypes.Hybrid’ değeri ile client’ın ‘ResponseType’ında belirttiği
                                                                                                                                      //‘code’ ve ‘id_token’ değerlerini alabilecek bir grant type bildirilmektedir. Bir önceki adımda bildirdiğimiz gibi ‘code’ esasında
                                                                                                                                      //‘Authorization Code Grant’a karşılık gelmekte ve sadece authorization code’u temsil etmektedir. ‘code id_token’ gibi birden fazla
                                                                                                                                      //ifadenin bir araya gelmiş hali ise Hybrid olarak isimlendirilmekte ve burada ‘id_token’ access token’ın bize ait Auth Server’dan
                                                                                                                                      //geldiğini doğrulayacak kodu temsil etmektedir. Haliyle ‘GrantTypes.Hybrid’ diyerek bu client’ın authororization code ile birlikte
                                                                                                                                      //access token’ı elde etmek istediği bildirilmektedir
                    RedirectUris = { "https://localhost:44370/signin-oidc" },
                    RequirePkce = false
                },

                new Client
                {
                    ClientId ="TestApi",
                    ClientName ="TestApi",
                    ClientSecrets= {new Secret("test".Sha256())},
                    AllowedGrantTypes={ GrantType.ClientCredentials},
                    AllowedScopes={"TestApi.Write","TestApi.Read"}                    
                },
                new Client
                {
                    ClientId="ProductsApi",
                    ClientName="ProductsApi",
                    ClientSecrets={new Secret("productsSecret".Sha256())},
                    AllowedGrantTypes={GrantType.ClientCredentials},
                    AllowedScopes={"ProductsApi.Write","ProductsApi.Read"}
                },
                 new Client
                {
                    ClientId="SitkiTugrul",
                    ClientName="Noyax",
                    ClientSecrets={new Secret("Yuksel".Sha256())},
                    AllowedGrantTypes={GrantType.ClientCredentials},
                    AllowedScopes={"ProductsApi.Write","TestApi.Read","ProductsApi.Read"}
                }
            };
        }
    }
}
