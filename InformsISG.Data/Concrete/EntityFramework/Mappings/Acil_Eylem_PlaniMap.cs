using InformsISG.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformsISG.Data.Concrete.EntityFramework.Mappings
{
    public class Acil_Eylem_PlaniMap : IEntityTypeConfiguration<Acil_Eylem_Plani>
    {
        public void Configure(EntityTypeBuilder<Acil_Eylem_Plani> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Plan_Adi).HasMaxLength(50).IsRequired();
            builder.Property(a => a.Dosya).HasMaxLength(150).IsRequired();

            builder.ToTable("acil_eylem_plani");

            builder.HasOne<Birim>(k => k.Birim).WithMany(b => b.Acil_Eylem_Plani).HasForeignKey(b => b.Birim_Id).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne<Isveren>(k => k.Isveren).WithMany(b => b.Acil_Eylem_Plani).HasForeignKey(b => b.Isveren_Id).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
