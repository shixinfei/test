using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TestDB.Models.Mapping
{
    public class TableWithTrigger1Map : EntityTypeConfiguration<TableWithTrigger1>
    {
        public TableWithTrigger1Map()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.value1)
                .HasMaxLength(256);

            this.Property(t => t.value2)
                .HasMaxLength(256);

            this.Property(t => t.value3)
                .HasMaxLength(256);

            // Table & Column Mappings
            this.ToTable("TableWithTrigger1");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.value1).HasColumnName("value1");
            this.Property(t => t.value2).HasColumnName("value2");
            this.Property(t => t.value3).HasColumnName("value3");
        }
    }
}
