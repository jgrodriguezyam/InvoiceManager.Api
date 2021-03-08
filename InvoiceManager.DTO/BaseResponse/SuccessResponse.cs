namespace InvoiceManager.DTO.BaseResponse
{
    public class SuccessResponse
    {
        public SuccessResponse(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }

        public bool IsSuccess { get; set; }
    }
}
