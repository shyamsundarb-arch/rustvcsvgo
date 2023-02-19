using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace cs_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Device>> GetDevices()
        {
            var devices = new List<Device>
            {
                new Device { Id = 1, Mac = "5F-33-CC-1F-43-82", Firmware = "2.1.6" },
                new Device { Id = 2, Mac = "EF-2B-C4-F5-D6-34", Firmware = "2.1.6" },
            };

            return devices;
        }

        [HttpPost]
        public ActionResult<string> CreateDevice()
        {
            int number = 40;
            int fib = Fibonacci(number);
            string location = $"/api/devices/{fib}";
            return Created(location, location);
        }

        private int Fibonacci(int n)
        {
            if (n == 1 || n == 2)
                return 1;
            if (n == 3)
                return 2;
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
    }

    public class Device
    {
        public int Id { get; set; }
        public string Mac { get; set; }
        public string Firmware { get; set; }
    }
}
