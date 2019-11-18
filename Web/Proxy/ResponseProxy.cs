using System;
using System.Collections.Generic;

namespace Web.Proxy
{
    public class ResponseProxy<TEntity> : ICloneable where TEntity : class, new()
    {
        public int Code { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public IEnumerable<TEntity> List { get; set; }
        public TEntity Object { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}