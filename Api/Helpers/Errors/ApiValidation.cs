/* using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GardenApi.Helpers.Error
{
    public class ApiValidation : ApiResponse
    {
        public ApiValidation() : base(400)
        {

        }

        public IEnumerable<string> Errors { get; set; }
    }
} */