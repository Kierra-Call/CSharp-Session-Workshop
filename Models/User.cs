#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;


namespace SessionWorkshop.Models;

public class User
{
    [Required(ErrorMessage = "This field is required")]
    [Display(Name = "Please give your name:")]
    public string Name { get; set; }
}