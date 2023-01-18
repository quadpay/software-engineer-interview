namespace Zip.Installments.Infrastructure.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Zip.Installments.Domain.Entities;

    /// <summary>
    /// Class defines the configuration of installmentplan entity class.
    /// </summary>
    public class InstallmentPlanEntityConfiguration : IEntityTypeConfiguration<InstallmentPlan>
    {
        public void Configure(EntityTypeBuilder<InstallmentPlan> builder)
        {
            builder.Property(x => x.DueAmount)
                .IsRequired();

            builder.Property(x => x.DueDate)
                .IsRequired();

            //Foreign key relation
            builder.HasOne(x => x.Payment)
                .WithMany(x => x.InstallmentPlans)
                .HasForeignKey(x => x.PaymentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
