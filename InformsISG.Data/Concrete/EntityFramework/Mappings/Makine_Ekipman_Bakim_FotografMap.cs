using InformsISG.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InformsISG.Data.Concrete.EntityFramework.Mappings
{
    public class Makine_Ekipman_Bakim_FotografMap : IEntityTypeConfiguration<Makine_Ekipman_Bakim_Fotograf>
    {
        public void Configure(EntityTypeBuilder<Makine_Ekipman_Bakim_Fotograf> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Dosya).HasMaxLength(150).IsRequired();

            builder.ToTable("makine_ekipman_bakim_fotograf");

            builder.HasOne<Makine_Ekipman_Bakim_Planlari>(k => k.Makine_Ekipman_Bakim_Planlari).WithMany(b => b.Makine_Ekipman_Bakim_Fotograf).HasForeignKey(b => b.Makine_Ekipman_Bakim_Planlari_Id).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
