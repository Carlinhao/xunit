﻿using System.Threading.Tasks;
using CursoOnline.DominioTest.Cursos;
using Microsoft.EntityFrameworkCore;

namespace CursoOnline.Infrastructure.Contextos
{
    public class AplicationDbContext : DbContext
    {
        public DbSet<Curso> Cursos { get; set; }
        
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options)
            :base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public async Task Commit()
        {
            await SaveChangesAsync();
        } 
    }
}