using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos
{
    public class ProgramingDto : BaseEntityDto
    {
        public int IdContract { get; set; }

        public int IdShifts { get; set; }

        public int IdEmployee { get; set; }
    }
}