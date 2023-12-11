using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos
{
    public class CountryDto : BaseEntityDto
    {
        public string Name { get; set; } = null!;
    }
}