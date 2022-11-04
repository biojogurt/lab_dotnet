using System.Text.Json.Serialization;
using lab_dotnet.entity.ValidationAttributes;

namespace lab_dotnet.entity.Models.CreditHistory;

public class Payment : BaseEntity
{
    public Guid CreditId { get; set; }
    public DateTime PaymentDate { get; set; }
    public int PaymentAmount { get; set; }
    public int RemainingAmount { get; set; }
    [LessThanOrEqual("RemainingAmount")]
    public int Debt { get; set; }

    [JsonIgnore]
    public virtual Credit? Credit { get; set; }
}