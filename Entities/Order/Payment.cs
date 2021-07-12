using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Payment : BaseEntity
    {
        public Payment()
        {

        }

        public bool Result { get; set; }
        public DateTime PaymentDate { get; set; }

        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
    }

    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.Property(p => p.Result).IsRequired();
            builder.Property(p => p.PaymentDate).IsRequired();

            builder.HasOne(p => p.Order).WithOne(c => c.Payment).HasForeignKey<Payment>(p => p.OrderId);
        }
    }
}
