namespace RecruiteeASPNETCoreWebAPI.DAL.Models;

public class Application
{
    public Application() { }

    public Applicant candidate { get; set; }
    public string offer_id { get; set; }
}