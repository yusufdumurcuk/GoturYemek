namespace GoturYemek.Models
{
    public class Food
    {
        public int Id { get; set; }                  // Yemek ID
        public int RestaurantId { get; set; }         // Hangi restorana ait olduğu
        public string Name { get; set; }              // Yemek adı
        public decimal Price { get; set; }            // Yemek fiyatı
        public string Category { get; set; }          // Yemek kategorisi

        public Restaurant Restaurant { get; set; }    // İlişki: Bir yemek bir restorana ait
    }
}
