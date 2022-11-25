namespace lab_dotnet.WebAPI.Models;

public class PaymentPreviewResponse : BaseResponse
{
    public DateTime PaymentDate { get; set; }
    public int PaymentAmount { get; set; }
    public string Borrower { get; set; }
}