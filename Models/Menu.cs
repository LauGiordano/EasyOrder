using System.ComponentModel.DataAnnotations;

namespace EasyOrder.Models
{
    public class Menu
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido.")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El precio es requerido.")]
        [Display(Name = "Precio")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "La descripción es requerida.")]
        [Display(Name = "Descripción")]
        public string Description { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
