using System.Text.Json.Serialization;

namespace lab_dotnet.entity.Models.CreditHistory;

public class Creditor : BaseEntity
{
    public string Name { get; set; }
    public string Inn { get; set; }

    [JsonIgnore]
    public virtual ICollection<CreditApplication>? CreditApplications { get; set; }
}