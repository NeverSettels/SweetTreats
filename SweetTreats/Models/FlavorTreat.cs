namespace Library.Models
{
  public class AuthorBook
  {
    public int FlavorTreatId { get; set; }
    public int FlavorId { get; set; }
    public int TreatId { get; set; }
    public Treat Treat { get; set; }
    public Flavor Flavor { get; set; }
  }
}