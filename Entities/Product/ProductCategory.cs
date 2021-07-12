using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ProductCategory : BaseEntity
    {
        public ProductCategory()
        {

        }

        public int ProductId { get; set; }
        public int CategoryId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Category Category { get; set; }
    }

    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasOne(p => p.Product).WithMany(c => c.ProductCategory).HasForeignKey(p => p.ProductId);
            builder.HasOne(p => p.Category).WithMany(c => c.ProductCategory).HasForeignKey(p => p.CategoryId);
        }
    }
}
