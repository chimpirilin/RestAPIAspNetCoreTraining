using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestApi.Entities {
    public class OrdersDetails(int quantity, decimal subTotal) {
        [Key]
        public int id { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Cantidad debe ser al menos 1")]
        public int quantity { get; set; } = quantity;
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Subtotal debe ser positivo")]
        public decimal subTotal { get; set; } = subTotal;

         public int productId { get; set; }
         [ForeignKey("productId")]
        public virtual Products? products { get; set; }

        public int orderId { get; set; }
         [ForeignKey("orderId")]
        public virtual Orders? orders { get; set; }
    }
}