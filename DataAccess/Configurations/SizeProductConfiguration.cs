using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    public class SizeProductConfiguration : IEntityTypeConfiguration<SizeProduct>
    {
        public void Configure(EntityTypeBuilder<SizeProduct> builder)
        {
            builder.Property(x => x.Quantity).IsRequired();

            builder.HasMany(x => x.OrderLines)
             .WithOne(x => x.SizeProducts)
             .HasForeignKey(x => new { x.SizeId, x.ProductId })
             .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
