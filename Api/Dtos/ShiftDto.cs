using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos
{
    public class ShiftDto : BaseEntityDto
    {
        public string ShiftName { get; set; } = null!;

        public TimeOnly TimeShiftStart { get; set; }

        public TimeOnly TimeShiftEnd { get; set; }
    }
}