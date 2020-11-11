using System;
using System.Collections.Generic;
using System.Text;
using BlackThreadWeb.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlackThreadWeb.Data
{
    // auto-generated database connection class
    public class ApplicationDbContext : IdentityDbContext
    {
        // reference data models - in-memory version of the tables for CRUD operations

        /*
         * Powershell commands for updating the database schema
         *  1. add-migration <no-space description>
         *  2. update-database
         */

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // override the OnModelCreating method - fixes a bug in the Identity Framework
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
