using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ecomm.DataModel.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ProductId { get; set; }

        [ForeignKey("ProductCategory")]
        public long? ProductCategoryId { get; set; }
        public ProductCategory ProductCategory { get; set; }

        public string ProductName { get; set; }
        public string Description { get; set; }

        public ICollection<ProductAttribute> Attributes { get; set; }
    }
}
