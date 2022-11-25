namespace lab_dotnet.WebAPI.Models;

public class CreditApplicationPreviewResponse : BaseResponse
{
    public DateTime ApplicationDate { get; set; }
    public int CreditAmount { get; set; }
    public string Borrower { get; set; }
}