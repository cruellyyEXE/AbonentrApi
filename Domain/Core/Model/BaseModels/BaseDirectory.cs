using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Model.BaseModels;

public abstract class BaseDirectory : BaseEntity
{
    [Column("name")]
    public required string Name { get; set; }
}