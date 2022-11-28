
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
        public UserModel? User { get; set; } = new UserModel("NIKITA228"); //�� ���������� ����������� ��� ����� ���� �������, �����, ���� ��-�� ����� ���� ������ ^-^

        public string Id { get { return $"{User?.Name}.{Name}"; } } //������ ����������� (� ������� ������������ ����� ���� ����� ���������)

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