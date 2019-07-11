using System;
using System.Collections.Generic;
using System.Text;
using ESVS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ESVS.Persistence.Configurations
{
    public class FieldValueConfiguration:IEntityTypeConfiguration<FieldValue>
    {
        public void Configure(EntityTypeBuilder<FieldValue> builder) => 
            builder.HasKey(o => new { o.FieldId, o.Date });
    }
}
