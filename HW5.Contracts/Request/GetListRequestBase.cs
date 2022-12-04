namespace HW5.Contracts.Request
{
    public abstract class GetListRequestBase
    {
        public int PageCount { get; set; }
        public int PageSize { get; set; }
    }
}
