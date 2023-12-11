using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos
{
    public class PersonTypeDto : BaseEntityDto
    {
        public string Description { get; set; } = null!;
    }
}