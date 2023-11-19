using Shared.Models;
namespace Shared.Models
{
    public class CommentDTO
    {
        public string comment_text { get; set; }
        public DateTime created_at { get; set; }
        public int comment_like_count { get; set; }
        public bool did_report_as_spam { get; set; }
        public string id { get; set; }
        public long user_id { get; set; }
        public string? paginationToken { get; set; }
    }
}