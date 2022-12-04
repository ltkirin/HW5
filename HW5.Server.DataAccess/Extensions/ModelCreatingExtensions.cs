using HW5.Server.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace HW5.Server.DataAccess.Extensions
{
    public static class ModelCreatingExtensions
    {
        public static void BuildModels(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .ToTable("Clients")
                .HasKey(x => x.Id);
            modelBuilder.Entity<Client>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Client>()
                .HasMany(x => x.Questionnaires)
                .WithOne()
                .HasForeignKey(x => x.ClientId);

            modelBuilder.Entity<Operator>()
                .ToTable("Operators")
                .HasKey(x => x.Id);
            modelBuilder.Entity<Operator>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Operator>()
                .HasMany(x => x.Questionnaires)
                .WithOne()
                .HasForeignKey(x => x.OperatorId);


            modelBuilder.Entity<Questionnaire>()
                .ToTable("Questionnairies")
                .HasKey(x => new { x.Id, x.OperatorId, x.ClientId });
            modelBuilder.Entity<Questionnaire>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Questionnaire>()
                .HasOne(x => x.Client)
                .WithMany(x => x.Questionnaires)
                .HasForeignKey(x => x.ClientId);
            modelBuilder.Entity<Questionnaire>()
                .HasOne(x => x.Operator)
                .WithMany(x => x.Questionnaires)
                .HasForeignKey(x => x.OperatorId);
            modelBuilder.Entity<Questionnaire>()
            .Property(e => e.CreationDate)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("now()");





        }
    }
}
