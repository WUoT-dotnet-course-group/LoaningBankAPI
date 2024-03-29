﻿using LoaningBank.CrossCutting.DTO;
using LoaningBank.CrossCutting.DTO.LoaningBank;

namespace LoaningBank.Services.Abstract
{
    public interface IInquiryService
    {
        Task<CreateInquiryResponse> Add(CreateInquiryRequest request);
        Task<GetInquiryResponse> GetById(string inquiryId);
        Task<PaginatedResponse<GetInquiryDetailsResponse>> Get(PagingParameter pagingParams);
    }
}
