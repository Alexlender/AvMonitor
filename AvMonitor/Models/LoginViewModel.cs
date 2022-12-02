using System.ComponentModel.DataAnnotations;

namespace AvMonitor.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Логин")]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "Не логин (пароль)")]
        public string Password { get; set; }    
    }
}
