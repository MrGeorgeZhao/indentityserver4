using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer4.Quickstart.UI
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource> { new ApiResource("api1", "My API") };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>{
        //new Client
        //{
        //    ClientId = "client",

        //    // no interactive user, use the clientid/secret for authentication
        //    //AllowedGrantTypes = GrantTypes.ClientCredentials,
        //    AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
        //    // secret for authentication
        //    ClientSecrets =
        //    {
        //        new Secret("secret".Sha256())
        //    },

        //    // scopes that client has access to
        //    AllowedScopes = { "api1" }
        //},
         new Client
        {
            ClientId = "mvc1",
            ClientName = "MVC Client",
           // AllowedGrantTypes = GrantTypes.Implicit,
            AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,
            // where to redirect to after login
           RequireConsent = true,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    RedirectUris = { "http://localhost:5002/signin-oidc" }, //注意端口5002 是我们修改的Client的端口
                    PostLogoutRedirectUris = { "http://localhost:5002/signout-callback-oidc" },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "api1"
                    },
                    AllowOfflineAccess = true
        },
             new Client
        {
            ClientId = "mvc2",
            ClientName = "MVC Client",
            AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,

         RequireConsent = true,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    RedirectUris = { "http://localhost:5003/signin-oidc" },
                    PostLogoutRedirectUris = { "http://localhost:5003/signout-callback-oidc" },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "api1"
                    },
                    AllowOfflineAccess = true
        }
    };
        }


        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
    {
        new TestUser
        {
            SubjectId = "1",
            Username = "alice",
            Password = "password"
        },
        new TestUser
        {
            SubjectId = "2",
            Username = "bob",
            Password = "password"
        }
    };
        }


        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
    {
        new IdentityResources.OpenId(),
        new IdentityResources.Profile(),
    };
        }
    }
}
