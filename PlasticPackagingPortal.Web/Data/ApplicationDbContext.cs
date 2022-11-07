using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PlasticPackagingPortal.Web.Models.Data;

namespace PlasticPackagingPortal.Web.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Item> Items { get; set; } = null!;

        public DbSet<StagingItem> StagingItems { get; set; } = null!;

        public DbSet<Tag> Tags { get; set; } = null!;

        public DbSet<StagingTag> StagingTags { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            SetSequentialGuidAsDefaultValuesForPKs(modelBuilder);

            
        }


        private static void SetSequentialGuidAsDefaultValuesForPKs(ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                var entityClass = entity.ClrType;
                
                foreach (var property in entityClass.GetProperties().Where(p => p.PropertyType == typeof(Guid) && p.CustomAttributes.Any(a => a.AttributeType == typeof(DatabaseGeneratedAttribute))))
                {
                    modelBuilder.Entity(entityClass).Property(property.Name).ValueGeneratedOnAdd().HasDefaultValueSql("newsequentialid()");
                }
            }
        }
    }
}
