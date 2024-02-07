using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicDatabase.Contexts;
using MusicDatabase.Models;

namespace MusicDatabase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private readonly ArtistContext _musicDbContext;
        
        public ArtistsController(ArtistContext musicDbContext)
        {
            _musicDbContext = musicDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Artist>>> GetArtists()
        {
            return await _musicDbContext.Artists.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Artist>> GetArtist(long id)
        {
            var artist = await _musicDbContext.Artists.FindAsync(id);
            if (artist == null)
            {
                return NotFound();
            }
            return artist;
        }

        [HttpPost]
        public async Task<ActionResult<Artist>> PostArtist(Artist artist)
        {
            _musicDbContext.Artists.Add(artist);
            await _musicDbContext.SaveChangesAsync();
            return CreatedAtAction("GetArtist", new { id = artist.Id }, artist);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtist(long id)
        {
            var artist = await _musicDbContext.Artists.FindAsync(id);
            if (artist == null)
            {
                return NotFound();
            }
            _musicDbContext.Artists.Remove(artist);
            await _musicDbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
