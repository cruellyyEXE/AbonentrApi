using System.ComponentModel.DataAnnotations.Schema;
using Core.Model.BaseModels;

namespace Core.Model;

[Table("re_addresses")]
public class Address : BaseEntity
{
    [Column("country")]
    public required string Country { get; set; }
    
    [Column("town")]
    public required string Town { get; set; }
    
    [Column("street")]
    public required string Street { get; set; } 
    
    [Column("house")]
    public required string House { get; set; }
    
    [Column("abonent_id")]
    [ForeignKey("Abonent")]
    public long AbonentId { get; set; }
    public required Abonent Abonent { get; set; }
}