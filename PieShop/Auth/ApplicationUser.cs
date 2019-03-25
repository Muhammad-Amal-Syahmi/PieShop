using System;
using Microsoft.AspNetCore.Identity;

namespace PieShop.Auth
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime BirthDate { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
