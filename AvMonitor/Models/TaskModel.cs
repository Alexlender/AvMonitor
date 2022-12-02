
using AvMonitor.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AvMonitor.Models
{
    [Keyless]
    public class TaskModel
    {
        [Display(Name = "Имя ресурса")]
        [Required]
        public string? Name { get; set; } 
        public string? UserName { get; set; } 

        public string Id { get { return $"{UserName}.{Name}"; } } //всегда ункикальное (у каждого пользователя имена всех задач уникальны)

        [Display(Name = "Url")]
        [Required]
        public string? Path { get; set; }

        [Display(Name = "Периодичность выполнения (выражение crontab)")]
        [Required]
        public string? CronExp { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; } = "";

    }
}