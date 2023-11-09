namespace Shared.Models
{
    public class ProfileDetailDTO
    {
        public string[]? bio_links { get; set; }
        public string? biography { get; set; }
        public int? follower_count { get; set; }
        public int? following_count { get; set; }
        public string? username { get; set; }
    }
}