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
        private readonly IInstagramService _instaService;

        public InstagramController(IInstagramService instaService)
        {
            _instaService = instaService;
        }
        [HttpGet("GetComments")]
        public async Task<string> GetComments(string ShortCode)
        {
           var result = await _instaService.GetComments("6c202f6909msh5e75652d5bd0a45p1492bejsna4d4d201dc46", ShortCode);
           return result;
        }

        [HttpGet("GetPosts")]
        public async Task<string> GetPosts( string userId)
        {
            var result = await _instaService.GetPosts("6c202f6909msh5e75652d5bd0a45p1492bejsna4d4d201dc46", userId);
            return result;
        }
    }
}
