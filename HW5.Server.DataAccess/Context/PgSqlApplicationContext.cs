using HW5.Server.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5.Server.DataAccess.Context
{
    public class PgSqlApplicationContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Operator> Operators { get; set; }
        public DbSet<Questionnaire> Questionnaires { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=wh5db;Username=postgres;Password=ne4hbsgx");
        }

        public PgSqlApplicationContext(DbContextOptions<PgSqlApplicationContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        public PgSqlApplicationContext()
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Console.WriteLine("DB model creating starts!");

            base.OnModelCreating(modelBuilder);


            Console.WriteLine("New Model created");
        }
    }
}
