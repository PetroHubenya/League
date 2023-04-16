using League.Data;
using League.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace League.Pages.Teams
{
    public class DetailsModel : PageModel
    {
        private readonly LeagueContext _context;
        public DetailsModel( LeagueContext context )
        {
            _context = context;
        }
        public Team Team { get; set; }
        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                Team = await _context.Teams
                .Include(p => p.Players)
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.TeamId == id);
            }

            if (Team == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
