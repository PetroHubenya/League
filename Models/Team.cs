using System.Collections.Generic;

namespace League.Models
{
  public class Team
  {
    public string DivisionId { get; set; }
    public string TeamId { get; set; }
    public string Location { get; set; }
    public string Name { get; set; }
    public int Win { get; set; }
    public int Loss { get; set; }
    public int Tie { get; set; }
    public int PointsFor { get; set; }
    public int PointsAgainst { get; set; }
    public string Stadium { get; set; }
    public int Capacity { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Zip { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public Division Division { get; set; }
    
    public ICollection<Player> Players { get; set; }
  }
}
