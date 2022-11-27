using LoaningBank.CrossCutting.DTO;
using LoaningBank.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace LoaningBank.Presentation.Controllers
{
    [ApiController]
    [Route("api/offers")]
    public class OfferController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public OfferController(IServiceManager serviceManager) => _serviceManager = serviceManager;

        [HttpPost("add")]
        public async Task<ActionResult> Add([FromBody] AddOfferDTO offer)
        {
            await _serviceManager.OfferService.Add(offer);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<GetOfferDTO>> GetAll()
        {
            var offers = await _serviceManager.OfferService.GetAll();
            return Ok(offers);
        }

    }
}
