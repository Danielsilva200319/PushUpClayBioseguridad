using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos
{ 
    public class PersonAddressDto : BaseEntityDto
    {
        public string Address { get; set; } = null!;

        public int IdPerson { get; set; }

        public int IdAddressType { get; set; }
    }
}