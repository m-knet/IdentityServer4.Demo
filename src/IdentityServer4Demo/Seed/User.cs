using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using IdentityModel;

namespace IdentityServer4Demo.Seed
{
    public class User
    {
        public string SubjectId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string ProviderName { get; set; }

        public string ProviderSubjectId { get; set; }

        public bool IsActive { get; set; } = true;

        public IDictionary<string, string> Claims { get; set; } = new Dictionary<string, string>();

        public IdentityServer4.Test.TestUser ToModel()
        {
            return new IdentityServer4.Test.TestUser
            {
                Claims = Claims.Select(c => new Claim(c.Key, c.Value)).ToHashSet(new ClaimComparer()),
                IsActive = IsActive,
                Password = Password,
                ProviderName = ProviderName,
                ProviderSubjectId = ProviderSubjectId,
                SubjectId = SubjectId,
                Username = Username
            };
        }
    }
}