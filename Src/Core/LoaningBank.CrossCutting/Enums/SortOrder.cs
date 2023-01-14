using System.ComponentModel;

namespace LoaningBank.CrossCutting.Enums
{
    public enum SortOrder
    {
        [Description("desc")]
        Descending = -1,

        [Description("")]
        Undefined = 0,

        [Description("asc")]
        Ascending = 1,
    }
}
