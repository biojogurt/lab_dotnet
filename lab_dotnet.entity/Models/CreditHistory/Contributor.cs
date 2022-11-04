using System.Text.Json.Serialization;

namespace lab_dotnet.entity.Models.CreditHistory;

public class Contributor : BaseEntity
{
    public string Name { get; set; }
    public string Inn { get; set; }

    [JsonIgnore]
    public virtual ICollection<Contribution>? Contributions { get; set; }
}