using System.ComponentModel.DataAnnotations;

namespace Flicks.Models
{
    public class PeliculaViewModel
    {
        [ScaffoldColumn(false)]
        public int NumReferencia { get; set;  }

        [Display(Prompt = "Describa la película", Description= "Descripción de la película", Name = "Descripción")]
        [Required(ErrorMessage ="Debe indicar un nombre para la película")]
        [StringLength(maximumLength:200, ErrorMessage ="Ls descripción no puede ser de más de 200 caracteres")]

        public string Descripcion { get; set; }

        [Display(Prompt = "Indique el precio de la película", Description = "Precio de la película en euros", Name = "Precio")]
        [Required(ErrorMessage = "Debe indicar un precio para la película")]
        [DataType(DataType.Currency, ErrorMessage = "El precio debe ser un valor numérico")]
        [Range(minimum:0, maximum:10000, ErrorMessage ="El precio debe estar entre 0 y 10.000 euros")]

        public double Precio { get; set; }



        [Display(Prompt = "Indique el stock disponible", Description = "Número de unidades disponibles", Name = "Stock")]
        [Required(ErrorMessage = "Debe indicar el stock disponible")]
        [Range(minimum: 0, maximum: 1000, ErrorMessage = "El stock debe estar entre 0 y 1000 unidades")]
        //[RegularExpression("([0-9]+)"), ErrorMessage = "El stock debe ser un número entero"]
        public int Stock { get; set; }


    }
}
