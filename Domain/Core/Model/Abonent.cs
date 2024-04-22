using System.ComponentModel.DataAnnotations.Schema;
using Core.Model.BaseModels;

namespace Core.Model;

[Table("re_abonents")]
public class Abonent : BaseEntity
{
    [Column("first_name")]
    public required string FirstName { get; set; }
    
    [Column("last_name")]
    public required string LastName { get; set; }
    
    [Column("patronymic")]
    public required string Patronymic { get; set; }
}