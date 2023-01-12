using System.Text.Json.Serialization;

namespace RecruiteeASPNETCoreWebAPI.DAL.Models
{
    public class Application
    {
        public Application(Candidate candidate, string offerId) {
            Candidate = candidate;
            Offer_id = offerId;
        }
        public Candidate Candidate { get; set; }
        public string Offer_id { get; set; }
    }
}