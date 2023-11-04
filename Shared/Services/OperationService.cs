using AntiBotIO.Shared.Services;
using AntiBotIO.Shared.Models;
using System.Linq;

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
            var result = await _ınstagramService.GetComments(ApiKey, ShortCode);
            var jsonResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<CommentJsonModel>(result);
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
    var result = await _ınstagramService.GetPostDetails(ApiKey, ShortCode);
    var jsonResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<PostJsonModel>(result);
    var postDetail = jsonResponse.data;

    List<PostDetailData> PostDetailList = new List<PostDetailData>();
    PostDetailList.Add(new PostDetailData {caption = postDetail.caption , taken_at = postDetail.taken_at});
    return PostDetailList;
}

        public async Task<List<ProfileData>> ReadProfileDetails(string ApiKey, string ShortCode)
        {
            var result = await _ınstagramService.GetProfileDetails(ApiKey, ShortCode);
            var jsonResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<ProfileJsonModel>(result);
            var profileDetails = jsonResponse.data;

            List<ProfileData> ProfileInfos = new List<ProfileData>();
            foreach (var profileDetail in profileDetails)
            {
                ProfileInfos.Add(new ProfileData {bio_links = profileDetail.bio_links , biography = profileDetail.biography , follower_count = profileDetail.follower_count  , following_count = profileDetail.following_count});
            }
            return ProfileInfos;
        }
        public async Task<List<Bots>> DetectBots(string apiKey, string shortCode, string userName)
        {
            var commentList = await ReadComments(apiKey, shortCode);
            var postDetailList = (await ReadPostDetails(apiKey, shortCode)).ToList();
            var profileDetailList = (await ReadProfileDetails(apiKey, shortCode)).ToList();
            DetectionPossibilities possibilities = new DetectionPossibilities();
            List<Bots> Bots = new List<Bots>();
            int SuspiciousRate = 0;
            foreach(var comment in commentList)
            {
                if (IsSuspicious(comment.text))
                {
                    SuspiciousRate += 2;
                    possibilities.IsTextSuspicious = true;
                }
                if (ContainsSpecialCharacters(comment.text))
                {
                    SuspiciousRate += 10;
                    possibilities.IsTextContainsSpecialCaracters = true;
                }
            }
            foreach (var post in postDetailList)
            {
                if (post.taken_at.Equals(DateTime.Parse(commentList.FirstOrDefault().created_at.ToString())) 
                || post.taken_at.Equals(DateTime.Parse(commentList.FirstOrDefault().created_at.ToString()).AddSeconds(10)))
                {
                    SuspiciousRate += 10;
                    possibilities.IsDateEqualsPost = true;
                    break;
                }
            }
            foreach(var profile in profileDetailList)
            {
                if (IsSuspicious(profile.biography))
                {
                    SuspiciousRate += 10;
                    possibilities.IsProfileBioHasSuspiciousWords = true;
                }
                else if(profile.bio_links[0].url.Contains("t.me")){
                    SuspiciousRate += 15;
                    possibilities.IsProfileBioLinkIsTelegram = true;
                }
            }
            if (SuspiciousRate >= 50)
            {
                foreach (var BotProp in profileDetailList)
                {
                    Bots.Add(new Bots {BotName = BotProp.username , BotBio = BotProp.biography , BotId = Int32.Parse(BotProp.id) , SuspectRate = SuspiciousRate , BotComment = ""});
                }
                //engelleme işlemi
            }
            return Bots;
        }
        private bool IsSuspicious(string text)
{
    // Şüpheli kelime listesi
    var suspiciousWords = new List<string> { "Dm", "+18", "link", "hikayemde","telegram","kızlı erkekli","sütyen","erkekler","sitorim","yalnızım","pompa","gece","benden güzeli","sizce ben","18","25","20","yaş","tg","telegram grubumuz","tg grubumuz","link bio","bioma bak",@"\U+1F447","1000 takipçi","düşmeyen takipçi","sayfamıza davetlisiniz","davetlisiniz","olay ne","var mi","var mı","varmi","varmı" };

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