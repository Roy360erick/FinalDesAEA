using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.HttpHelpers
{
    public class EResponseBase<T>
    {
        public int Code { get; set; }

        public bool IsSuccess { get; set; }

        public string Message { get; set; }

        public IEnumerable<T> List { get; set; }

        public T Object { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
        public override string ToString()
        {
            return $"{Code} {Message} {List} {Object}";
        }
    }
    
}
