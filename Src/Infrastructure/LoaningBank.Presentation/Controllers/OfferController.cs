using LoaningBank.CrossCutting.DTO;
using LoaningBank.Services.Abstract;
using Microsoft.AspNetCore.Http;
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
        public async Task<ActionResult<GetOfferResponse>> GetById(Guid offerId)
        {
            var offer = await _serviceManager.OfferService.GetById(offerId);
            return Ok(offer);
        }

        [HttpPost("{offerId}/upload")]
        public async Task<ActionResult> UploadDocument([FromForm] IFormFile file, Guid offerId)
        {
            var key = await _serviceManager.OfferService.GetDocumentKey(offerId);
            await _serviceManager.FileService.UploadFile(file.OpenReadStream(), $"{offerId}_{key}.txt");
            return Ok();
        }
    }
}
