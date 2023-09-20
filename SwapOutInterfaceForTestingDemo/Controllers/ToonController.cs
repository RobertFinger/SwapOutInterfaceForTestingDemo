using Microsoft.AspNetCore.Mvc;
using SwapOutInterfaceForTestingDemo.Interfaces;
using SwapOutInterfaceForTestingDemo.Models;
using System.Net;

namespace SwapOutInterfaceForTestingDemo.Controllers
{ 
    [ApiController]
    [Route("[controller]")]
    public class ToonController : ControllerBase
    {
        private readonly ToonCreator _creator;

        public ToonController(ToonCreator creator)
        {
            _creator = creator;
        }

        [HttpGet(Name = "GetToons")]
        public IEnumerable<IToon> Get()
        {
            var returnVar = _creator.GenerateNewToons(10);

            return returnVar;
        }

    }

}



