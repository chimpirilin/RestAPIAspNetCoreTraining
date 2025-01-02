using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestApi.Entities {
    public class Orders(DateTime date, decimal total) {
        [Key]
        public int id { get; set; }

        [Required]
        public DateTime date { get; set; } = date;

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "El total debe ser positivo")]
        public decimal total { get; set; } = total;
        public int userId { get; set; }
         [ForeignKey("userId")]
        public virtual Users users { get; set; }
    }
}