﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

using System.Text;

namespace AntiBotIO.Services
{
    public class InstagramService : IInstagramService
    {
        public async Task<string> GetComments(string ApiKey, string ShortCode)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://instagram-scraper-api2.p.rapidapi.com/v1/comments?code={ShortCode}"),
                Headers =
                {
                    { "X-RapidAPI-Key", $"{ApiKey}" },
                    { "X-RapidAPI-Host", "instagram-scraper-api2.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var bodyBytes = await response.Content.ReadAsByteArrayAsync();
                var body = Encoding.UTF8.GetString(bodyBytes);
                return body;
            }
        }

        public async Task<string> GetLikes(string ApiKey, string ShortCode)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://instagram-scraper-api2.p.rapidapi.com/v1/likes?code={ShortCode}"),
                Headers =
                        {
                            { "X-RapidAPI-Key", $"{ApiKey}" },
                            { "X-RapidAPI-Host", "instagram-scraper-api2.p.rapidapi.com" },
                        },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return body;
            }
        }

        public async Task<string> GetPosts(string ApiKey, string ShortCode)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://instagram-scraper-api2.p.rapidapi.com/v1/posts?username_or_id_or_url={ShortCode}"),
                Headers =
                        {
                            { "X-RapidAPI-Key", $"{ApiKey}" },
                            { "X-RapidAPI-Host", "instagram-scraper-api2.p.rapidapi.com" },
                        },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return body;
            }
        }

        public async Task<string> GetReels(string ApiKey, string ShortCode)
        {
            
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://instagram-scraper-api2.p.rapidapi.com/v1/reels?id={ShortCode}"),
                Headers =
                        {
                            { "X-RapidAPI-Key", $"{ApiKey}" },
                            { "X-RapidAPI-Host", "instagram-scraper-api2.p.rapidapi.com" },
                        },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return body;
            }
        }
    }
}
