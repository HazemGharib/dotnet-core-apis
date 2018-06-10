using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace dotnet_core_apis.Model
{
    public partial class core2apiv1Context : DbContext
    {
        public core2apiv1Context()
        {
        }

        public core2apiv1Context(DbContextOptions<core2apiv1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Values> Values { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=den1.mssql6.gear.host;Database=core2apiv1;Persist Security Info=False;User Id=core2apiv1;Password=zuka*zuka;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Values>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });
        }
    }
}
