using System.ComponentModel.DataAnnotations;

namespace G4_HotelManagerDEMO.Models
{
    public class HotelModel
    {
        public int IdHotel { get; set; }

        [Required(ErrorMessage = "Ingrese el nombre del hotel")]
        public string hotelName { get; set;}

        [Required(ErrorMessage = "La descripción del hotel es obligatoria.")]
        public string hotelInfo { get; set; }

        [RegularExpression(@"^\d{4}-\d{4}$", ErrorMessage = "El formato del teléfono debe ser ####-####.")]
        public string hotelPhone { get; set; }

        [EmailAddress(ErrorMessage = "Ingrese un correo eléctronico válido.")]
        public string hotelEmail { get; set; }

        [Required(ErrorMessage = "La dirección del hotel es obligatoria.")]
        public string hotelAddress { get; set; }

        [Required(ErrorMessage = "Ingrese la categoria del hotel.")]
        public string hotelCategory { get; set; }

    }
}
