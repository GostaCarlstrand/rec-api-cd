namespace RecruiteeASPNETCoreWebAPI.DAL.Models;

public record Candidate
{
    public Candidate(string name,
        List<string> emails,
        List<string> phones,
        List<string> socialLinks,
        List<string> links,
        string coverLetter)
    {
        Name = name;
        Emails = emails;
        Phones = phones;
        Social_links = socialLinks;
        Links = links;
        Cover_letter = coverLetter;
    }

    public string Name { get; set; }
    public List<string> Emails { get; set; }
    public List<string> Phones { get; set; }
    public List<string> Social_links { get; set; }
    public List<string> Links { get; set; }
    public string Cover_letter { get; set; }
}