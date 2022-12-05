using HW5.Server.DataAccess.Extensions;
using HW5.Server.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5.Server.DataAccess.Context
{
    public class PgSqlApplicationContext : DbContext
    {

        private string connectionString;
        public DbSet<Client> Clients { get; set; }
        public DbSet<Operator> Operators { get; set; }
        public DbSet<Questionnaire> Questionnaires { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                var extension = optionsBuilder.Options.FindExtension<NpgsqlOptionsExtension>();
                if (extension != null)
                {
                    connectionString = extension.ConnectionString;
                }
                else
                {
                    throw new Exception("No connectionString");
                }
            }
            optionsBuilder.UseNpgsql(connectionString);
        }

        public PgSqlApplicationContext(DbContextOptions<PgSqlApplicationContext> options) : base(options)
        {
            var extension = options.FindExtension<NpgsqlOptionsExtension>();
            if (extension != null)
            {
                connectionString = extension.ConnectionString;
            }
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        public PgSqlApplicationContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Console.WriteLine("DB model creating starts!");
            modelBuilder.BuildModels();

            base.OnModelCreating(modelBuilder);

            Console.WriteLine("New Model created");
        }
    }
}
