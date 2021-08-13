using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.OData.Entities
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public Guid Uid { get; set; }

        public string Title { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
