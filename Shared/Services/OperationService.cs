using AntiBotIO.Shared.Services;
using AntiBotIO.Shared.Models;
using System.Linq;
using Shared.Models;

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
        public async Task<List<CommentDTO>> ReadComments(string ApiKey, string ShortCode)
        {
            var result = await _ınstagramService.GetComments(ApiKey, ShortCode);
            var jsonResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<CommentJsonModel>(result);
            var comments = jsonResponse.data;
            List<CommentDTO> commentTexts = new List<CommentDTO>();
            foreach (var comment in comments.items)
            {
                commentTexts.Add(new CommentDTO { 
                    comment_text = comment.text, 
                    created_at = DateTimeOffset.FromUnixTimeSeconds((long)comment.created_at).DateTime, 
                    comment_like_count = (int)comment.comment_like_count, 
                    did_report_as_spam = (bool)comment.did_report_as_spam, 
                    id = comment.id, 
                    user_id = (long)comment.user_id 
                });
            }
            return commentTexts;
        }
        public async Task<List<PostDetailDTO>> ReadPostDetails(string ApiKey, string ShortCode)
        {
            var result = await _ınstagramService.GetPostDetails(ApiKey, ShortCode);
            var jsonResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<PostJsonModel>(result);
            var postDetail = jsonResponse.data;

            List<PostDetailDTO> PostDetailList = new List<PostDetailDTO>
            {
                new PostDetailDTO { Caption = postDetail.caption.ToString(), taken_at = DateTimeOffset.FromUnixTimeSeconds(postDetail.taken_at).DateTime }
            };
            return PostDetailList;
        }

        public async Task<List<ProfileDetailDTO>> ReadProfileDetails(string ApiKey, string ShortCode)
        {
            var result = await _ınstagramService.GetProfileDetails(ApiKey, ShortCode);
            var jsonResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<ProfileJsonModel>(result);
            var profileDetails = jsonResponse.data;

            List<ProfileDetailDTO> ProfileInfos = new List<ProfileDetailDTO>();
            
                ProfileInfos.Add(new ProfileDetailDTO { 
                    bio_links = profileDetails.bio_links.Select(x => x.url).ToArray(), 
                    biography = profileDetails.biography, 
                    follower_count = profileDetails.follower_count, 
                    following_count = profileDetails.following_count,
                    username = profileDetails.username
                });
            
            return ProfileInfos;
        }
        public async Task<List<Bots>> DetectBots(string apiKey, string shortCode, string userName)
        {
            var commentList = await ReadComments(apiKey, shortCode);
            var postDetailList = (await ReadPostDetails(apiKey, shortCode)).ToList();
            var profileDetailList = (await ReadProfileDetails(apiKey, userName)).ToList();
            DetectionPossibilities possibilities = new DetectionPossibilities();
            List<Bots> Bots = new List<Bots>();
            int SuspiciousRate = 0;
            foreach (var comment in commentList)
            {
                if (IsSuspicious(comment.comment_text))
                {
                    SuspiciousRate += 5;
                    possibilities.IsTextSuspicious = true;
                }
                if (ContainsSpecialCharacters(comment.comment_text))
                {
                    SuspiciousRate += 20;
                    possibilities.IsTextContainsSpecialCaracters = true;
                }
            }
            foreach (var post in postDetailList)
            {
                if (post.taken_at.Equals(DateTime.Parse(commentList.FirstOrDefault().created_at.ToString()))
                || post.taken_at.Equals(DateTime.Parse(commentList.FirstOrDefault().created_at.ToString()).AddSeconds(10)))
                {
                    SuspiciousRate += 20;
                    possibilities.IsDateEqualsPost = true;
                    
                }
            }
            foreach (var profile in profileDetailList)
            {
                if (IsSuspicious(profile.biography))
                {
                    SuspiciousRate += 15;
                    possibilities.IsProfileBioHasSuspiciousWords = true;
                }
                else if (profile.bio_links[0].Contains("t.me"))
                {
                    SuspiciousRate += 20;
                    possibilities.IsProfileBioLinkIsTelegram = true;
                }
            }
            Console.WriteLine(SuspiciousRate);
            if (SuspiciousRate >= 5)
            {
                Console.WriteLine("Bir bot tespit edildi");
                Console.WriteLine(SuspiciousRate);
                foreach (var BotProp in profileDetailList)
                {
                    Console.WriteLine("Botun adı: " + BotProp.username);
                    Bots.Add(new Bots { BotName = BotProp.username, BotBio = BotProp.biography, SuspectRate = SuspiciousRate, BotComment = "" });
                }
                //engelleme işlemi
            }
            else {
                Bots.Add(new Bots { BotName = "NONE", BotBio = "NONE", BotId = 0, SuspectRate = 0, BotComment = "NONE" });
            }
            return Bots;
        }
        private bool IsSuspicious(string text)
        {
            // Şüpheli kelime listesi
            var suspiciousWords = new List<string> { "Dm", "+18", "link", "hikayemde", "telegram", "kızlı erkekli", "sütyen", "erkekler", "sitorim", "yalnızım", "pompa", "gece", "benden güzeli", "sizce ben", "18", "25", "20", "yaş", "tg", "telegram grubumuz", "tg grubumuz", "link bio", "bioma bak", @"\U+1F447", "1000 takipçi", "düşmeyen takipçi", "sayfamıza davetlisiniz", "davetlisiniz", "olay ne", "var mi", "var mı", "varmi", "varmı" };

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