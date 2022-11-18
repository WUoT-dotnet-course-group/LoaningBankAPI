using LoaningBank.CrossCutting.DTO;
﻿namespace LoaningBank.Services.Abstract
{
    public interface IInquiryService
    {
        Task<IEnumerable<Guid>> GetAllIds();
        Task Add(AddInquiryDTO inquiry);
    }
}
