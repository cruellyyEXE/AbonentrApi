using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Model.BaseModels;

public abstract class BaseEntity
{
    [Column("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
}