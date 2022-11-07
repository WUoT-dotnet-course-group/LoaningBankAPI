using Microsoft.AspNetCore.Mvc;

namespace LoaningBank.Presentation.Controllers
{
    [ApiController]
    [Route("api/test")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public List<int> GetTestData()
        {
            return new List<int> { 1, 2, 3 };
        }
    }
}
