using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginReg.Models
{
    public class Category
    {
    [Key]
    public int CategoryId {get;set;}
    [Required(ErrorMessage = "Category Name is required")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Category name should be atleast 2 characters!")]
    [Display(Name = "Category Name")]
    public string CategoryName {get;set;}
    public int CreatorId {get;set;}

    //nav properties go here
    public List<Card> CategoryCards {get;set;}

    }
}