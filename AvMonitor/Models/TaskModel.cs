
using AvMonitor.Models;
using System.ComponentModel.DataAnnotations;

namespace AvMonitor
{
    public class TaskModel
    {
        [Display(Name = "Ќазвание задачи")]
        [Required]
        public string? Name { get; set; }  //может быть неуникальным

        [Display(Name = "ѕользователь")]
        public UserModel? User { get; set; } = new UserModel("NIKITA228"); //до реализации авторизации тут будет этот костыль, сор€н, если из-за этого буду ошибки ^-^

        public string Id { get { return $"{User?.Name}.{Name}"; } } //всегда ункикальное (у каждого пользовател€ имена всех задач уникальны)

        [Display(Name = "Url")]
        [Required]
        public string? Url { get; set; }

        [Display(Name = "ѕериодичность выполнени€ (выражение crontab)")]
        [Required]
        public string? CronExp { get; set; }

        [Display(Name = " анал св€зи дл€ уведомлени€")]
        public string? Channel { get; set; } = "";

    }
}