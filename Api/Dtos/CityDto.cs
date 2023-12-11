using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos
{
    public class CityDto : BaseEntityDto
    {
        public string Name { get; set; } = null!;

        public int IdDepartment { get; set; }
    }
}