using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JoinedEntityTableTask.Models.DataModels;

public class Product
{
    [Key]
    public int ProductId { get; set; }
    [Required(ErrorMessage = "You must put Product Name")]
    public required string Name { get; set; }
    public DateTime CreateDate { get; set; } = DateTime.Now;

    [ForeignKey(nameof(Category))]
    public int CategoryId {  get; set; }
}
