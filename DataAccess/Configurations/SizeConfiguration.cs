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
    public class SizeConfiguration : IEntityTypeConfiguration<Size>
    {
        public void Configure(EntityTypeBuilder<Size> builder)
        {
            builder.Property(x => x.Value).IsRequired().HasMaxLength(5);
            builder.HasIndex(x => x.Value).IsUnique();

            builder.HasMany(x=> x.SizeProducts).WithOne(x=>x.Size).HasForeignKey(x=>x.SizeId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
