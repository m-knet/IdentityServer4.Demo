using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using IdentityModel;
using IdentityServer4;

namespace IdentityServer4Demo.Seed
{
    public class Client
    {
        public bool Enabled { get; set; } = true;

        public string ClientId { get; set; }

        public string ProtocolType { get; set; } = IdentityServerConstants.ProtocolTypes.OpenIdConnect;

        public ICollection<Secret> ClientSecrets { get; set; } = new HashSet<Secret>();

        public bool RequireClientSecret { get; set; } = true;
        
        public string ClientName { get; set; }
        
        public string Description { get; set; }

        public string ClientUri { get; set; }

        public string LogoUri { get; set; }

        public bool RequireConsent { get; set; } = true;

        public bool AllowRememberConsent { get; set; } = true;

        public ICollection<string> AllowedGrantTypes { get;set; }

        public bool RequirePkce { get; set; } = false;

        public bool AllowPlainTextPkce { get; set; } = false;

        public bool AllowAccessTokensViaBrowser { get; set; } = false;

        public ICollection<string> RedirectUris { get; set; } = new HashSet<string>();

        public ICollection<string> PostLogoutRedirectUris { get; set; } = new HashSet<string>();

        public string FrontChannelLogoutUri { get; set; }

        public bool FrontChannelLogoutSessionRequired { get; set; } = true;

        public string BackChannelLogoutUri { get; set; }

        public bool BackChannelLogoutSessionRequired { get; set; } = true;

        public bool AllowOfflineAccess { get; set; } = false;

        public ICollection<string> AllowedScopes { get; set; } = new HashSet<string>();

        public bool AlwaysIncludeUserClaimsInIdToken { get; set; } = false;

        public int IdentityTokenLifetime { get; set; } = 300;

        public int AccessTokenLifetime { get; set; } = 3600;

        public int AuthorizationCodeLifetime { get; set; } = 300;

        public int AbsoluteRefreshTokenLifetime { get; set; } = 2592000;

        public int SlidingRefreshTokenLifetime { get; set; } = 1296000;

        public int? ConsentLifetime { get; set; } = null;

        public IdentityServer4.Models.TokenUsage RefreshTokenUsage { get; set; } = IdentityServer4.Models.TokenUsage.OneTimeOnly;

        public bool UpdateAccessTokenClaimsOnRefresh { get; set; } = false;

        public IdentityServer4.Models.TokenExpiration RefreshTokenExpiration { get; set; } = IdentityServer4.Models.TokenExpiration.Absolute;

        public IdentityServer4.Models.AccessTokenType AccessTokenType { get; set; } = IdentityServer4.Models.AccessTokenType.Jwt;

        public bool EnableLocalLogin { get; set; } = true;

        public ICollection<string> IdentityProviderRestrictions { get; set; } = new HashSet<string>();

        public bool IncludeJwtId { get; set; } = false;

        public IDictionary<string, string> Claims { get; set; } = new Dictionary<string, string>();

        public bool AlwaysSendClientClaims { get; set; } = false;

        public string ClientClaimsPrefix { get; set; } = "client_";

        public string PairWiseSubjectSalt { get; set; }

        public int? UserSsoLifetime { get; set; }

        public string UserCodeType { get; set; }

        public int DeviceCodeLifetime { get; set; } = 300;

        public ICollection<string> AllowedCorsOrigins { get; set; } = new HashSet<string>();

        public IDictionary<string, string> Properties { get; set; } = new Dictionary<string, string>();

        public IdentityServer4.Models.Client ToModel()
        {
            return new IdentityServer4.Models.Client
            {
                AbsoluteRefreshTokenLifetime = AbsoluteRefreshTokenLifetime,
                AccessTokenLifetime = AccessTokenLifetime,
                AccessTokenType = AccessTokenType,
                AllowAccessTokensViaBrowser = AllowAccessTokensViaBrowser,
                AllowedCorsOrigins = AllowedCorsOrigins,
                AllowedGrantTypes = AllowedGrantTypes,
                AllowedScopes = AllowedScopes,
                AllowOfflineAccess = AllowOfflineAccess,
                AllowPlainTextPkce = AllowPlainTextPkce,
                AllowRememberConsent = AllowRememberConsent,
                AlwaysIncludeUserClaimsInIdToken = AlwaysIncludeUserClaimsInIdToken,
                AlwaysSendClientClaims = AlwaysSendClientClaims,
                AuthorizationCodeLifetime = AuthorizationCodeLifetime,
                BackChannelLogoutSessionRequired = BackChannelLogoutSessionRequired,
                BackChannelLogoutUri = BackChannelLogoutUri,
                Claims = Claims.Select(c => new Claim(c.Key, c.Value)).ToList(),
                ClientClaimsPrefix = ClientClaimsPrefix,
                ClientId = ClientId,
                ClientName = ClientName,
                ClientSecrets = ClientSecrets.Select(c => new IdentityServer4.Models.Secret
                {
                    Type = c.Type,
                    Description = c.Description,
                    Expiration = c.Expiration,
                    Value = c.Value.ToSha256()
                }).ToList(),
                ClientUri = ClientUri,
                ConsentLifetime = ConsentLifetime,
                Description = Description,
                DeviceCodeLifetime = DeviceCodeLifetime,
                Enabled = Enabled,
                EnableLocalLogin = EnableLocalLogin,
                FrontChannelLogoutSessionRequired = FrontChannelLogoutSessionRequired,
                FrontChannelLogoutUri = FrontChannelLogoutUri,
                IdentityProviderRestrictions = IdentityProviderRestrictions,
                IdentityTokenLifetime = IdentityTokenLifetime,
                IncludeJwtId = IncludeJwtId,
                LogoUri = LogoUri,
                PairWiseSubjectSalt = PairWiseSubjectSalt,
                PostLogoutRedirectUris = PostLogoutRedirectUris,
                Properties = Properties,
                ProtocolType = ProtocolType,
                RedirectUris = RedirectUris,
                RefreshTokenExpiration = RefreshTokenExpiration,
                RefreshTokenUsage = RefreshTokenUsage,
                RequireClientSecret = RequireClientSecret,
                RequireConsent = RequireConsent,
                RequirePkce = RequirePkce,
                SlidingRefreshTokenLifetime = SlidingRefreshTokenLifetime,
                UpdateAccessTokenClaimsOnRefresh = UpdateAccessTokenClaimsOnRefresh,
                UserCodeType = UserCodeType,
                UserSsoLifetime = UserSsoLifetime
            };
        }
    }
}