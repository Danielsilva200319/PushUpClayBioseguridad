using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos
{
    public class ContractDto : BaseEntityDto
    {
        public DateOnly DateContract { get; set; }

        public DateOnly DateEnd { get; set; }

        public int IdClient { get; set; }

        public int IdEmployee { get; set; }

        public int IdState { get; set; }

    }
}