namespace RecruiteeASPNETCoreWebAPI.DAL.Models.Response;

public class Field
{
    public bool? @fixed { get; set; }
    public object id { get; set; }
    public string kind { get; set; }
    public Options options { get; set; }
    public string origin { get; set; }
    public List<object> values { get; set; }
    public Visibility visibility { get; set; }
    public bool? visible { get; set; }
}