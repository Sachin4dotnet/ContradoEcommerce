using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ecomm.DataModel.Models
{
    public class ProductAttribute
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ProductAttributeId { get; set; }

        [ForeignKey("ProductAttributeLookup")]
        public long? AttributeId { get; set; }
        public ProductAttributeLookup ProductAttributeLookup { get; set; }

        [ForeignKey("Products")]
        public long? ProductId { get; set; }
        public Product Product { get; set; }

        public string AttributeValue { get; set; }
    }
}
