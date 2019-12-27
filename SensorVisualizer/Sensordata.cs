using System;
using System.Collections.Generic;

namespace SensorVisualizer
{
    public partial class Sensordata
    {
        public int Id { get; set; }
        public DateTime? ResultTime { get; set; }
        public int? Sensorid { get; set; }
        public double? Temperaturevalue { get; set; }
        public double? Humidityvalue { get; set; }
    }
}
