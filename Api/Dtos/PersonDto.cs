using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos
{
    public class PersonDto : BaseEntityDto
    {
        public int IdPerson { get; set; }

        public string Name { get; set; } = null!;

        public DateOnly DateReg { get; set; }

        public int IdPersonType { get; set; }

        public int IdCategory { get; set; }

        public int IdCity { get; set; }

    }
}