using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JoinedEntityTableTask.Models.DataModels;

public class Category
{
    [Key]
    public int CategoryId { get; set; }
    [Required(ErrorMessage ="You must put Category Name")]
    public required string CategoryName { get; set; }
}
