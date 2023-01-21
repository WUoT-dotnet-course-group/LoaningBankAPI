using LoaningBank.CrossCutting.DTO;
using LoaningBank.CrossCutting.Enums;
using LoaningBank.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoaningBank.Presentation.Controllers
{
    [ApiController]
    [Authorize]
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
        public async Task<ActionResult> UploadDocument(IFormFile file, Guid offerId)
        {
            var key = await _serviceManager.OfferService.GetDocumentKey(offerId);

            await _serviceManager.FileService.UploadFile(file.OpenReadStream(), $"{offerId}_{key}.txt");

            await _serviceManager.OfferService.SetStatus(offerId, OfferStatus.Pending);

            return Ok();
        }

        [AllowAnonymous]
        [HttpGet("{offerId}/document/{key}")]
        public async Task<ActionResult> DownloadDocument(string offerId, Guid key)
        {
            var fileStream = await _serviceManager.FileService.DownloadFile($"{offerId}_{key}.txt");

            if (fileStream != Stream.Null)
            {
                return File(fileStream, "text/plain", fileDownloadName: "arrangement.txt");
            }

            return Unauthorized();
        }

        [HttpPatch("{offerId}/accept")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> AcceptOffer(Guid offerId)
        {
            await _serviceManager.OfferService.SetStatus(offerId, OfferStatus.Accepted);
            return Ok();
        }

        [HttpPatch("{offerId}/reject")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> RejectOffer(Guid offerId)
        {
            await _serviceManager.OfferService.SetStatus(offerId, OfferStatus.Declined);
            return Ok();
        }
    }
}
