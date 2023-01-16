namespace RecruiteeASPNETCoreWebAPI.DAL.Models.Response
{
    public class Candidate
    {
        public bool? upcoming_event { get; set; }
        public List<Field> fields { get; set; }
        public object gdpr_expires_at { get; set; }
        public List<string> links { get; set; }
        public object sourcing_origin { get; set; }
        public int? ratings_count { get; set; }
        public DateTime? created_at { get; set; }
        public List<object> admin_ids { get; set; }
        public object gdpr_scheduled_to_delete_at { get; set; }
        public bool? my_upcoming_event { get; set; }
        public int? id { get; set; }
        public int? attachments_count { get; set; }
        public int? notes_count { get; set; }
        public bool? has_avatar { get; set; }
        public bool? gdpr_consent_ever_given { get; set; }
        public object referrer { get; set; }
        public List<string> phones { get; set; }
        public bool? unread_notifications { get; set; }
        public double? rating { get; set; }
        public string name { get; set; }
        public bool? example { get; set; }
        public string gdpr_status { get; set; }
        public object my_last_rating { get; set; }
        public bool? pending_request_link { get; set; }
        public bool? in_active_share { get; set; }
        public Ratings ratings { get; set; }
        public DateTime? updated_at { get; set; }
        public string source { get; set; }
        public List<object> referral_referrers_ids { get; set; }
        public List<object> custom_fields { get; set; }
        public int? admin_id { get; set; }
        public bool? viewed { get; set; }
        public object gdpr_consent_request_type { get; set; }
        public object positive_ratings { get; set; }
        public string adminapp_url { get; set; }
        public object last_message_at { get; set; }
        public string photo_thumb_url { get; set; }
        public List<string> emails { get; set; }
        public DateTime? last_activity_at { get; set; }
        public int? mailbox_messages_count { get; set; }
        public int? tasks_count { get; set; }
        public List<string> social_links { get; set; }
        public List<object> sources { get; set; }
        public string cv_processing_status { get; set; }
        public List<object> grouped_open_question_answers { get; set; }
        public string photo_url { get; set; }
        public object cv_url { get; set; }
        public bool? my_pending_result_request { get; set; }
        public string initials { get; set; }
        public object sourcing_data { get; set; }
        public bool? rating_visible { get; set; }
        public List<int?> duplicates { get; set; }
        public object cv_original_url { get; set; }
        public bool? pending_result_request { get; set; }
        public bool? followed { get; set; }
        public List<object> tags { get; set; }
        public List<object> open_question_answers { get; set; }
        public string cover_letter { get; set; }
        public List<Placement> placements { get; set; }
        public object gdpr_consent_request_sent_at { get; set; }
        public object online_data { get; set; }
        public object gdpr_consent_request_completed_at { get; set; }
    }
}
