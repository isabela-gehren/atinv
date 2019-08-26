using ATINV.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace ATINV.Repository
{
    class MovimentConfiguration : IEntityTypeConfiguration<Moviment>
    {
        public void Configure(EntityTypeBuilder<Moviment> builder)
        {
            builder.ToTable("Moviment");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasDefaultValueSql("newid()");
            builder.Property(x => x.Cpf).IsRequired().HasMaxLength(11);
            builder.Property(x => x.Date).IsRequired();
            builder.Property(x => x.Amount).HasColumnType("decimal(10,2)").IsRequired();
            builder.Property(x => x.MovimentType).IsRequired();
            builder.HasOne(x => x.Fund)
                .WithMany(x => x.Moviments)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.FundId).IsRequired();
        }
    }
}
