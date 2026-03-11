using System.ComponentModel.DataAnnotations;
using System.Timers;

namespace Abstracciones.Modelos
{
    public class VehiculoBase
    {
        [Required(ErrorMessage="La propiedad placa es requerida")]
        [RegularExpression(@"[A-Za-z]{3}-[0-9]{3}", ErrorMessage= "El formato de la placa debe ser: 'ABC-###'")]
        public string placa { get; set; }

        [Required(ErrorMessage ="La propiedad color es requerida")]
        [StringLength(40, ErrorMessage ="La propiedad color debe ser mayor a 4 caracteres y menos de 40", MinimumLength =4)]
        public string color { get; set; }

        [Required(ErrorMessage = "La propiedad año es requerida")]
        [RegularExpression(@"(19|20)\d\d", ErrorMessage = "El formato del año no es válido" )]
        public int anio { get; set; }

        [Required(ErrorMessage = "La propiedad precio es requerida")]
        public Decimal precio { get; set; }

        [Required(ErrorMessage = "La propiedad correo es requerida")]
        [EmailAddress]
        public string correoPropietario { get; set; }

        [Required(ErrorMessage = "La propiedad teléfono es requerida")]
        [Phone]
        public string telefonoPropietario { get; set; }
    }
    public class VehiculoRequest : VehiculoBase
    {
        public Guid Idmodelo { get; set; }
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
