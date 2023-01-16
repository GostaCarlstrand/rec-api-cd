namespace RecruiteeASPNETCoreWebAPI.DAL.Models.Response;

public class Placement
{
    public int? candidate_id { get; set; }
    public DateTime? created_at { get; set; }
    public object hired_at { get; set; }
    public object hired_by_id { get; set; }
    public bool? hired_in_other_placement { get; set; }
    public bool? hired_in_this_placement { get; set; }
    public int? id { get; set; }
    public object job_starts_at { get; set; }
    public object language { get; set; }
    public int? offer_id { get; set; }
    public object overdue_at { get; set; }
    public object overdue_diff { get; set; }
    public int? position { get; set; }
    public object positive_ratings { get; set; }
    public bool? rating_visible { get; set; }
    public Ratings ratings { get; set; }
    public int? stage_id { get; set; }
    public DateTime? updated_at { get; set; }
}