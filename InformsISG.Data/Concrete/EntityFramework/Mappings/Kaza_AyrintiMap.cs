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
    public class Kaza_AyrintiMap : IEntityTypeConfiguration<Kaza_Ayrinti>
    {
        public void Configure(EntityTypeBuilder<Kaza_Ayrinti> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Hareketler1).IsRequired();
            builder.Property(a => a.Hareketler2).IsRequired();
            builder.Property(a => a.Hareketler3).IsRequired();
            builder.Property(a => a.Hareketler4).IsRequired();
            builder.Property(a => a.Hareketler5).IsRequired();
            builder.Property(a => a.Hareketler6).IsRequired();
            builder.Property(a => a.Hareketler7).IsRequired();
            builder.Property(a => a.Hareketler8).IsRequired();
            builder.Property(a => a.Hareketler9).IsRequired();
            builder.Property(a => a.Hareketler10).IsRequired();
            builder.Property(a => a.Hareketler11).IsRequired();
            builder.Property(a => a.Hareketler12).IsRequired();
            builder.Property(a => a.Hareketler13).IsRequired();
            builder.Property(a => a.Hareketler14).IsRequired();
            builder.Property(a => a.Hareketler15).IsRequired();
            builder.Property(a => a.Hareketler16).IsRequired();
            builder.Property(a => a.Hareketler17).IsRequired();
            builder.Property(a => a.Hareketler18).IsRequired();
            builder.Property(a => a.Kisisel_Faktorler1).IsRequired();
            builder.Property(a => a.Kisisel_Faktorler2).IsRequired();
            builder.Property(a => a.Kisisel_Faktorler3).IsRequired();
            builder.Property(a => a.Kisisel_Faktorler4).IsRequired();
            builder.Property(a => a.Kisisel_Faktorler5).IsRequired();
            builder.Property(a => a.Kisisel_Faktorler6).IsRequired();
            builder.Property(a => a.Kisisel_Faktorler7).IsRequired();
            builder.Property(a => a.Kisisel_Faktorler8).IsRequired();
            builder.Property(a => a.Kisisel_Faktorler9).IsRequired();
            builder.Property(a => a.Kisisel_Faktorler10).IsRequired();
            builder.Property(a => a.Kisisel_Faktorler11).IsRequired();
            builder.Property(a => a.Kisisel_Faktorler12).IsRequired();
            builder.Property(a => a.Kisisel_Faktorler13).IsRequired();
            builder.Property(a => a.Kisisel_Faktorler14).IsRequired();
            builder.Property(a => a.Kisisel_Faktorler15).IsRequired();
            builder.Property(a => a.Kisisel_Faktorler16).IsRequired();
            builder.Property(a => a.Kisisel_Faktorler17).IsRequired();
            builder.Property(a => a.Kisisel_Faktorler18).IsRequired();
            builder.Property(a => a.Calisma_Kosullari1).IsRequired();
            builder.Property(a => a.Calisma_Kosullari2).IsRequired();
            builder.Property(a => a.Calisma_Kosullari3).IsRequired();
            builder.Property(a => a.Calisma_Kosullari4).IsRequired();
            builder.Property(a => a.Calisma_Kosullari5).IsRequired();
            builder.Property(a => a.Calisma_Kosullari6).IsRequired();
            builder.Property(a => a.Calisma_Kosullari7).IsRequired();
            builder.Property(a => a.Calisma_Kosullari8).IsRequired();
            builder.Property(a => a.Calisma_Kosullari9).IsRequired();
            builder.Property(a => a.Calisma_Kosullari10).IsRequired();
            builder.Property(a => a.Calisma_Kosullari11).IsRequired();
            builder.Property(a => a.Calisma_Kosullari12).IsRequired();
            builder.Property(a => a.Calisma_Kosullari13).IsRequired();
            builder.Property(a => a.Calisma_Kosullari14).IsRequired();
            builder.Property(a => a.Calisma_Kosullari15).IsRequired();
            builder.Property(a => a.Calisma_Kosullari16).IsRequired();
            builder.Property(a => a.Calisma_Kosullari17).IsRequired();
            builder.Property(a => a.Calisma_Kosullari18).IsRequired();
            builder.Property(a => a.Calisma_Kosullari19).IsRequired();
            builder.Property(a => a.Is_Faktorleri1).IsRequired();
            builder.Property(a => a.Is_Faktorleri2).IsRequired();
            builder.Property(a => a.Is_Faktorleri3).IsRequired();
            builder.Property(a => a.Is_Faktorleri4).IsRequired();
            builder.Property(a => a.Is_Faktorleri5).IsRequired();
            builder.Property(a => a.Is_Faktorleri6).IsRequired();
            builder.Property(a => a.Is_Faktorleri7).IsRequired();
            builder.Property(a => a.Is_Faktorleri8).IsRequired();
            builder.Property(a => a.Is_Faktorleri9).IsRequired();
            builder.Property(a => a.Is_Faktorleri10).IsRequired();
            builder.Property(a => a.Is_Faktorleri11).IsRequired();
            builder.Property(a => a.Is_Faktorleri12).IsRequired();
            builder.Property(a => a.Is_Faktorleri13).IsRequired();
            builder.Property(a => a.Is_Faktorleri14).IsRequired();
            builder.Property(a => a.Is_Faktorleri15).IsRequired();
            builder.Property(a => a.Is_Faktorleri16).IsRequired();
            builder.Property(a => a.Is_Faktorleri17).IsRequired();
            builder.Property(a => a.Is_Faktorleri18).IsRequired();
            builder.Property(a => a.Is_Faktorleri19).IsRequired();
            builder.Property(a => a.Kaza_Turu1).IsRequired();
            builder.Property(a => a.Kaza_Turu2).IsRequired();
            builder.Property(a => a.Kaza_Turu3).IsRequired();
            builder.Property(a => a.Kaza_Turu4).IsRequired();
            builder.Property(a => a.Kaza_Turu5).IsRequired();
            builder.Property(a => a.Kaza_Turu6).IsRequired();
            builder.Property(a => a.Kaza_Turu7).IsRequired();
            builder.Property(a => a.Kaza_Turu8).IsRequired();
            builder.Property(a => a.Kaza_Turu9).IsRequired();
            builder.Property(a => a.Kaza_Turu10).IsRequired();
            builder.Property(a => a.Kaza_Turu11).IsRequired();
            builder.Property(a => a.Kaza_Turu12).IsRequired();
            builder.Property(a => a.Yaralanan_Uzuvlar1).IsRequired();
            builder.Property(a => a.Yaralanan_Uzuvlar2).IsRequired();
            builder.Property(a => a.Yaralanan_Uzuvlar3).IsRequired();
            builder.Property(a => a.Yaralanan_Uzuvlar4).IsRequired();
            builder.Property(a => a.Yaralanan_Uzuvlar5).IsRequired();
            builder.Property(a => a.Yaralanan_Uzuvlar6).IsRequired();
            builder.Property(a => a.Yaralanan_Uzuvlar7).IsRequired();
            builder.Property(a => a.Yaralanan_Uzuvlar8).IsRequired();
            builder.Property(a => a.Yaralanan_Uzuvlar9).IsRequired();
            builder.Property(a => a.Yaralanan_Uzuvlar10).IsRequired();
            builder.Property(a => a.Yaralanan_Uzuvlar11).IsRequired();
            builder.Property(a => a.Yaralanan_Uzuvlar12).IsRequired();

            builder.ToTable("kaza_ayrinti");

            builder.HasOne<Kaza>(k => k.Kaza).WithMany(b => b.kaza_Ayrinti).HasForeignKey(b => b.Kaza_Id).OnDelete(DeleteBehavior.NoAction);


        }
    }
}
