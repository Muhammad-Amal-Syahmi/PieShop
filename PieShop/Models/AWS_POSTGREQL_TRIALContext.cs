using Microsoft.AspNetCore.Identity;
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

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

        //    modelBuilder.Entity<Pie>(entity =>
        //    {
        //        entity.Property(e => e.Id).ValueGeneratedNever();

        //        entity.Property(e => e.ImageThumbnailUrl).HasColumnType("character varying");

        //        entity.Property(e => e.ImageUrl).HasColumnType("character varying");

        //        entity.Property(e => e.IsPieOfTheWeek)
        //            .IsRequired()
        //            .HasColumnType("boolean");

        //        entity.Property(e => e.LongDescription).HasColumnType("character varying");

        //        entity.Property(e => e.Name)
        //            .IsRequired()
        //            .HasColumnType("character varying");

        //        entity.Property(e => e.ShortDescription)
        //            .IsRequired()
        //            .HasColumnType("character varying");
        //    });

        //    modelBuilder.HasSequence("aspnetuserclaims_seq");
        //}
    }
}
