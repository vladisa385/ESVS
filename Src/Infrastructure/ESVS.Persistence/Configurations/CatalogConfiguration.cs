using System;
using System.Collections.Generic;
using System.Text;
using ESVS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ESVS.Persistence.Configurations
{
    public class CatalogConfiguration: IEntityTypeConfiguration<Catalog>
    {
        public void Configure(EntityTypeBuilder<Catalog> builder)
        {
             builder.HasKey(e => e.Id);
             builder.HasQueryFilter(p => !p.IsDeleted);
        }
    }
}
