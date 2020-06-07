namespace IdentityServer4Demo.Seed
{
    public class SeedOptions
    {
        public IdentityResource[] IdentityResources { get; set; }

        public User[] Users { get; set; }

        public Client[] Clients { get; set; }

        public ApiResource[] ApiResources { get; set; }
    }
}
