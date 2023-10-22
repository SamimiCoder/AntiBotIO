using Microsoft.AspNetCore.Mvc;

namespace AntiBotIO.Services
{
    public interface IInstagramService
    {
        public Task<string> GetComments(string ApiKey,string ShortCode);
        public Task<string> GetPosts(string ApiKey, string ShortCode);
        public Task<string> GetReels(string ApiKey, string ShortCode);
        public Task<string> GetLikes(string ApiKey, string ShortCode);
    }
}
