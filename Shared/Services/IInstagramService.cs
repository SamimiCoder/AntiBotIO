
namespace AntiBotIO.Shared.Services
{
    public interface IInstagramService
    {
        public Task<string> GetComments(string ApiKey,string ShortCode,string? PaginationToken);
        public Task<string> GetComments(string ApiKey, string ShortCode);
        public Task<string> GetPosts(string ApiKey, string ShortCode);
        public Task<string> GetReels(string ApiKey, string ShortCode);
        public Task<string> GetLikes(string ApiKey, string ShortCode);
        public Task<string> GetPostDetails(string apiKey, string shortCode);
        public Task<string> GetProfileDetails(string apiKey, string shortCode);
    }
}
