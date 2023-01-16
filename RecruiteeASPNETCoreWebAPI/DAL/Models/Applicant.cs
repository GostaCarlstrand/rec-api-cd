namespace RecruiteeASPNETCoreWebAPI.DAL.Models;

public record Applicant
{
    public Applicant() { }

    public string name { get; set; }
    public List<string> emails { get; set; }
    public List<string> phones { get; set; }
    public List<string>? social_links { get; set; }
    public List<string>? links { get; set; }
    public string? cover_letter { get; set; }
}