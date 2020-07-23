using System.Collections.Generic;

namespace SweetTreats.Models
{
  public class Client
    {
        public Client()
        {
          this.Flavors = new HashSet<Checkout>();
        }

        public int ClientId { get; set; }
        public string ClientName { get; set; }
         public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Checkout> Flavors { get; set; }
    }
}