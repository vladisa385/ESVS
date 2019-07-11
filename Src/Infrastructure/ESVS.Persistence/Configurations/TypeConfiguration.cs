using Type = ESVS.Domain.Entities.Type;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ESVS.Persistence.Configurations
{
    public class TypeConfiguration: IEntityTypeConfiguration<Type>
    {
        public void Configure(EntityTypeBuilder<Type> builder)
        {
             builder.HasKey(e => e.Id);
             builder.Property(e=>e.Name).IsRequired();
        }
    }
}
