
using AvMonitor.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AvMonitor.Models
{

    public class TaskModel
    {
        [Display(Name = "Имя задачи")]
        [Required]
        public string? Name { get; set; } 
        public string? UserName { get; set; }

        [Key]
        public int Index { get; set; }

        public string Id { get { return $"{UserName}.{Name}"; } } //всегда ункикальное (у каждого пользователя имена всех задач уникальны)

        [Display(Name = "Ссылка на задачу")]
        [Required]
        public string? Path { get; set; }

        [Display(Name = "Расписание в формате CRON")]
        [Required]
        public string? CronExp { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; } = "";

    }
}