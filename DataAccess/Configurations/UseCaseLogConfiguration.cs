using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFDataAccess.Configurations
{
    class UseCaseLogConfiguration : IEntityTypeConfiguration<UseCaseLog>
    {
        public void Configure(EntityTypeBuilder<UseCaseLog> builder)
        {
            builder.Property(x => x.Date).IsRequired();
            builder.Property(x => x.Actor).IsRequired();
            builder.Property(x => x.UseCaseName).IsRequired();
            builder.Property(x => x.Data).IsRequired();
        }
    }
}
