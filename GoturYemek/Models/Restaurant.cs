namespace GoturYemek.Models
{
    public class Restaurant
    {
        public int Id { get; set; }                  // Restoran ID
        public string Name { get; set; }              // Restoran adı
        public ICollection<Food> Foods { get; set; }  // İlişki: Bir restoranın birden fazla yemeği olabilir
    }
}
