using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Garage.Garage
{
    internal class IdValuePair<T>(int id, T value) where T: class
    {
        [JsonConstructor]
        public IdValuePair() : this(0, null!) {}

        [JsonPropertyOrder(1)]
        public int Id { get; } = id;

        [JsonPropertyOrder(2)]
        public T Value { get; } = value;
    }
}
