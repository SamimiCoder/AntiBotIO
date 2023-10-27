namespace AntiBotIO.Shared.Models
{
    public class ApiData
    {
        
    }
     public class Captions
    {
        public List<object> items { get; set; }
    }

    public class Comments
    {
        public int count { get; set; }
    }

    public class Data
    {
        public int count { get; set; }
        public List<Item> items { get; set; }
        public int total { get; set; }
    }

    public class Dimensions
    {
        public int height { get; set; }
        public int width { get; set; }
    }

    public class DisplayVersion
    {
        public int height { get; set; }
        public string src { get; set; }
        public int width { get; set; }
    }

    public class Item
    {
        public object accessibility_caption { get; set; }
        public bool can_reshare { get; set; }
        public Captions captions { get; set; }
        public List<object> coauthor_producers { get; set; }
        public string code { get; set; }
        public Comments comments { get; set; }
        public bool comments_disabled { get; set; }
        public Dimensions dimensions { get; set; }
        public string display_url { get; set; }
        public List<DisplayVersion> display_versions { get; set; }
        public object fact_check_information { get; set; }
        public object fact_check_overall_rating { get; set; }
        public bool has_upcoming_event { get; set; }
        public string id { get; set; }
        public bool is_affiliate { get; set; }
        public bool is_paid_partnership { get; set; }
        public bool is_video { get; set; }
        public object location { get; set; }
        public object media_overlay_info { get; set; }
        public string media_preview { get; set; }
        public object nft_asset_info { get; set; }
        public Owner owner { get; set; }
        public List<object> pinned_for_users { get; set; }
        public PreviewLikes preview_likes { get; set; }
        public object sensitivity_friction_info { get; set; }
        public SharingFrictionInfo sharing_friction_info { get; set; }
        public SponsorUsers sponsor_users { get; set; }
        public TaggedUsers tagged_users { get; set; }
        public int taken_at_timestamp { get; set; }
        public string thumbnail_url { get; set; }
        public List<ThumbnailVersion> thumbnail_versions { get; set; }
        public string type { get; set; }
    }

    public class Owner
    {
        public string id { get; set; }
        public string username { get; set; }
    }

    public class PreviewLikes
    {
        public int count { get; set; }
        public List<object> items { get; set; }
    }

    public class JSONModel
    {
        public Data data { get; set; }
        public object pagination_token { get; set; }
    }

    public class SharingFrictionInfo
    {
        public object bloks_app_url { get; set; }
        public bool should_have_sharing_friction { get; set; }
    }

    public class SponsorUsers
    {
        public List<object> items { get; set; }
    }

    public class TaggedUsers
    {
        public List<object> items { get; set; }
    }

    public class ThumbnailVersion
    {
        public int height { get; set; }
        public string src { get; set; }
        public int width { get; set; }
    }
}