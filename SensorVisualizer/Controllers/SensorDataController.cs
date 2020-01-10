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
        public object Get()
        {
            List<Data.sensorviewdata> sensorviewdatalist = new List<Data.sensorviewdata>();

            sensordbContext sensordb = new sensordbContext();
            var lastday = sensordb.Sensordata.Where(i => i.ResultTime > DateTime.Now.AddDays(-14) && i.ResultTime < DateTime.Now.AddDays(-6)).ToList();

            foreach (var item in lastday)
            {
                sensorviewdatalist.Add(new Data.sensorviewdata()
                {
                    date = item.ResultTime.ToString("yyyy-M-dd/H:m:s"),
                    value = item.Temperaturevalue.ToString().Replace(',','.')
                    //value = item.Humidityvalue.ToString().Replace(',', '.')
                });
            }

            
            //sensorviewdatalist.Add(new Data.sensorviewdata()
            //{
            //    date = DateTime.Today.ToShortDateString(),
            //    value = "2"
            //});
            //sensorviewdatalist.Add(new Data.sensorviewdata()
            //{
            //    date = DateTime.Today.AddDays(1).ToShortDateString(),
            //    value = "5"
            //});
            return JsonConvert.SerializeObject(sensorviewdatalist);
        }
    }
}