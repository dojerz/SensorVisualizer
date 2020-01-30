using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace SensorVisualizer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensorDataController : ControllerBase
    {
        [HttpGet("{datatype}/{sensorid}/{days}")]
        public object Get(string datatype, string sensorid, string days)
        {
            List<Data.sensorviewdata> sensorviewdatalist = new List<Data.sensorviewdata>();

            sensordbContext sensordb = new sensordbContext();
            //var lastday = sensordb.Sensordata.Where(i => i.ResultTime > DateTime.Now.AddDays(-14) && i.ResultTime < DateTime.Now.AddDays(-6)).ToList();
            var lastday = sensordb.Sensordata.Where(i => i.ResultTime > DateTime.Now.AddDays(-4)).ToList();

            if (datatype == "temp")
            {
                foreach (var item in lastday)
                {
                    sensorviewdatalist.Add(new Data.sensorviewdata()
                    {
                        date = item.ResultTime.ToString("yyyy-M-dd/H:m:s"),
                        value = item.Temperaturevalue.ToString().Replace(',', '.')
                    });
                }
            }
            else if (datatype == "hum")
            {
                foreach (var item in lastday)
                {
                    sensorviewdatalist.Add(new Data.sensorviewdata()
                    {
                        date = item.ResultTime.ToString("yyyy-M-dd/H:m:s"),
                        value = item.Humidityvalue.ToString().Replace(',', '.')
                    });
                }
            }
            return JsonConvert.SerializeObject(sensorviewdatalist);
        }
    }
}