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

            var offerId = await _serviceManager.OfferService.Add(response.InquiryId, request);

            await _serviceManager.OfferService.GenerateDocument(offerId);

            return Ok(response);
        }

        [HttpGet("{inquiryId}")]
        public async Task<ActionResult<GetInquiryResponse>> GetById(string inquiryId)
        {
            var inquiry = await _serviceManager.InquiryService.GetById(inquiryId);
            return Ok(inquiry);
        }

        [HttpGet]
        public async Task<ActionResult<PaginatedResponse<GetInquiryDetailsResponse>>> Get([FromQuery] PagingParameter pagingParams)
        {
            var inquiries = await _serviceManager.InquiryService.Get(pagingParams);
            return Ok(inquiries);
        }
    }
}
