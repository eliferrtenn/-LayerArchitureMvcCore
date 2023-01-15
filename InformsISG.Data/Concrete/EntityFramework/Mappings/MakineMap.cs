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
    public class MakineMap : IEntityTypeConfiguration<Makine>
    {
        public void Configure(EntityTypeBuilder<Makine> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Makine_Ad).HasMaxLength(100).IsRequired();
 
            builder.ToTable("makine");


        }
    }
}
