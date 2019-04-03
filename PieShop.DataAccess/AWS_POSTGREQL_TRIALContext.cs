using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PieShop.Auth;

namespace PieShop.Models
{
    public partial class AWS_POSTGREQL_TRIALContext : IdentityDbContext<ApplicationUser>
    {
        public AWS_POSTGREQL_TRIALContext()
        {
        }

        public AWS_POSTGREQL_TRIALContext(DbContextOptions<AWS_POSTGREQL_TRIALContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Pie> Pie { get; set; }
        public virtual DbSet<Feedback> Feedback { get; set; }
        public virtual DbSet<Category> Category { get; set; }
    }
}
