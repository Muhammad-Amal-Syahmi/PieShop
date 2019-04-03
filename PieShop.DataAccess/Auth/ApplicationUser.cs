using System;
using Microsoft.AspNetCore.Identity;

namespace PieShop.Auth
{
    public class ApplicationUser : IdentityUser
    {
        public string City { get; set; }
        public string Country { get; set; }
    }
}
