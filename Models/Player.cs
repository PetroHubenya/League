using System;

namespace League.Models
{
  public class Player
  {
    public string PlayerId { get; set; }
    public string TeamId { get; set; }
    public int Number { get; set; }
    public string Position { get; set; }
    public string Name { get; set; }
    public int? Height { get; set; }
    public int? Weight { get; set; }
    public int? Age { get; set; }
    public DateTime? BirthDate { get; set; }
    public string Experience { get; set; }
    public int? DraftYear { get; set; }
    public int? DraftRound { get; set; }
    public int? DraftPick { get; set; }
    public string College { get; set; }
    public string State { get; set; }
    public int? Rank { get; set; }
    public int? Rating { get; set; }
    public int? Depth { get; set; }

    public Team Team { get; set; }
  }
}
