using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automatic
{
    public class Product
    {
        public string ModelName { get; set; }
        public string Route { get; set; }
        public string Station { get; set; }
        public string Sn { get; set; }
        public string Result { get; set; }
        public string ErrorCode { get; set; }
        public double TotalTime { get; set; }
        public List<TimeTest> FunctionTime { get; set; }
        public List<DataTest> TestData { get; set; }
    }
    public class TimeTest
    {
        public string Name { get; set; }
        public double? TestTime { get; set; }
    }
    public class DataTest
    {
        public string ItemName { get; set; }
        public double? ItemValue { get; set; }
    }
    public class DataTest1
    {
        public string ItemName { get; set; }
        public int? ItemValue { get; set; }
    }
}
