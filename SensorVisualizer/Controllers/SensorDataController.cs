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
            sensorviewdatalist.Add(new Data.sensorviewdata()
            {
                date = DateTime.Today,
                value = "2"
            });
            return JsonConvert.SerializeObject(sensorviewdatalist);
        }
    }
}