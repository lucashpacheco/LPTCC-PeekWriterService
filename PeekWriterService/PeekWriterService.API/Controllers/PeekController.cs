using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PeekWriterService.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeekController : ControllerBase
    {
       
        private readonly ILogger<PeekController> _logger;

        public PeekController(ILogger<PeekController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public void Create()
        {
            
        }
    }
}
