using AntiBotIO.Services;
using AntiBotIO.Shared.Models;

namespace Server.Services
{
    public class OperationService
    {
        private readonly IInstagramService _ınstagramService;
        private IGComments _comments;
        public OperationService(IInstagramService ınstagramService, IGComments comments)
        {
            _ınstagramService = ınstagramService;
            _comments = comments;
        }
        public async Task<List<string>> ReadComments(string ApiKey, string ShortCode, string GeneralApiResult)
        {
            var result = _ınstagramService.GetComments(ApiKey, ShortCode);
            var jsonResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<CommentJsonModel>(result.Result);
            var comments = jsonResponse.data.items;

            List<string> commentTexts = new List<string>();
            foreach (var comment in comments)
            {
                commentTexts.Add(comment.text);
            }
            return commentTexts;
        }
        public async Task<List<string>> ReadPostDetails(string ApiKey,string ShortCode , string GeneralApiResult)
        {
            var result = _ınstagramService.GetPostDetails(ApiKey, ShortCode);
            var jsonResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<PostJsonModel>(result.Result);
            var postDetails = jsonResponse.data;

            List<string> commentTexts = new List<string>();
            foreach (var postDetail in postDetails)
            {
                commentTexts.Add(postDetail.taken_at.ToString());
            }
            return commentTexts;
        }
        public async Task<List<string>> DetectBots()
        {
            
        }
    }
}