using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos
{
    public class StateDto : BaseEntityDto
    {
        public string Description { get; set; } = null!;
    }
}