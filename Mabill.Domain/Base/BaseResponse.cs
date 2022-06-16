using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mabill.Domain.Base
{
    public class BaseResponse<T>
    {
        public T Date { get; set; }
        public BaseError Error { get; set; }
    }
}
