namespace EduHubApi.Models;

public class Registration
{
    public int Id { get; set; }
    public int MemberId { get; set; }
    public int CourseId { get; set; }
    public string Status { get; set; } = "pending";
}