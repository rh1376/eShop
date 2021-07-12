using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Order : BaseEntity
    {
        public Order()
        {

        }

        public DateTime OrderDate { get; set; }


        public OrderDetails OrderDetails { get; set; }
        public Payment Payment { get; set; }

        public virtual ICollection<OrderProduct> OrderProduct { get; set; }
        public virtual ICollection<CustomerOrder> CustomerOrder { get; set; }
    }

    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(p => p.OrderDate).IsRequired();


        }
    }
}
