using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/info")]
    public class HomeController : ControllerBase
    {
        [HttpGet("{name}")]
        public ActionResult<string> GetName(string name)
        {
            return $"Hello, {name}!";
        }

        [HttpGet("age/{yearBorn}")]
        public ActionResult<string> GetAge(int yearBorn)
        {
            int age = DateTime.Now.Year - yearBorn;
            return $"You are {age} years old!";
        }
        [HttpGet("async/{delayTime}")]
        public async Task<ActionResult<string>> GetAsync(int delayTime)
        {
            await Task.Delay(delayTime *1000);
            return $"This is an async method! - delay time: {delayTime}s";
        }

        [HttpGet("async/delay/{name}")]
        public async Task<ActionResult<string>> GetAsyncName(string name)
        {
            Random rnd = new Random();
            int number = rnd.Next(1, 10);
            await Task.Delay(TimeSpan.FromSeconds(number));
            
            return $"Hello, {name}! - delay time: {number}s";
        }   
    }
}
