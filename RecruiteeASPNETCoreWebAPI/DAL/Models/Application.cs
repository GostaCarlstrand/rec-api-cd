using System.Text.Json.Serialization;

namespace RecruiteeASPNETCoreWebAPI.DAL.Models
{
    public class Application
    {
        public Application() { }

        public Candidate candidate { get; set; }
        public string offer_id { get; set; }
    }
}