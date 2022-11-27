
using System.ComponentModel.DataAnnotations;

namespace AvMonitor
{
    public class TaskModel
    {
        [Display(Name = "����")]
        [Required]
        public string Id { get; set; }

        [Display(Name = "�������� ������")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Url")]
        [Required]
        public string Url { get; set; }

        [Display(Name = "�������� crontab")]
        [Required]
        public string CronExp { get; set; }

    }
}