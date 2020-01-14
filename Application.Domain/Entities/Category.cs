using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Domain.Entities
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        public decimal Value { get; set; }
    }
}
