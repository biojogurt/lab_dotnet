namespace lab_dotnet.WebAPI.Models;

public class RequestPreviewResponse : BaseResponse
{
    public DateTime RequestDate { get; set; }
    public string Requester { get; set; }
    public string Borrower { get; set; }
}