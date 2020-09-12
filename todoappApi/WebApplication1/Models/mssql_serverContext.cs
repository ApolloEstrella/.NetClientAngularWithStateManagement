using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication1.Models
{
    public partial class mssql_serverContext : DbContext
    {
        public mssql_serverContext()
        {
        }

        public mssql_serverContext(DbContextOptions<mssql_serverContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Todo> Todo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
               // optionsBuilder.UseSqlServer("Server=DESKTOP-GT4AAMB;Database=mssql_server;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            modelBuilder.Entity<Todo>(entity =>
            {
                entity.ToTable("todo");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(20);
            });

             

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
