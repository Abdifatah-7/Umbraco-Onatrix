using System.ComponentModel.DataAnnotations;

namespace UmbracoProject1.ViewModels
{
    public class QuestionFormViewModel
    {
        [MaxLength(50)]
        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "Name")]
        public string Name { get; set; } = null!;

        [MaxLength(150)]
        [Required(ErrorMessage = "Email is required")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Email is required>")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Please submit a question")]
        [Display(Name = "Question")]
        public string Question { get; set; } = null!;
    }
}
