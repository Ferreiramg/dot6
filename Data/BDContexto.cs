using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Minimal.Models;

namespace Minimal.Data
{
    public class BDContexto : DbContext
    {
        public DbSet<Estudante> Estudante { get; set; } = default!;
        public DbSet<Curso> Curso { get; set; } = default!;

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite("DataSource=app.db;Cache=Shared");

    }
}
