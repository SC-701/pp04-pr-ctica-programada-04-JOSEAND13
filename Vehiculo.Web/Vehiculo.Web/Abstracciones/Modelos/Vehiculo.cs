using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Abstracciones.Modelos
{
    public class VehiculoBase
    {
        [Required(ErrorMessage="La propiedad placa es requerida")]
        [RegularExpression(@"[A-Za-z]{3}-[0-9]{3}", ErrorMessage= "El formato de la placa debe ser: 'ABC-###'")]
        [DisplayName("Placa")]
        public string placa { get; set; }

        [Required(ErrorMessage ="La propiedad color es requerida")]
        [StringLength(40, ErrorMessage ="La propiedad color debe ser mayor a 4 caracteres y menos de 40", MinimumLength =4)]
        [DisplayName("Color")]
        public string color { get; set; }

        [Required(ErrorMessage = "La propiedad año es requerida")]
        [RegularExpression(@"(19|20)\d\d", ErrorMessage = "El formato del año no es válido" )]
        [DisplayName("Año")]
        public int anio { get; set; }

        [Required(ErrorMessage = "La propiedad precio es requerida")]
        [DisplayName("Precio")]
        public Decimal precio { get; set; }

        [Required(ErrorMessage = "La propiedad correo es requerida")]
        [EmailAddress]
        [DisplayName("Correo del Propietario")]
        public string correoPropietario { get; set; }

        [Required(ErrorMessage = "La propiedad teléfono es requerida")]
        [Phone]
        [DisplayName("Teléfono del Propietario")]
        public string telefonoPropietario { get; set; }
    }
    public class VehiculoRequest : VehiculoBase
    {
        public Guid IdModelo { get; set; }
    }  

    public class VehiculoResponse : VehiculoBase
    {
        public Guid Id { get; set; }
        public string? Modelo { get; set; }
        public string? Marca { get; set; }       
    }

    public class VehiculoDetalle : VehiculoResponse
    {
        public bool revisionValida { get; set; }
        public bool registroValido { get; set; }
    }
}
