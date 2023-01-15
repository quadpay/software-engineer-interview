namespace Zip.Installements.Infrastructure.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Zip.Installements.Domain.Entities;

    public class InstallementPlanEntityConfiguration : IEntityTypeConfiguration<InstallementPlan>
    {
        public void Configure(EntityTypeBuilder<InstallementPlan> builder)
        {
            builder.Property(x => x.DueAmount)
                .IsRequired();

            builder.Property(x => x.DueDate)
                .IsRequired();

            //Foreign key relation
            builder.HasOne(x => x.Payment)
                .WithMany(x => x.InstallementPlans)
                .HasForeignKey(x => x.PaymentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
