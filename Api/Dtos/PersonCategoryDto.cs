using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos
{
    public class PersonCategoryDto : BaseEntityDto 
    {
        public string NameCategory { get; set; } = null!;
    }
}