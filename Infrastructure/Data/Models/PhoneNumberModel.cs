using Newtonsoft.Json;

namespace Data.Models;

public class PhoneNumberModel
{
    [JsonProperty("id")]
    public int? Id { get; set; }
    
    [JsonProperty("number")]
    public string? Number { get; set; }
    
    [JsonProperty("typeName")]
    public string? TypeName { get; set; }
}