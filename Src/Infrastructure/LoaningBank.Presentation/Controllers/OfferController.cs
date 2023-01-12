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

        [HttpGet("{offerId}")]
        public async Task<ActionResult<GetOfferResponse>> GetById(string offerId)
        {
            var offer = await _serviceManager.OfferService.GetById(offerId);
            return Ok(offer);
        }
    }
}
