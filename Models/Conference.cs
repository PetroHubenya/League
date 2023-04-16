namespace League.Models
{
  public class Conference
  {
    public string LeagueId { get; set; }
    public string ConferenceId { get; set; }
    public string Name { get; set; }

    public League League { get; set; }
  }
}
