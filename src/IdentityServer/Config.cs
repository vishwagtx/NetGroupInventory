using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;
using System.Security.Claims;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
                new()
                {
                    Name = "app_api",
                    ApiSecrets = { new Secret("secret".Sha256()) },
                    Scopes =
                        {
                            "app_api"
                        },
                    UserClaims =
                    {
                        ClaimTypes.NameIdentifier,
                        ClaimTypes.Name,
                        ClaimTypes.Email,
                        ClaimTypes.Role,
                        JwtClaimTypes.Role,
                        JwtClaimTypes.Name,
                        JwtClaimTypes.Email
                    }
                }
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new()
                {
                    Name = "app_api",
                    UserClaims =
                    {
                        ClaimTypes.NameIdentifier,
                        ClaimTypes.Name,
                        ClaimTypes.Email,
                        ClaimTypes.Role,
                        JwtClaimTypes.Role,
                        JwtClaimTypes.Name,
                        JwtClaimTypes.Email
                    }
                }
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new()
                {
                    ClientId = "i_spa",
                    ClientName = "SPA Client",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,
                    AlwaysSendClientClaims = false,
                    RequireConsent = false,
                    RedirectUris = { Startup.Configuration["spaRedirectURL"]},
                    PostLogoutRedirectUris = { Startup.Configuration["spaPostLogoutURL"] },
                    AllowedCorsOrigins = { Startup.Configuration["spaURL"] },
                    ClientSecrets = {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.LocalApi.ScopeName,
                        "app_api"
                    },
                },
                new()
                    {
                        ClientId = "mobile",
                        ClientName = "Mobile Client",
                        AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                        ClientSecrets = {
                            new Secret("secret".Sha256())
                        },
                        AllowedScopes =
                        {
                            IdentityServerConstants.StandardScopes.OpenId,
                            IdentityServerConstants.StandardScopes.Profile,
                            "app_api"
                        },
                        AllowOfflineAccess = true
                    }
            };
    }
}