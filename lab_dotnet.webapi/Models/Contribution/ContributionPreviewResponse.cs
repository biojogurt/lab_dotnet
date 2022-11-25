namespace lab_dotnet.WebAPI.Models;

public class ContributionPreviewResponse : BaseResponse
{
    public DateTime ContributionDate { get; set; }
    public string Contributor { get; set; }
    public string Borrower { get; set; }
}