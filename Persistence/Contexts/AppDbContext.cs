using Core.Security.Entities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        protected IConfiguration _configuration;

        public AppDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            _configuration = configuration;
        }

        public DbSet<ProgramLanguage> ProgramLanguages { get; set; }
        public DbSet<Tech> Teches { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgramLanguage>(p =>
            {
                p.HasKey(k => k.Id);

                p.HasMany(k => k.Teches);
            });

            modelBuilder.Entity<Tech>(p =>
            {
                p.HasKey(k => k.Id);
                p.Property(k => k.ProgramLanguageId).HasColumnName("ProgramLanguageId");

                p.HasOne(k => k.ProgramLanguage);
            });

            modelBuilder.Entity<UserProfile>(p =>
            {
                p.HasKey(k => k.Id);
                p.Property(k => k.UserId).HasColumnName("UserId");

                p.HasOne(k => k.User);
            });

            modelBuilder.Entity<User>(p =>
            {
                p.HasKey(k => k.Id);
            });

            modelBuilder.Entity<OperationClaim>(p =>
            {
                p.HasKey(k => k.Id);
            });

            modelBuilder.Entity<UserOperationClaim>(p =>
            {
                p.HasKey(k => k.Id);
                p.Property(k => k.OperationClaimId).HasColumnName("OperationClaimId");
                p.Property(k => k.UserId).HasColumnName("UserId");

                p.HasOne(k => k.OperationClaim);
                p.HasOne(k => k.User);
            });


            List<ProgramLanguage> programLanguages = new() {
                new() { Id = 1, LanguageName = "C#" },
                new() { Id = 2, LanguageName = "Java" },
                new() { Id = 3, LanguageName = "Python" },
                new() { Id = 4, LanguageName = "JavaScript" },
            };

            List<Tech> teches = new() {
                new() { Id = 1, ProgramLanguageId = 1, Name="WPF" },
                new() { Id = 2, ProgramLanguageId = 1, Name="ASP.NET" },
                new() { Id = 3, ProgramLanguageId = 2,  Name="Spring" },
                new() { Id = 4, ProgramLanguageId = 4,  Name="Vue" },
                new() { Id = 5, ProgramLanguageId = 4,  Name="React" },
            };

            List<OperationClaim> operationClaims = new()
            {
                 new(){  Id = 1, Name = "User" },
                 new(){  Id = 2, Name = "Admin" },
            };

            modelBuilder.Entity<ProgramLanguage>().HasData(programLanguages.ToArray());
            modelBuilder.Entity<Tech>().HasData(teches.ToArray());
            modelBuilder.Entity<OperationClaim>().HasData(operationClaims.ToArray());
        }



    }
}
