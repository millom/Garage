using Garage.Exceptions;
using Garage.Types;

using System.Text.Json.Serialization;
namespace Garage.Vehicles
{
    [JsonDerivedType(typeof(Boat), typeDiscriminator: "Boat")]
    internal class Boat(
        string regNumber,
        ColorType color,
        int length) : Vehicle(
              regNumber,
              color,
              weels: 0,
              weelsMin: 0,
              weelsMax: 0),
        IVehicle, IBoat
    {
        [JsonPropertyOrder(3)]
        public override int Weels
        {
            get => _weels;
            set
            {
                Throw<ArgumentException>.If(value != 0, "Weels must be zero0");

                _weels = value;
            }
        }

        [JsonPropertyOrder(4)]
        public int Length { get; set; } = length > 0
            ? length
            : throw new ArgumentOutOfRangeException(
                $"Argument length={length} (must be > 0)"
              );

        public Boat()
            : this("abc123", ColorType.BLUE, length: 12) {}

        public override string ToString()
        {
            return $"{base.ToString()}, Length:{Length}";
        }
    }
}
