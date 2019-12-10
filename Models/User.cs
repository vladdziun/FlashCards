using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace LoginReg.Models
{
    public class User
    {
    [Key]
    public int UserId {get;set;}
    [Required(ErrorMessage = "Name is required")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Name should be atleast 3 characters!")]
    public string Name {get;set;}
    [EmailAddress]
    [Required(ErrorMessage = "Email is required")]
    public string Email {get;set;}
    [Required(ErrorMessage = "Password is required")]
    [DataType(DataType.Password)]
    [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$", ErrorMessage = "Password must contain atleast 1 uppercase, 1 lowercase and 1 number!")]
    [StringLength(255, MinimumLength = 8, ErrorMessage = "Password should be atleast 8 characters long!")]
    public string Password {get;set;}
    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;
    [NotMapped]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match")]
    [DataType(DataType.Password)]
    [Display(Name = "Password Confirm")]
    public string Confirm {get;set;}

    //nav properties go here
    public List<Card> UserCards {get;set;}
    public List<Category> UserCategories {get;set;}
    }
}