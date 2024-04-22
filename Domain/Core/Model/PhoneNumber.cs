using System.ComponentModel.DataAnnotations.Schema;
using Core.Model.BaseModels;

namespace Core.Model;

[Table("re_phone_numbers")]
public class PhoneNumber : BaseEntity
{
    [Column("number")]
    public required string Number { get; set; }
    
    [Column("abonent_id")]
    [ForeignKey("Abonent")]
    public long AbonentId { get; set; }
    public required Abonent Abonent { get; set; }
    
    [Column("type_id")]
    [ForeignKey("PhoneNumberType")]
    public long TypeId { get; set; }
    public required PhoneNumberType PhoneNumberType { get; set; }
}