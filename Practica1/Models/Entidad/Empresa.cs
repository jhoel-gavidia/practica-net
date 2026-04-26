using System.ComponentModel.DataAnnotations;

namespace Practica1.Models.Entidad
{
    public class Empresa
    {
        [Key]
        public int IdEmpresa { get; set; }

        [Required(ErrorMessage = "Debe Ingresar la Razon Social de la empresa")]
        [MaxLength(25)]
        [Display(Name = "Razon Social")]
        public string RazonSocial { get; set; }

        [Required(ErrorMessage = "Debe Ingresar el RUC de la empresa")]
        [MaxLength(11)]
        [Display(Name = "RUC")]
        public string RUC { get; set; }
        public string Direccion { get; set; }
        public virtual ICollection<Colaborador> Colaborador { get; set; }

    }
}
