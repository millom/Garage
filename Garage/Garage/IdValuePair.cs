using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Garage.Garage
{
    internal class IdValuePair<T> where T : class
    {
        //[JsonConstructor]
        //public IdValuePair() /*: this(0, null!)*/ {}
        [JsonPropertyOrder(1)]
        public int Id { get; set; }

        [JsonPropertyOrder(2)]
        public T Value { get; set; } = default!;

        //public IdValuePair(int id, T value)
        //{
        //    Id = id;
        //    Value = value;
        //}
    }
}
