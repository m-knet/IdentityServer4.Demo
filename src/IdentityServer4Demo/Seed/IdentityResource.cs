using System.Collections.Generic;

namespace IdentityServer4Demo.Seed
{
    public class IdentityResource : Resource
    {
        public bool Required { get; set; } = false;

        public bool Emphasize { get; set; } = false;

        public bool ShowInDiscoveryDocument { get; set; } = true;

        public IdentityServer4.Models.IdentityResource ToModel()
        {
            return new IdentityServer4.Models.IdentityResource
            {
                Description = Description,
                DisplayName = DisplayName,
                Emphasize = Emphasize,
                Enabled = Enabled,
                Name = Name,
                Properties = Properties,
                Required = Required,
                ShowInDiscoveryDocument = ShowInDiscoveryDocument,
                UserClaims = UserClaims
            };
        }
    }

    public class Scope
    {
        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string Description { get; set; }

        public bool Required { get; set; } = false;

        public bool Emphasize { get; set; } = false;

        public bool ShowInDiscoveryDocument { get; set; } = true;

        public ICollection<string> UserClaims { get; set; } = new HashSet<string>();
    }
}
