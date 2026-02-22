using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automatic
{
    public class ResultAPI
    {
        public int status { get; set; }
        public int totalPage { get; set; }
        public string data { get; set; }
        public string message { get; set; }
    }
}
