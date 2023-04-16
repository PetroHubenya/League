using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using League.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace League.Pages
{
  public class IndexModel : PageModel
  {
    private readonly LeagueContext _context;
    public IndexModel(LeagueContext context)
        {
            _context = context; 
        }
    public Models.League League { get; set; }
    public async Task OnGetAsync()
    {
            League = await _context.Leagues.FirstOrDefaultAsync();
    }
  }
}
