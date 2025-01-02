using System.ComponentModel.DataAnnotations;

namespace RestApi.Entities {
    public class Products(string name, string description, decimal price) {
        [Key]
        public int id { get; set; }
        [StringLength(100,  MinimumLength = 2, ErrorMessage = "El nombre debe tener de 2 a 100 caracteres")]
        public string name { get; set; } = name;
        
        [StringLength(500, ErrorMessage = "La descripcion no debe exceder 500 caracteres")]
        public string description { get; set; } = description;

        [Required]
        [Range(0, 1000000, ErrorMessage = "El precio debe estar entre 0 y 1000000")]
        public decimal price { get; set; } = price; 
    }
}