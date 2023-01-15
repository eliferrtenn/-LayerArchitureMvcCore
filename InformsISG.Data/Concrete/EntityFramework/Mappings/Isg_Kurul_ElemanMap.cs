using InformsISG.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InformsISG.Data.Concrete.EntityFramework.Mappings
{
    public class Isg_Kurul_ElemanMap : IEntityTypeConfiguration<Isg_Kurul_Eleman>
    {
        public void Configure(EntityTypeBuilder<Isg_Kurul_Eleman> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();

            builder.ToTable("isg_kurul_eleman");

            builder.HasOne<Isg_Kurul_Karar>(k => k.Isg_Kurul_Karar).WithMany(b => b.Isg_Kurul_Eleman).HasForeignKey(b => b.Isg_Kurul_Karar_Id).OnDelete(DeleteBehavior.NoAction);

            builder.HasOne<Personel_Bilgi>(k => k.Personel_Bilgi).WithMany(b => b.Isg_Kurul_Eleman).HasForeignKey(b => b.Personel_Id).OnDelete(DeleteBehavior.NoAction);


        }
    }
}
