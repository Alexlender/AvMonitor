
using AvMonitor.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AvMonitor.Models
{
    [Keyless]
    public class TaskModel
    {
        [Display(Name = "��� �������")]
        [Required]
        public string? Name { get; set; } 
        public string? UserName { get; set; } 

        public string Id { get { return $"{UserName}.{Name}"; } } //������ ����������� (� ������� ������������ ����� ���� ����� ���������)

        [Display(Name = "Url")]
        [Required]
        public string? Path { get; set; }

        [Display(Name = "������������� ���������� (��������� crontab)")]
        [Required]
        public string? CronExp { get; set; }

        [Display(Name = "��������")]
        public string Description { get; set; } = "";

    }
}