using System.Collections.Generic;

namespace SweetTreats.Models
{
  public class Flavor
  {
    public Flavor()
    {
      this.Treats = new HashSet<FlavorTreat>();
    }
    public int FlavorId { get; set; }
    public string Name { get; set; }

    public int TreatFlavorId { get; set; }
    public int PatronId { get; set; }

     public virtual ApplicationUser User { get; set; }
     
     public ICollection<Checkout> Patrons { get;}
    public virtual ICollection<FlavorTreat> Treats { get; set; }

  }
}