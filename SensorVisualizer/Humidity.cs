using System;
using System.Collections.Generic;

namespace SensorVisualizer
{
    public partial class Humidity
    {
        public int Id { get; set; }
        public DateTime? ResultTime { get; set; }
        public int? Sensorid { get; set; }
        public double? Value { get; set; }
    }
}
