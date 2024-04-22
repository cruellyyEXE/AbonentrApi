using Newtonsoft.Json;

namespace Data.Models;

public class GetAbonents
{
    [JsonProperty("id")]
    public int? Id { get; set; }
    
    [JsonProperty("fullname")]
    public string? Fullname { get; set; }
    
    [JsonProperty("address")]
    public string? Address { get; set; }
    
    [JsonProperty("phoneNumbers")]
    public IEnumerable<PhoneNumberModel>? PhoneNumbers { get; set; }
}