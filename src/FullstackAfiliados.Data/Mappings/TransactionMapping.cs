using FullstackAfiliados.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FullstackAfiliados.Data.Mappings;

public class TransactionMapping : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.ProcessedAt)
            .IsRequired();

        builder.Property(t => t.Product)
            .IsRequired()
            .HasColumnType("varchar(200)");

        builder.Property(t => t.Seller)
            .IsRequired()
            .HasColumnType("varchar(200)");
        
        builder.ToTable(nameof(Transaction));
    }
}