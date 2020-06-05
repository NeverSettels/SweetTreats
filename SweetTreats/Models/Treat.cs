using System.Collections.Generic;

namespace SweetTreats.Models
{
  public class Treat
  {
    public Treat()
    {
      this.Flavors = new HashSet<FlavorTreat>();
    }
    public int TreatId { get; set; }
    public string Name { get; set; }
    public string Price  { get; set; }
    public virtual ICollection<FlavorTreat> Flavors { get; set; }

  }
}