using System.ComponentModel.DataAnnotations;

namespace studentregistry.Models;

public class Student
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Το ονοματεπώνυμο είναι υποχρεωτικό.")]
    [StringLength(80, MinimumLength = 2, ErrorMessage = "Το ονοματεπώνυμο πρέπει να έχει 2 έως 80 χαρακτήρες.")]
    [Display(Name = "Ονοματεπώνυμο")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Η ηλικία είναι υποχρεωτική.")]
    [Range(16, 99, ErrorMessage = "Η ηλικία πρέπει να είναι από 16 έως 99.")]
    [Display(Name = "Ηλικία")]
    public int? Age { get; set; }

    [Required(ErrorMessage = "Το email είναι υποχρεωτικό.")]
    [EmailAddress(ErrorMessage = "Δώστε ένα έγκυρο email.")]
    [Display(Name = "Email")]
    public string Email { get; set; } = string.Empty;
}
