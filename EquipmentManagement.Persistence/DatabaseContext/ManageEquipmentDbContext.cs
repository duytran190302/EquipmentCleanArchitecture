using EquipmentManagement.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentManagement.Persistence.DatabaseContext
{
	public class ManageEquipmentDbContext: DbContext
	{
        public ManageEquipmentDbContext(DbContextOptions<ManageEquipmentDbContext> options): base (options)
        {
            
        }

		public DbSet<EquipmentType> EquipmentType { get; set; }
		public DbSet<Location> Location { get; set; }
		public DbSet<Borrow> Borrow { get; set; }
		public DbSet<Equipment> Equipment { get; set; }
		public DbSet<Project> Project { get; set; }
		public DbSet<Supplier> Supplier { get; set; }
		public DbSet<Specification> Specification { get; set; }
		public DbSet<Tag> Tag { get; set; }
		public DbSet<Picture> Picture { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// Xác định các thuộc tính làm key
			modelBuilder.Entity<Supplier>().HasKey(p => p.SupplierName);
			modelBuilder.Entity<Location>().HasKey(p => p.LocationId);
			modelBuilder.Entity<Project>().HasKey(p => p.ProjectName);



			modelBuilder.Entity<Picture>().HasKey(e => e.PictureId);
			modelBuilder.Entity<Picture>().HasOne(s => s.EquipmentType).WithMany(x => x.Pictures).HasForeignKey(s => s.EquipmentTypeId);
			modelBuilder.Entity<Specification>().HasKey(e => e.SpecificationId);
			modelBuilder.Entity<Specification>().HasOne(s => s.EquipmentType).WithMany(x=>x.Specifications).HasForeignKey(s => s.EquipmentTypeId);



			modelBuilder.Entity<Borrow>().HasKey(p => p.BorrowId);
			modelBuilder.Entity<Equipment>().HasKey(e => e.EquipmentId);
			//modelBuilder.Entity<Equipment>().HasOne(x=>x.Supplier);
			modelBuilder.Entity<Borrow>().HasMany<Equipment>(b => b.Equipments).WithMany(e => e.Borrows);

			modelBuilder.Entity<Borrow>().HasOne(s => s.Project).WithMany(x=>x.Borrows).HasForeignKey(s => s.ProjectName);

			modelBuilder.Entity<EquipmentType>().HasKey(e => e.EquipmentTypeId);
			modelBuilder.Entity<EquipmentType>().HasMany<Tag>(t => t.Tags).WithMany(t => t.EquipmentTypes);
			modelBuilder.Entity<Tag>().HasKey(e => e.TagId);
		}
	}


}
