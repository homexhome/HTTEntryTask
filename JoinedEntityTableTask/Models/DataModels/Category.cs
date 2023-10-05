using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace JoinedEntityTableTask.Models.DataModels;

public class Category
{
    [Key]
    public int CategoryId { get; set; }
    [Required(ErrorMessage ="You must put Category Name")]
    public required string CategoryName { get; set; }

    public List<Product>? Products { get; set; } 
}
