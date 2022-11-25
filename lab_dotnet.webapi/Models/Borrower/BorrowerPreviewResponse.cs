namespace lab_dotnet.WebAPI.Models;

public class BorrowerPreviewResponse : BaseResponse
{
    public string FullName { get; set; }
    public int PassportSerial { get; set; }
    public int PassportNumber { get; set; }
}