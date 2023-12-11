using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos
{
    public class DepartmentDto : BaseEntityDto
    {
        public string Name { get; set; } = null!;

        public int IdCountry { get; set; }
    }
}