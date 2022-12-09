
using AvMonitor.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AvMonitor.Models
{

    public class TaskModel
    {
        [Display(Name = "��� ������")]
        [Required]
        public string? Name { get; set; } 
        public string? UserName { get; set; }

        [Key]
        public int Index { get; set; }

        public string Id { get { return $"{UserName}.{Name}"; } } //������ ����������� (� ������� ������������ ����� ���� ����� ���������)

        [Display(Name = "������ �� ������")]
        [Required]
        public string? Path { get; set; }

        [Display(Name = "���������� � ������� CRON")]
        [Required]
        public string? CronExp { get; set; }

        [Display(Name = "��������")]
        public string Description { get; set; } = "";

    }
}