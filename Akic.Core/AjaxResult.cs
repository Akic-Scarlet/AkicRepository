using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akic.Core
{
    public enum ResultType
    { 
        info,
        success,
        warn,
        error
    }
    public class AjaxResult
    {
        public object state { get; set; }
        public string message { get; set; }
        public object data { get; set; }
    }
}
