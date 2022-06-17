namespace Mabill.Domain.Base
{
    public class BaseResponse<T>
    {
        public T Date { get; set; }
        public BaseError Error { get; set; }
    }
}
