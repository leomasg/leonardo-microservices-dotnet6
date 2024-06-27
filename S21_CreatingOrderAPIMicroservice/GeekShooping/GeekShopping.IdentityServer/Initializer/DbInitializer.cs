using GeekShopping.IdentityServer.Configuration;
using GeekShopping.IdentityServer.Model;
using GeekShopping.IdentityServer.Model.Context;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace GeekShopping.IdentityServer.Initializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly MySQLContext _context;
        private readonly UserManager<ApplicationUser> _user;
        private readonly RoleManager<IdentityRole> _role;

        public DbInitializer(MySQLContext context,
            UserManager<ApplicationUser> user,
            RoleManager<IdentityRole> role)
        {
            _context = context;
            _user = user;
            _role = role;
        }

        public void Initialize()
        {
            if (_role.FindByNameAsync(IdentityConfiguration.Admin).Result != null) return;
            _role.CreateAsync(new IdentityRole(
                IdentityConfiguration.Admin)).GetAwaiter().GetResult();
            _role.CreateAsync(new IdentityRole(
                IdentityConfiguration.Client)).GetAwaiter().GetResult();

            ApplicationUser admin = new ApplicationUser()
            {
                UserName = "leandro-admin",
                Email = "leandro-admin@erudio.com.br",
                EmailConfirmed = true,
                PhoneNumber = "+55 (34) 12345-6789",
                FirstName = "Leandro",
                LastName = "Admin"
            };

            _user.CreateAsync(admin, "Erudio123$").GetAwaiter().GetResult();
            _user.AddToRoleAsync(admin,
                IdentityConfiguration.Admin).GetAwaiter().GetResult();
            var adminClaims = _user.AddClaimsAsync(admin, new Claim[]
            {
                new Claim(JwtClaimTypes.Name, $"{admin.FirstName} {admin.LastName}"),
                new Claim(JwtClaimTypes.GivenName, admin.FirstName),
                new Claim(JwtClaimTypes.FamilyName, admin.LastName),
                new Claim(JwtClaimTypes.Role, IdentityConfiguration.Admin)
            }).Result;

            ApplicationUser client = new ApplicationUser()
            {
                UserName = "leandro-client",
                Email = "leandro-client@erudio.com.br",
                EmailConfirmed = true,
                PhoneNumber = "+55 (34) 12345-6789",
                FirstName = "Leandro",
                LastName = "Client"
            };

            _user.CreateAsync(client, "Erudio123$").GetAwaiter().GetResult();
            _user.AddToRoleAsync(client,
                IdentityConfiguration.Client).GetAwaiter().GetResult();
            var clientClaims = _user.AddClaimsAsync(client, new Claim[]
            {
                new Claim(JwtClaimTypes.Name, $"{client.FirstName} {client.LastName}"),
                new Claim(JwtClaimTypes.GivenName, client.FirstName),
                new Claim(JwtClaimTypes.FamilyName, client.LastName),
                new Claim(JwtClaimTypes.Role, IdentityConfiguration.Client)
            }).Result;

            //------------------------------------------------------------------------------

            ApplicationUser admin2 = new ApplicationUser()
            {
                UserName = "leonardo-admin",
                Email = "leomasg@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "+55 (21) 98315-6014",
                FirstName = "Leonardo",
                LastName = "Admin"
            };

            _user.CreateAsync(admin2, "Leonardo@123").GetAwaiter().GetResult();
            _user.AddToRoleAsync(admin2,
                IdentityConfiguration.Admin).GetAwaiter().GetResult();
            var adminClaims2 = _user.AddClaimsAsync(admin2, new Claim[]
            {
                new Claim(JwtClaimTypes.Name, $"{admin2.FirstName} {admin2.LastName}"),
                new Claim(JwtClaimTypes.GivenName, admin2.FirstName),
                new Claim(JwtClaimTypes.FamilyName, admin2.LastName),
                new Claim(JwtClaimTypes.Role, IdentityConfiguration.Admin)
            }).Result;

            ApplicationUser client2 = new ApplicationUser()
            {
                UserName = "leonardo-client",
                Email = "leomasg@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "+55 (21) 98315-6014",
                FirstName = "leonardo",
                LastName = "Client"
            };

            _user.CreateAsync(client2, "Leonardo@123").GetAwaiter().GetResult();
            _user.AddToRoleAsync(client2,
                IdentityConfiguration.Client).GetAwaiter().GetResult();
            var clientClaims2 = _user.AddClaimsAsync(client2, new Claim[]
            {
                new Claim(JwtClaimTypes.Name, $"{client2.FirstName} {client2.LastName}"),
                new Claim(JwtClaimTypes.GivenName, client2.FirstName),
                new Claim(JwtClaimTypes.FamilyName, client2.LastName),
                new Claim(JwtClaimTypes.Role, IdentityConfiguration.Client)
            }).Result;

        }
    }
}
