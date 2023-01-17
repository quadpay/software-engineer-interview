namespace Zip.Installments.Infrastructure.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Zip.Installments.Domain.Entities;

    /// <summary>
    /// Class defines the configuration of payment entity class.
    /// </summary>
    public class PaymentEntityConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.Property(x => x.Amount)
                .IsRequired();
        }
    }
}
