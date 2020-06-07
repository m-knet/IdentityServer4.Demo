using System.Collections.Generic;
using System.Linq;
using IdentityModel;

namespace IdentityServer4Demo.Seed
{
    public class ApiResource : Resource
    {
        public ICollection<Secret> ApiSecrets { get; set; } = new HashSet<Secret>();

        public ICollection<Scope> Scopes { get; set; } = new HashSet<Scope>();

        public IdentityServer4.Models.ApiResource ToModel()
        {
            return new IdentityServer4.Models.ApiResource
            {
                ApiSecrets = ApiSecrets.Select(c => new IdentityServer4.Models.Secret
                {
                    Type = c.Type,
                    Description = c.Description,
                    Expiration = c.Expiration,
                    Value = StringExtensions.ToSha256(c.Value)
                }).ToList(),
                Description = Description,
                DisplayName = DisplayName,
                Enabled = Enabled,
                Name = Name,
                Properties = Properties,
                Scopes = Scopes.Select(s => new IdentityServer4.Models.Scope
                {
                    Description = s.Description,
                    DisplayName = s.DisplayName,
                    Emphasize = s.Emphasize,
                    Name = s.Name,
                    Required = s.Required,
                    ShowInDiscoveryDocument = s.ShowInDiscoveryDocument,
                    UserClaims = s.UserClaims
                }).ToList(),
                UserClaims = UserClaims,
            };
        }
    }
}