namespace AntiBotIO.Shared.Models
{
    public class IGComments {
        public string? ShortCode { get; set; }
        public string? CommentText { get; set; }
        public string? CommentId { get; set; }
        public string? UserId { get; set; }
        public string? FullName { get; set; }
        public string? ProfilePicture { get; set; }
        public DateTime? Date { get; set; }
        public string? UserName { get; set; }
    }
    public class Rootobject
    {
        public DataComment? data { get; set; }
        public string? pagination_token { get; set; }
    }
    public class CommentJsonModel
    {
        public DataComment? data { get; set; }
        public object? Pagination { get; set; }
    }
    public class DataComment
    {
        public Additional_Data? additional_data { get; set; }
        public long? count { get; set; }
        public CommentItems[]? items { get; set; }
        public long? total { get; set; }
    }

    public class Additional_Data
    {
        public Caption? caption { get; set; }
        public bool? caption_is_edited { get; set; }
        public string? comment_filter_param { get; set; }
        public bool? comment_likes_enabled { get; set; }
        public bool? insert_new_comment_to_top { get; set; }
        public bool? is_ranked { get; set; }
        public string? media_header_display { get; set; }
        public Quick_Response_Emojis[]? quick_response_emojis { get; set; }
        public bool? threading_enabled { get; set; }
    }

    public class Caption
    {
        public string? content_type { get; set; }
        public long? created_at { get; set; }
        public int? created_at_utc { get; set; }
        public bool? did_report_as_spam { get; set; }
        public bool? is_covered { get; set; }
        public bool? is_created_by_media_owner { get; set; }
        public bool? is_ranked_comment { get; set; }
        public string? pk { get; set; }
        public bool? share_enabled { get; set; }
        public string? text { get; set; }
        public int? type { get; set; }
        public User? user { get; set; }
        public long? user_id { get; set; }
    }

    public class User
    {
        public Fan_Club_Status_Sync_Info? fan_club_status_sync_info { get; set; }
        public string? fbid_v2 { get; set; }
        public string? full_name { get; set; }
        public string? id { get; set; }
        public bool? is_mentionable { get; set; }
        public bool? is_private { get; set; }
        public bool? is_verified { get; set; }
        public string? profile_pic_id { get; set; }
        public string? profile_pic_url { get; set; }
        public string? username { get; set; }
    }

    public class Fan_Club_Status_Sync_Info
    {
        public bool? eligible_to_subscribe { get; set; }
        public bool? subscribed { get; set; }
    }

    public class Quick_Response_Emojis
    {
        public string? unicode { get; set; }
    }

    public class CommentItems
    {
        public int? child_comment_count { get; set; }
        public int? comment_index { get; set; }
        public int? comment_like_count { get; set; }
        public string? content_type { get; set; }
        public long? created_at { get; set; }
        public int? created_at_utc { get; set; }
        public bool? did_report_as_spam { get; set; }
        public bool? has_liked { get; set; }
        public bool? has_liked_comment { get; set; }
        public string? id { get; set; }
        public string? inline_composer_display_condition { get; set; }
        public bool? is_covered { get; set; }
        public bool? is_ranked_comment { get; set; }
        public int? like_count { get; set; }
        public Other_Preview_Users[]? other_preview_users { get; set; }
        public string? pk { get; set; }
        public int? private_reply_status { get; set; }
        public bool? share_enabled { get; set; }
        public string? text { get; set; }
        public int? type { get; set; }
        public User1? user { get; set; }
        public long? user_id { get; set; }
        public bool? has_more_head_child_comments { get; set; }
        public bool? has_more_tail_child_comments { get; set; }
    }

    public class User1
    {
        public string? fbid_v2 { get; set; }
        public string? full_name { get; set; }
        public string? id { get; set; }
        public bool? is_mentionable { get; set; }
        public bool? is_private { get; set; }
        public bool? is_verified { get; set; }
        public int? latest_besties_reel_media { get; set; }
        public int? latest_reel_media { get; set; }
        public string? profile_pic_id { get; set; }
        public string? profile_pic_url { get; set; }
        public string? username { get; set; }
    }

    public class Other_Preview_Users
    {
        public long? id { get; set; }
        public string? profile_pic_url { get; set; }
    }

}