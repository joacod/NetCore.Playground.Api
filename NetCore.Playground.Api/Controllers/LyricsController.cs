using Microsoft.AspNetCore.Mvc;
using NetCore.Playground.Api.Models;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;

namespace NetCore.Playground.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]    
    public class LyricsController : ControllerBase
    {
        public LyricsController()
        {
        }

        [HttpGet]
        public async Task<SongLyrics> Get([Required]string artist, [Required]string song)
        {
            var apiURL = "https://api.lyrics.ovh/v1/" + artist + "/" + song;
            var textInfo = CultureInfo.CurrentCulture.TextInfo;
            var lyrics = new SongLyrics
            {
                Artist = textInfo.ToTitleCase(artist),
                SongTitle = textInfo.ToTitleCase(song),
                Lyrics = ""
            };

            var client = new HttpClient();
            var response = await client.GetAsync(apiURL);
            if (response.IsSuccessStatusCode)
            {
                lyrics.Lyrics = await response.Content.ReadAsStringAsync();
            }

            return lyrics;
        }

    }
}