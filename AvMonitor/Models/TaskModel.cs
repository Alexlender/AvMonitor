
using AvMonitor.Models;
using System.ComponentModel.DataAnnotations;

namespace AvMonitor.Models
{
    public class TaskModel
    {
        [Display(Name = "Ќазвание задачи")]
        [Required]
        public string? Name { get; set; }  //может быть неуникальным

        [Display(Name = "ѕользователь")]
        public string? UserName { get; set; }

        public string Id { get { return $"{UserName}.{Name}"; } } //всегда ункикальное (у каждого пользовател€ имена всех задач уникальны)

        [Display(Name = "Url")]
        [Required]
        public string? Path { get; set; }

        [Display(Name = "ѕериодичность выполнени€ (выражение crontab)")]
        [Required]
        public string? CronExp { get; set; }

        [Display(Name = " анал св€зи дл€ уведомлени€")]
        public string? Channel { get; set; } = "";



    }
}