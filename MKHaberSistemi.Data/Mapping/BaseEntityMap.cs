using MKHaberSistemi.Core.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MKHaberSistemi.Data.Mapping
{
    public abstract class BaseEntityMap<TEntity>:EntityTypeConfiguration<TEntity> where TEntity:BaseEntity
    {
        protected BaseEntityMap()
        {
            HasKey(b => b.ID);
            Property(b => b.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
