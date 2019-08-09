using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginReg.Models
{
    public class Card
    {
    [Key]
    public int CardId {get;set;}
    [Required(ErrorMessage = "Front Card Text is required")]
    [StringLength(200, MinimumLength = 3, ErrorMessage = "Back should be atleast 3 characters!")]
    [Display(Name = "Front Card Text")]
    public string FrontText {get;set;}
    [Required(ErrorMessage = "Back Card Text is required")]
    [StringLength(1000, MinimumLength = 3, ErrorMessage = "Front should be atleast 3 characters!")]
    [Display(Name = "Back Card Text")]
    public string BackText {get;set;}
    [Display(Name = "Learned")]
    public bool isLearned {get;set;}

    public int UserId {get;set;}
    [Required(ErrorMessage = "Category is required")]
    [Display(Name = "Category")]
    public int CategoryId {get;set;}
    //nav properties go here
    public User Creator {get;set;}
    public Category Category {get;set;}
    }
}