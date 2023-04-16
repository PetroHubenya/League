using League.Data;
using League.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace League.Pages.Players
{
    public class DetailsModel : PageModel
    {
        private readonly LeagueContext _context;

        public DetailsModel( LeagueContext context )
        {
            _context = context;
        }
        public Player Player { get; set; }
        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Player = await _context.Players.FindAsync(id);
            if (Player == null)
            {
                return RedirectToPage("./Teams/Details");
            }
            return Page();
        }
    }
}
