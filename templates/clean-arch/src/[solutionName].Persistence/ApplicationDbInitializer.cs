using System.Collections.Generic;
using System.IO;
using System.Linq;
using [solutionName].Domain.Entities.Identity;
using Newtonsoft.Json;

namespace [solutionName].Persistence
{
    public class ApplicationDbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            new ApplicationDbInitializer().Seed(context);
        }
        private void Seed(ApplicationDbContext context)
        {
            SeedUser(context);
            SeedRoles(context);
        }
        private void SeedUser(ApplicationDbContext context)
        {
            if (context.Users.FirstOrDefault() != null) return;

            var users = JsonConvert.DeserializeObject<IList<User>>(ReadJson("users.json"));
            context.Users.AddRange(users);
            SeedUserClaims(context, users);
            context.SaveChanges();
        }
        private void SeedUserClaims(ApplicationDbContext context, IList<User> users)
        {
            foreach (var user in users)
            {
                var userClaims = new List<UserClaim>
                {
                    new UserClaim{UserId = user.Id,ClaimType="userId",ClaimValue=user.Id.ToString()},
                    new UserClaim{UserId = user.Id,ClaimType="Email",ClaimValue=user.Email},
                    new UserClaim{UserId = user.Id,ClaimType="UserName",ClaimValue=user.UserName},
                    new UserClaim{UserId = user.Id,ClaimType="FirstName",ClaimValue=user.FirstName},
                    new UserClaim{UserId = user.Id,ClaimType="LastName",ClaimValue=user.LastName},
                    new UserClaim{UserId = user.Id,ClaimType="EmailConfirmed",ClaimValue=user.EmailConfirmed.ToString()},
                    new UserClaim{UserId = user.Id,ClaimType="SecurityStamp",ClaimValue=user.SecurityStamp.ToString()},
                };
                context.UserClaims.AddRange(userClaims);
            }
        }

        private void SeedRoles(ApplicationDbContext context)
        {
            if (context.Roles.FirstOrDefault() != null) return;

            var roles = JsonConvert.DeserializeObject<IList<Role>>(ReadJson("roles.json"));
            context.Roles.AddRange(roles);
            context.SaveChanges();
        }

        private string ReadJson(string fileName)
        {
            var assembly = typeof(ApplicationDbContext).Assembly;

            var resources = assembly.GetManifestResourceNames();

            using (Stream stream = assembly.GetManifestResourceStream(resources.First(x => x.Contains(fileName))))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    var result = reader.ReadToEnd();
                    return result;
                }
            }
        }
    }
}
