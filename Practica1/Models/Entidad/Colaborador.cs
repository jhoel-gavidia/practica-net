using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practica1.Models.Entidad
{
    public class Colaborador
    {
        [Key]
        public int IdColaborador {  get; set; }

        
        [MaxLength(25, ErrorMessage = "No debe tener mas de 25 caracteres")]
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Debe ingresar el nombre del colaborador")]
        public string NombColaborador { get; set;}

        
        [MaxLength(25, ErrorMessage = "No debe tener mas de 25 caracteres")]
        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "Debe ingresar el apellido del colaborador")]
        public string ApeColaborador { get; set;}

        
        [MaxLength(8, ErrorMessage = "No debe tener mas de 8 caracteres")]
        [Display(Name = "DNI")]
        [Required(ErrorMessage = "Debe ingresar el DNI del colaborador")]
        public string DNI {  get; set;}

        [MaxLength(1, ErrorMessage = "No debe tener mas de 1 Caracter")]
        [Required]
        public string Sexo { get; set;}
        public string Direccion { get; set;}

        [Required]
        public int IdEmpresa { get; set;}

        [ForeignKey(nameof(IdEmpresa))]
        [ValidateNever]
        public virtual Empresa Empresa { get; set; }

        [Display(Name = "Registro")]
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
        [Display(Name = "Modificación")]
        public DateTime? FechaModificacion { get; set; }
    }
}
