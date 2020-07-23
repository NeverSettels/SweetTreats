namespace SweetTreats.Models
{
  public class Checkout
    {       
        public int CheckoutId { get; set; }
        public int FlavorId { get; set; }
        public int ClientId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public Flavor Flavor { get; set; }
        public Client Client { get; set; }
    }
}