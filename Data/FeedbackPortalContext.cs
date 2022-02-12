using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FeedbackPortal.Models;
using FeedbackPortal.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace FeedbackPortal.Models
{
    public class FeedbackPortalContext : IdentityDbContext<FeedbackPortalUser>
    {
        public FeedbackPortalContext(DbContextOptions<FeedbackPortalContext> options)
            : base(options)
        {
        }

        public DbSet<FeedbackPortal.Models.Product> Product { get; set; }

        public DbSet<FeedbackPortal.Models.Client> Client { get; set; }

        public DbSet<FeedbackPortal.Models.Employee> Employee { get; set; }

        public DbSet<FeedbackPortal.Models.Feedback> Feedback { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            {
                base.OnModelCreating(builder);

                builder.Entity<Feedback>()
                .HasOne<Product>(p => p.Product)
                .WithMany(p => p.Feedbacks)
                .HasForeignKey(p => p.ProductId);
                //.HasPrincipalKey(p => p.Id);
                builder.Entity<Feedback>()
                .HasOne<Client>(p => p.Client)
                .WithMany(p => p.Feedbacks)
                .HasForeignKey(p => p.ClientId);
                //.HasPrincipalKey(p => p.Id);
                builder.Entity<Product>()
                .HasOne<Employee>(p => p.Employee)
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.EmployeeId);
                //.HasPrincipalKey(p => p.Id);
            }
        }
    }
}
