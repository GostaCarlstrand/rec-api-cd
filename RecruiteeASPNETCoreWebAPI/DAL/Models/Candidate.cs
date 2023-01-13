namespace RecruiteeASPNETCoreWebAPI.DAL.Models;

public record Candidate
{
    public Candidate(string _name,
        List<string> _emails,
        List<string> _phones,
        List<string> _socialLinks,
        List<string> _links,
        string _coverLetter)
    {
        name = _name;
        emails = _emails;
        phones = _phones;
        social_links = _socialLinks;
        links = _links;
        cover_letter = _coverLetter;
    }

    public string name { get; set; }
    public List<string> emails { get; set; }
    public List<string> phones { get; set; }
    public List<string> social_links { get; set; }
    public List<string> links { get; set; }
    public string cover_letter { get; set; }
}