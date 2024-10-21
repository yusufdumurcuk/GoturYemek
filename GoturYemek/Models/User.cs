using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoturYemek.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Kullanıcı adı en fazla 100 karakter olmalıdır.")]
        public string Username { get; set; }
        
        [Required]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi girin.")]
        [StringLength(100, ErrorMessage = "E-posta en fazla 100 karakter olmalıdır.")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(255, MinimumLength = 6, ErrorMessage = "Şifre en az 6 karakter olmalıdır.")]
        [NotMapped] // Bu alanın veritabanında yer almadığını belirtir
        public string Password { get; set; } // Kullanıcının girdiği şifre

        // Şifre hash'ini saklamak için ek alan
        public string PasswordHash { get; set; }
    }
}
