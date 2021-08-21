using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CbbItem
    {
        public string _Text { get; set; }
        public int _Value { get; set; }
        public override string ToString()
        {
            return _Text;

        }
    }
}
