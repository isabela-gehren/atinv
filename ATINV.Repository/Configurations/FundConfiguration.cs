using ATINV.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ATINV.Repository
{
    class FundConfiguration : IEntityTypeConfiguration<Fund>
    {
        public void Configure(EntityTypeBuilder<Fund> builder)
        {
            builder.ToTable("Fund");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasDefaultValueSql("newid()");
            //.ValueGeneratedOnAdd();//.HasValueGenerator(typeof(Guid));
            builder.Property(x => x.Cnpj).IsRequired().HasMaxLength(14);
            builder.Property(x => x.MinInicialContribution).HasColumnType("decimal(10,2)").IsRequired();
            builder.Property(x => x.Name).IsRequired();
        }
    }
}
