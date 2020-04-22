using Microsoft.AspNetCore.Mvc;
using NetCore.Playground.Api.Models;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;

namespace NetCore.Playground.Api.Controllers
{
    [ApiController]
    [Route("api/v1/lyrics/")]    
    public class LyricsController : ControllerBase
    {        
        public LyricsController()
        {            
        }

        /// <summary>
        /// Get lyrics from an Artist and a Song
        /// </summary>
        /// <param name="artist">Artist name</param>
        /// <param name="song">Song name</param>
        /// <returns>Lyrics of the song</returns>
        [HttpGet("{artist}/{song}")]
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

            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(apiURL);
            if (response.IsSuccessStatusCode)
            {
                lyrics.Lyrics = await response.Content.ReadAsStringAsync();
            }

            return lyrics;
        }

    }
}