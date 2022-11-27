
using System.ComponentModel.DataAnnotations;

namespace AvMonitor
{
    public class TaskModel
    {
        [Display(Name = "Айди")]
        [Required]
        public string Id { get; set; }

        [Display(Name = "Название задачи")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Url")]
        [Required]
        public string Url { get; set; }

        [Display(Name = "Выражене crontab")]
        [Required]
        public string CronExp { get; set; }

    }
}