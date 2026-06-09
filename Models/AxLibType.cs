using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxPropertyGrid.Samples.Models
{
    public class AxLibType
    {
        public bool Property1 { get; set; } = true;

        public string Property2 { get; set; } = "Library string property";

        public int Property3 { get; set; } = 11100;

        public AxInnerType InnerProperty { get; set; } = new AxInnerType();
    }

    public class AxInnerType
    {
        public double InnerDoubleProperty { get; set; } = 1222.8;

        public AxInnerType2 InnerType2 { get; set; } = new AxInnerType2();
    }

    public class AxInnerType2
    {
        public string InnerStringProperty { get; set; } = "InnerType2 string";
    }
}
