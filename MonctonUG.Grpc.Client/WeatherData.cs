using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonctonUG.Grpc.Server
{
    public partial class WeatherData
    {
        public void Deconstruct(out Timestamp timestamp, out int temperature, out string summary) =>
        (timestamp, temperature, summary) = (this.DateTimeStamp, this.TemperatureC, this.Summary);
    }
}
