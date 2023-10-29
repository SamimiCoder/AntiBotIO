using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AntiBotIO.Shared.Models
{
    internal class UserProfile
    {
    }

    public class RootObject
    {
        public ProfileData data { get; set; }
    }
    public class ProfileJsonModel
    {
        public ProfileData[] data { get; set; }
        public Item[] items { get; set; }
    }
    public class ProfileData
    {
        public object[] account_badges { get; set; }
        public string account_category { get; set; }
        public int account_type { get; set; }
        public Active_Standalone_Fundraisers active_standalone_fundraisers { get; set; }
        public string address_street { get; set; }
        public object ads_incentive_expiration_date { get; set; }
        public long ads_page_id { get; set; }
        public string ads_page_name { get; set; }
        public object auto_expand_chaining { get; set; }
        public Avatar_Status avatar_status { get; set; }
        public Bio_Links[] bio_links { get; set; }
        public string biography { get; set; }
        public Biography_With_Entities biography_with_entities { get; set; }
        public string birthday_today_visibility_for_viewer { get; set; }
        public Broadcast_Chat_Preference_Status broadcast_chat_preference_status { get; set; }
        public string business_contact_method { get; set; }
        public bool can_add_fb_group_link_on_profile { get; set; }
        public bool can_hide_category { get; set; }
        public bool can_hide_public_contacts { get; set; }
        public bool can_use_affiliate_partnership_messaging_as_brand { get; set; }
        public bool can_use_affiliate_partnership_messaging_as_creator { get; set; }
        public bool can_use_branded_content_discovery_as_brand { get; set; }
        public bool can_use_branded_content_discovery_as_creator { get; set; }
        public string category { get; set; }
        public int category_id { get; set; }
        public int city_id { get; set; }
        public string city_name { get; set; }
        public string contact_phone_number { get; set; }
        public object current_catalog_id { get; set; }
        public string direct_messaging { get; set; }
        public object displayed_action_button_partner { get; set; }
        public string displayed_action_button_type { get; set; }
        public bool existing_user_age_collection_enabled { get; set; }
        public string external_lynx_url { get; set; }
        public string external_url { get; set; }
        public Fan_Club_Info fan_club_info { get; set; }
        public string fbid_v2 { get; set; }
        public bool feed_post_reshare_disabled { get; set; }
        public int follow_friction_type { get; set; }
        public int follower_count { get; set; }
        public int following_count { get; set; }
        public int following_tag_count { get; set; }
        public string full_name { get; set; }
        public bool has_anonymous_profile_picture { get; set; }
        public bool has_chaining { get; set; }
        public bool has_collab_collections { get; set; }
        public bool has_exclusive_feed_content { get; set; }
        public bool has_fan_club_subscriptions { get; set; }
        public bool has_guides { get; set; }
        public bool has_highlight_reels { get; set; }
        public bool has_igtv_series { get; set; }
        public bool has_music_on_profile { get; set; }
        public bool has_private_collections { get; set; }
        public bool has_public_tab_threads { get; set; }
        public bool has_videos { get; set; }
        public Hd_Profile_Pic_Url_Info hd_profile_pic_url_info { get; set; }
        public Hd_Profile_Pic_Versions[] hd_profile_pic_versions { get; set; }
        public bool highlight_reshare_disabled { get; set; }
        public string home_country { get; set; }
        public string id { get; set; }
        public bool include_direct_blacklist_status { get; set; }
        public string instagram_location_id { get; set; }
        public long interop_messaging_user_fbid { get; set; }
        public bool is_bestie { get; set; }
        public bool is_business { get; set; }
        public bool is_call_to_action_enabled { get; set; }
        public bool is_category_tappable { get; set; }
        public bool is_direct_roll_call_enabled { get; set; }
        public bool is_eligible_for_lead_center { get; set; }
        public bool is_eligible_for_smb_support_flow { get; set; }
        public bool is_experienced_advertiser { get; set; }
        public bool is_favorite { get; set; }
        public bool is_favorite_for_clips { get; set; }
        public bool is_favorite_for_highlights { get; set; }
        public bool is_favorite_for_igtv { get; set; }
        public bool is_favorite_for_stories { get; set; }
        public bool is_in_canada { get; set; }
        public bool is_interest_account { get; set; }
        public bool is_memorialized { get; set; }
        public bool is_new_to_instagram { get; set; }
        public bool is_opal_enabled { get; set; }
        public bool is_potential_business { get; set; }
        public bool is_private { get; set; }
        public bool is_profile_audio_call_enabled { get; set; }
        public bool is_profile_broadcast_sharing_enabled { get; set; }
        public bool is_profile_picture_expansion_enabled { get; set; }
        public bool is_regulated_c18 { get; set; }
        public bool is_secondary_account_creation { get; set; }
        public bool is_supervision_features_enabled { get; set; }
        public bool is_verified { get; set; }
        public bool is_whatsapp_linked { get; set; }
        public string lead_details_app_id { get; set; }
        public string live_subscription_status { get; set; }
        public int media_count { get; set; }
        public object mini_shop_seller_onboarding_status { get; set; }
        public int mutual_followers_count { get; set; }
        public object nametag { get; set; }
        public object num_of_admined_pages { get; set; }
        public bool open_external_url_with_in_app_browser { get; set; }
        public long page_id { get; set; }
        public string page_name { get; set; }
        public Pinned_Channels_Info pinned_channels_info { get; set; }
        public int primary_profile_link_type { get; set; }
        public int professional_conversion_suggested_account_type { get; set; }
        public string profile_context { get; set; }
        public object[] profile_context_facepile_users { get; set; }
        public object[] profile_context_links_with_user_ids { get; set; }
        public string profile_pic_id { get; set; }
        public string profile_pic_url { get; set; }
        public int profile_type { get; set; }
        public object[] pronouns { get; set; }
        public string public_email { get; set; }
        public string public_phone_country_code { get; set; }
        public string public_phone_number { get; set; }
        public Recs_From_Friends recs_from_friends { get; set; }
        public bool remove_message_entrypoint { get; set; }
        public object shopping_post_onboard_nux_type { get; set; }
        public bool should_show_category { get; set; }
        public bool should_show_public_contacts { get; set; }
        public bool show_account_transparency_details { get; set; }
        public bool show_fb_link_on_profile { get; set; }
        public bool show_fb_page_link_on_profile { get; set; }
        public bool show_ig_app_switcher_badge { get; set; }
        public bool show_post_insights_entry_point { get; set; }
        public bool show_text_post_app_badge { get; set; }
        public bool show_text_post_app_switcher_badge { get; set; }
        public bool show_together_pog { get; set; }
        public object smb_delivery_partner { get; set; }
        public object smb_support_delivery_partner { get; set; }
        public object smb_support_partner { get; set; }
        public string text_post_app_badge_label { get; set; }
        public int text_post_app_joiner_number { get; set; }
        public string text_post_app_joiner_number_label { get; set; }
        public int third_party_downloads_enabled { get; set; }
        public int total_ar_effects { get; set; }
        public int total_clips_count { get; set; }
        public int total_igtv_videos { get; set; }
        public bool transparency_product_enabled { get; set; }
        public object[] upcoming_events { get; set; }
        public string username { get; set; }
        public string whatsapp_number { get; set; }
        public string zip { get; set; }
    }

    public class Active_Standalone_Fundraisers
    {
        public object[] fundraisers { get; set; }
        public int total_count { get; set; }
    }

    public class Avatar_Status
    {
        public bool has_avatar { get; set; }
    }

    public class Biography_With_Entities
    {
        public Entity[] entities { get; set; }
        public string raw_text { get; set; }
    }

    public class Entity
    {
        public Profile_User user { get; set; }
    }

    public class Profile_User
    {
        public long id { get; set; }
        public string username { get; set; }
    }

    public class Broadcast_Chat_Preference_Status
    {
        public string json_response { get; set; }
    }

    public class User_Fan_Club_Info
    {
        public object autosave_to_exclusive_highlight { get; set; }
        public object connected_member_count { get; set; }
        public object fan_club_id { get; set; }
        public object fan_club_name { get; set; }
        public object fan_consideration_page_revamp_eligiblity { get; set; }
        public object has_enough_subscribers_for_ssc { get; set; }
        public object is_fan_club_gifting_eligible { get; set; }
        public object is_fan_club_referral_eligible { get; set; }
        public object subscriber_count { get; set; }
    }

    public class Hd_Profile_Pic_Url_Info
    {
        public int height { get; set; }
        public string url { get; set; }
        public int width { get; set; }
    }

    public class Pinned_Channels_Info
    {
        public bool has_public_channels { get; set; }
        public object[] pinned_channels_list { get; set; }
    }

    public class Recs_From_Friends
    {
        public bool enable_recs_from_friends { get; set; }
        public string recs_from_friends_entry_point_type { get; set; }
    }

    public class Bio_Links
    {
        public string click_id { get; set; }
        public long link_id { get; set; }
        public string link_type { get; set; }
        public string lynx_url { get; set; }
        public bool open_external_url_with_in_app_browser { get; set; }
        public string title { get; set; }
        public string url { get; set; }
    }

    public class Hd_Profile_Pic_Versions
    {
        public int height { get; set; }
        public string url { get; set; }
        public int width { get; set; }
    }



}