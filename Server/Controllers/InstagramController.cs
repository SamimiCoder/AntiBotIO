using AntiBotIO.Shared.Services;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AntiBotIO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstagramController : ControllerBase
    {
         ConfigurationManager Configuration;
        private readonly IInstagramService _instaService;
        private readonly string _apiKeyInstagram2;

        public InstagramController(IConfiguration configuration, IInstagramService instaService)
        {
            _instaService = instaService;
            _apiKeyInstagram2 = configuration.GetSection("ApiSettings")["ApiKeyInstagram2"];
        }

        [HttpGet("GetComments")]
        public async Task<string> GetComments(string ShortCode)
        {
            var result = await _instaService.GetComments(_apiKeyInstagram2, ShortCode);
            return result;
        }
        

        [HttpGet("GetPosts")]
        public async Task<string> GetPosts( string userId)
        {
            var result = await _instaService.GetPosts(_apiKeyInstagram2, userId);
            return result;
        }
    }
}
