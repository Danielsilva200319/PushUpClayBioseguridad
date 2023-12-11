using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos
{
    public class PersonContactDto : BaseEntityDto
    {
        public string Description { get; set; } = null!;

        public int IdPerson { get; set; }

        public int IdContactType { get; set; }
    }
}