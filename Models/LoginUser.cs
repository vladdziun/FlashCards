using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class LoginUser
{
    [Required]
     [Display(Name = "Email")] 
    public string LoginEmail {get; set;}
    [DataType(DataType.Password)]
    [Required]
     [Display(Name = "Password")] 
    public string LoginPassword { get; set; }
}