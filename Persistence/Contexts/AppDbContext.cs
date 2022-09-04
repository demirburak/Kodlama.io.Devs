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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgramLanguage>(p =>
            {
                p.HasKey(k => k.LanguageId);
            });

            List<ProgramLanguage> programLanguages = new() {
                new() { LanguageId = 1, LanguageName = "C#" },
                new() { LanguageId = 2, LanguageName = "Java" },
                new() { LanguageId = 3, LanguageName = "Python" }
            };

            modelBuilder.Entity<ProgramLanguage>().HasData(programLanguages.ToArray());
        }

        public DbSet<ProgramLanguage> ProgramLanguages { get; set; }
    }
}
