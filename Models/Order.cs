using System.ComponentModel.DataAnnotations;

namespace EasyOrder.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El precio es requerido.")]
        [Display(Name = "Precio")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "El Nro. Mesa es requerido.")]
        [Range(0, 20, ErrorMessage = "El Nro. Mesa debe estar entre 0 y 20.")]
        [Display(Name = "Nro. Mesa")]
        public int Ntable { get; set; }

        [Required(ErrorMessage = "El Menu elegido es requerido.")]
        [Display(Name = "Menu elegido")]
        public int MenuId { get; set; }
        public Menu Menu { get; set; }

        [Required(ErrorMessage = "Las observaciones son requeridas.")]
        [Display(Name = "Observaciones")]
        public string Comments { get; set; }

        [Required(ErrorMessage = "La fecha de creación es requerida.")]
        [Display(Name = "Fecha de creación")]
        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }

        [Required(ErrorMessage = "El usuario es requerido.")]
        [Display(Name = "Usuario")]
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
