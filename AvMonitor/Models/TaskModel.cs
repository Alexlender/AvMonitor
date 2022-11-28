
using AvMonitor.Models;
using System.ComponentModel.DataAnnotations;

namespace AvMonitor
{
    public class TaskModel
    {
        [Display(Name = "�������� ������")]
        [Required]
        public string? Name { get; set; }  //����� ���� ������������

        [Display(Name = "������������")]
        public string? UserName { get; set; } = "NIKITA228"; //�� ���������� ����������� ��� ����� ���� �������, �����, ���� ��-�� ����� ���� ������ ^-^

        public string Id { get { return $"{UserName}.{Name}"; } } //������ ����������� (� ������� ������������ ����� ���� ����� ���������)

        [Display(Name = "Url")]
        [Required]
        public string? Url { get; set; }

        [Display(Name = "������������� ���������� (��������� crontab)")]
        [Required]
        public string? CronExp { get; set; }

        [Display(Name = "����� ����� ��� �����������")]
        public string? Channel { get; set; } = "";

    }
}