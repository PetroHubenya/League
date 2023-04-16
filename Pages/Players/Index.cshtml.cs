using League.Data;
using League.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace League.Pages.Players
{
    public class IndexModel : PageModel
    {
        private readonly LeagueContext _context;
		public List<Player> Players { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public string SortField { get; set; } = "TeamId";

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        // To filter by position.
        public SelectList Positions { get; set; }

        // To save filtered position.
        [BindProperty(SupportsGet = true)]
        public string SelectedPosition { get; set; }

        // To filter by team.
        public SelectList TeamSelectList { get; set; }

        // To save filtered team.
        [BindProperty(SupportsGet = true)]
        public string SelectedTeam { get; set; }

        // To highlite your favorite team with gold background.
        [BindProperty(SupportsGet = true)]
        public string FavoriteTeam { get; set; }
        
        public string FavoriteTeamId { get; set; }

		public IndexModel(LeagueContext context)
        {
            _context = context;
        }
        
		public async Task OnGetAsync()
        {
            var players = from p in _context.Players
                          select p;

            // Filter by team.
            IQueryable<string> teamsQuery = from t in _context.Teams select t.Name;

            TeamSelectList = new SelectList(await teamsQuery.OrderBy(x => x).ToListAsync());

            if (!string.IsNullOrEmpty(SelectedTeam))
            {
                var team = (from t in _context.Teams
                            where t.Name == SelectedTeam
                            select t.TeamId)
                            .FirstOrDefault();
                
				players = from p in players
                          where p.TeamId == team
						  select p;
            }

            // Filter by position.
            IQueryable<string> positionsQuery = (from p in _context.Players select p.Position).Distinct();

			Positions = new SelectList(await positionsQuery.OrderBy(x => x).ToListAsync());

            if (!string.IsNullOrEmpty(SelectedPosition))
            {
				players = from p in players
						  where p.Position == SelectedPosition
						  select p;
			}            

			// Search player by name.
			if (!string.IsNullOrEmpty(SearchString))
            {
                players = from p in players
                          where p.Name.Contains(SearchString)
                          select p;
            }

			// Sort players by Name, Rank or Rating.
			switch (SortField)
			{
				case "Name":
					players = players.OrderBy(p => p.Name);
					break;
				case "Rank":
					players = players.OrderBy(p => p.Rank);
					break;
				case "Rating":
					players = players.OrderBy(p => p.Rating);
					break;
			}

			// To highlite your favorite team with gold background.
            if (!string.IsNullOrEmpty(FavoriteTeam))
            {
                var favoriteTeamId = (from t in _context.Teams
                                      where t.Name == FavoriteTeam
                                      select t.TeamId)
                                      .FirstOrDefault();
				
                FavoriteTeamId = favoriteTeamId;
			}

			Players = await players.ToListAsync();            
        }
    }
}
