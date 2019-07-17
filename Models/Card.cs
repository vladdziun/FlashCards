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
    [Required]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Back should be atleast 3 characters!")]
    public string FrontText {get;set;}
    [Required]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Front should be atleast 3 characters!")]
    public string BackText {get;set;}

    //nav properties go here
    public User Creator {get;set;}
    public Category Category {get;set;}


    public int UserId {get;set;}
    public int CategoryId {get;set;}

    }
}