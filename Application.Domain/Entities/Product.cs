using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Application.Domain.Entities
{
    [Table("Products")]
    public class Product : IEntity
    {
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Price { get; set; }

        [Key]
        public int Id { get; set; }
    }
}
