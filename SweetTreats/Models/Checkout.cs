namespace Pierres.Models
{
  public class Checkout
    {       
        public int CheckoutId { get; set; }
        public int FlavorId { get; set; }
        public int PatronId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public Flavor Flavor { get; set; }
        public Patron Patron { get; set; }
    }
}