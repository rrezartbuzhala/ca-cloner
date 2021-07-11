using System;
using Microsoft.AspNetCore.Identity;

namespace [solutionName].Domain.Entities.Identity
{
    public class User : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
