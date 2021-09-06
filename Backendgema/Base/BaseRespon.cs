using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backendgema.Base
{
    public class BaseRespon<T>
    {
        public bool status { get; set; }
        public List<String> message { get; set; }
        public T payload { get; set; }
    }
}
