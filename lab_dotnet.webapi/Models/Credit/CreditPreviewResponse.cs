namespace lab_dotnet.WebAPI.Models;

public class CreditPreviewResponse
{
    public Guid CreditApplicationId { get; set; }
    public bool IsActive { get; set; }
    public DateTime StartDate { get; set; }
    public string Borrower { get; set; }
}