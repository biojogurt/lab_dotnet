namespace lab_dotnet.entity.Models.CreditHistory;

public class Requester : BaseEntity
{
    public string Name { get; set; }
    public string Inn { get; set; }

    public virtual ICollection<Request> Requests { get; set; }
}