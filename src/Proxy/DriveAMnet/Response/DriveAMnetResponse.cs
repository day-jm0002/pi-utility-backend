using System;
using System.Collections.Generic;
using System.Text;

namespace Proxy.DriveAMnet.Response
{
    public class DriveAMnetResponse
    {
        public MetaData metadata { get; set; }
        public List<Data> data { get; set; }
    }
}
