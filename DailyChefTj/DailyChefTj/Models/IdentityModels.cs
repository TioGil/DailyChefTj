﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DailyChefTj.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        virtual public DbSet<Ingrediente> Ingredientes { get; set; }

        virtual public DbSet<Chef> Chefs { get; set; }

        virtual public DbSet<Direccion> Direcciones { get; set; }

        virtual public DbSet<Medidas> Medidas { get; set; }

        virtual public DbSet<Nutriologo> Nutriologos { get; set; }

        virtual public DbSet<Platillo> Platillos { get; set; }

        virtual public DbSet<Cargo> Cargo { get; set; }

        virtual public DbSet<Venta> Ventas { get; set; }

    }
}