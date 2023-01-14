namespace RecruiteeASPNETCoreWebAPI.DAL.Models
{
    public class Attachment
    {
        public Attachment() { }
        public IFormFile file { get; set; }
        public string candidate_id { get; set; }
    }
}