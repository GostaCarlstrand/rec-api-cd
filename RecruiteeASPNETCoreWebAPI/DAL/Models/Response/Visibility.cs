namespace RecruiteeASPNETCoreWebAPI.DAL.Models.Response
{
    public class Visibility
    {
        public List<object> admin_ids { get; set; }
        public string level { get; set; }
        public List<object> role_ids { get; set; }
    }
}
