using FullstackAfiliados.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FullstackAfiliados.Data.Mappings;

public class TransactionTypeMapping : IEntityTypeConfiguration<TransactionType>
{
    public void Configure(EntityTypeBuilder<TransactionType> builder)
    {
        builder.HasKey(tt => tt.Id);

        builder.Property(tt => tt.Description)
            .IsRequired()
            .HasColumnType("varchar(200)");
        
        builder.Property(tt => tt.Nature)
            .IsRequired()
            .HasColumnType("varchar(50)");
        
        builder.Property(tt => tt.Sinal)
            .IsRequired();

        builder.HasMany(tt => tt.Transactions)
            .WithOne(t => t.TransactionType)
            .HasForeignKey(t => t.TransactionTypeId);
        
        builder.ToTable(nameof(TransactionType));
    }
}