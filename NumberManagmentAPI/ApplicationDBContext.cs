using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using App.Models;

namespace NumberManagmentAPI
{
    public class ApplicationDBContext : DbContext
    {
        public virtual DbSet<CategoryModel> Category { get; set; }
        public virtual DbSet<NumberModel> Number { get; set; }
        public virtual DbSet<NumberStatusModel> NumberStatus { get; set; }
        public virtual DbSet<QuarentineInfoModel> QuarentineInfo { get; set; }
        public virtual DbSet<EquipamentModel> Equipament { get; set; }
        public virtual DbSet<NumberEquipamentModel> NumberEquipament { get; set; }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NumberEquipamentModel>(entity => 
            {
                entity.HasKey(e => new { e.EquipamentId, e.NumberId });
            });
        }

    }
}
