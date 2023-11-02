using AntiBotIO.Shared.Services;
using AntiBotIO.Shared.Models;

namespace AntiBotIO.Shared.Services
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
        public async Task<List<CommentItems>> ReadComments(string ApiKey, string ShortCode)
        {
            var result = _ınstagramService.GetComments(ApiKey, ShortCode);
            var jsonResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<CommentJsonModel>(result.Result);
            var comments = jsonResponse.data;
            List<CommentItems> commentTexts = new List<CommentItems>();
            foreach (var comment in comments.items)
            {
                commentTexts.Add(new CommentItems { text = comment.text, created_at = comment.created_at , comment_like_count = comment.comment_like_count , user = comment.user , did_report_as_spam = comment.did_report_as_spam , id = comment.id , user_id = comment.user_id});

            }
            return commentTexts;
        }
        public async Task<List<PostDetailData>> ReadPostDetails(string ApiKey, string ShortCode)
        {
            var result = _ınstagramService.GetPostDetails(ApiKey, ShortCode);
            var jsonResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<PostJsonModel>(result.Result);
            var postDetails = jsonResponse.data;

            List<PostDetailData> PostDetailList = new List<PostDetailData>();
            foreach (var postDetail in postDetails)
            {
                PostDetailList.Add(new PostDetailData {caption = postDetail.caption , });
            }
            return PostDetailList;
        }
        public async Task<List<string>> ReadProfileDetails(string ApiKey, string ShortCode)
        {
            var result = _ınstagramService.GetProfileDetails(ApiKey, ShortCode);
            var jsonResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<ProfileJsonModel>(result.Result);
            var profileDetails = jsonResponse.data;

            List<string> ProfileInfos = new List<string>();
            foreach (var profileDetail in profileDetails)
            {
                ProfileInfos.Add(profileDetail.biography);
                ProfileInfos.Add(profileDetail.bio_links.ToString());
                ProfileInfos.Add(profileDetail.follower_count.ToString());
                ProfileInfos.Add(profileDetail.following_count.ToString());
            }
            return ProfileInfos;
        }
        public async Task<List<Bots>> DetectBots(string apiKey, string shortCode, string userName)
        {
            
        }
//"Dm", "+18", "link", "hikayemde","telegram","kızlı erkekli","sütyen","erkekler","sitorim","yalnızım","pompa","gece","benden güzeli","sizce ben","18","25","20","yaş",
        private bool IsSuspicious(string text)
{
    // Şüpheli kelime listesi
    var suspiciousWords = new List<string> {  };

    // Her şüpheli kelime için kontrol et
    foreach (var word in suspiciousWords)
    {
        if (text.Contains(word))
        {
            return true;
        }
    }

    return false;
}

        private bool ContainsSpecialCharacters(string text)
{
    // Özel karakter listesi
    var specialCharacters = new List<char> 
    {
        '†', '¤', '¶', '§', '†', '!', '"', '#', '$', '%', '&', '\'', '(', ')', '*', '+', ',', '-', '.', '/',
        '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ':', ';', '<', '=', '>', '?', '@', 'A', 'B', 'C', 'D',
        'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
        '[', '\\', ']', '^', '_', '`', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p',
        'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '{', '|', '}', '~', '', 'Ç', 'ü', 'é', 'â', 'ä', 'à', 'å', 'ç',
        'ê', 'ë', 'è', 'ï', 'î', 'ì', 'æ', 'Æ', 'ô', 'ö', 'ò', 'û', 'ù', 'ÿ', '¢', '£', '¥', 'P', 'ƒ', 'á', 'í', 'ó',
        'ú', 'ñ', 'Ñ', '¿', '¬', '½', '¼', '¡', '«', '»', '¦', 'ß', 'µ', '±', '°', '•', '·', '²', '€', '„', '…', '†', '‡',
        'ˆ', '‰', 'Š', '‹', 'Œ', '‘', '’', '“', '”', '–', '—', '˜', '™', 'š', '›', 'œ', 'Ÿ', '¨', '©', '®', '¯', '³', '´', '¸',
        '¹', '¾', 'À', 'Á', 'Â', 'Ã', 'Ä', 'Å', 'È', 'É', 'Ê', 'Ë', 'Ì', 'Í', 'Î', 'Ï', 'Ð', 'Ò', 'Ó', 'Ô', 'Õ', 'Ö', '×',
        'Ø', 'Ù', 'Ú', 'Û', 'Ü', 'Ý', 'Þ', 'ã', 'ð', 'õ', '÷', 'ø', 'ü', 'ý', 'þ'
    };

    // Başında veya sonunda özel karakter içeriyor mu kontrol et
    return specialCharacters.Contains(text.FirstOrDefault()) || specialCharacters.Contains(text.LastOrDefault());
}
    }
}