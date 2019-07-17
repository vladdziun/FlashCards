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
    [Required]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Back should be atleast 3 characters!")]
    public string CategoryName {get;set;}
    public int CreatorId {get;set;}

    //nav properties go here
    public List<Card> CategoryCards {get;set;}

    }
}