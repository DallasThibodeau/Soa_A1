using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SOA_A1
{
    public class WebServiceMethod
    {
        public string MethodName { get; set; }
        public string MethodDisplayName { get; set; }

        public IList<ParameterInfo> ParameterInfo { get; set; }
    }
}
