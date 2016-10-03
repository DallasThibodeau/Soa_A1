using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SOA_A1
{
    public class WebServiceInfo
    {
        public string WebServiceName { get; set; }
        public string WebServicePostUrl { get; set; }
        public string WebServiceBaseUrl { get; set; }
        public bool UseTns { get; set; }


        public IList<WebServiceMethod> WebServiceMethods { get; set; }
    }
}
