﻿namespace LoaningBank.CrossCutting.DTO
{
    public class AddInquiryDTO
    {
        public int LoanValue { get; set; }
        public short NumberOfInstallments { get; set; }
        public PersonalDataDTO PersonalData { get; set; } = default!;
    }
}