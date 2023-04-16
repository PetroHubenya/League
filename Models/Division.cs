namespace League.Models
{
  public class Division
  {
    public string ConferenceId { get; set; }
    public string DivisionId { get; set; }
    public string Name { get; set; }

    public Conference Conference { get; set; }
  }
}
