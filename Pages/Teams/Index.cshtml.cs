using League.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using League.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace League.Pages.Teams
{
    public class IndexModel : PageModel
    {
        private readonly LeagueContext _context;

        public List<Team> Teams { get; set; }
        public List<Conference> Conferences { get; set; }

        public List<Division> Divisions { get; set; }

        [BindProperty(SupportsGet = true)]
        public string FavoriteTeam { get; set; }

        public SelectList TeamsSelectList { get; set; }

        public IndexModel(LeagueContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {
            if (_context.Teams != null)
            {
                var teams = _context.Teams.OrderBy(t => t.Loss);

				// LINQ is used to gather all continents while sorting then alphabetically:
                IQueryable<string> teamsQuery = from t in _context.Teams
                                              orderby t.Name
											  select t.Name;

                TeamsSelectList = new SelectList(await  teamsQuery.ToListAsync());

				Teams = await teams.ToListAsync();
			}
            if (_context.Conferences != null)
            {
                Conferences = await _context.Conferences.ToListAsync();
            }
            if (_context?.Divisions != null)
            {
                Divisions = await _context.Divisions.ToListAsync();
            }
        }
    }
}
