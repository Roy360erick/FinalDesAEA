using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Proxy
{
    public class ResponseProxy<TEntity> : ICloneable where TEntity : class, new()
    {
        public bool Success { get; set; }
        public int Code { get; set; }
        public string Message { get; set; }
        public IEnumerable<TEntity> List { get; set; }
        public TEntity Object { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}