using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Common
{
    public class ValidateRangeProvider : IValidateRangeProvider
    {
        public void ValidateRange(int? value, int min, int max, string message)
        {
            RangeValidator.ValidateRange(value, min, max, message);
        } 
    }
}
