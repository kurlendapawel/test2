using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.Domain.Entities
{
    public interface IEntity
    {
        int Id { get; set; }
    }
}
