using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.OData.Models
{
    public class OrderApiModel
    {
        [Key]
        public Guid Uid { get; set; }

        public string Title { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
