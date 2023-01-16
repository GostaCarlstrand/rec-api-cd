namespace RecruiteeASPNETCoreWebAPI.DAL.Models.Response
{
    public class Reference
    {
        public int? department_id { get; set; }
        public string guid { get; set; }
        public int? id { get; set; }
        public string kind { get; set; }
        public string lang_code { get; set; }
        public string location { get; set; }
        public int? position { get; set; }
        public string slug { get; set; }
        public string status { get; set; }
        public string title { get; set; }
        public string type { get; set; }
        public List<object> action_templates { get; set; }
        public string category { get; set; }
        public object created_at { get; set; }
        public bool? fair_evaluations_enabled { get; set; }
        public object group { get; set; }
        public bool? locked { get; set; }
        public string name { get; set; }
        public object placements_count { get; set; }
        public object time_limit { get; set; }
        public object updated_at { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public bool? has_avatar { get; set; }
        public string initials { get; set; }
        public string last_name { get; set; }
        public string photo_normal_url { get; set; }
        public string photo_thumb_url { get; set; }
        public bool? time_format24 { get; set; }
        public string timezone { get; set; }
    }
}
