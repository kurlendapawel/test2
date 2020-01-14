using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Domain.Entities
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
