using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ecomm.DataModel.Models
{
    public class ProductAttributeLookup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long AttributeId { get; set; }

        [ForeignKey("ProductCategory")]
        public long? ProductCategoryId { get; set; }
        public ProductCategory ProductCategory { get; set; }

        public string AttributeName { get; set; }
    }
}
