using LoaningBank.CrossCutting.DTO;
using LoaningBank.CrossCutting.DTO.LoaningBank;
using LoaningBank.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace LoaningBank.Presentation.Controllers
{
    [ApiController]
    [Route("api/inquiries")]
    public class InquiryController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public InquiryController(IServiceManager serviceManager) => _serviceManager = serviceManager;

        [HttpPost("add")]
        public async Task<ActionResult<CreateInquiryResponse>> Add([FromBody] CreateInquiryRequest request)
        {
            var response = await _serviceManager.InquiryService.Add(request);

            await _serviceManager.OfferService.Add(response.InquiryId);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetInquiryResponse>> GetById(string id)
        {
            var inquiry = await _serviceManager.InquiryService.GetById(id);
            return Ok(inquiry);
        }
    }
}
