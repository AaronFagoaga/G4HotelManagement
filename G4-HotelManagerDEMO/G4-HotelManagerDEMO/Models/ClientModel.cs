using System.ComponentModel.DataAnnotations;

namespace G4_HotelManagerDEMO.Models
{
    public class ClientModel
    {
        public int IdClient { get; set; }

        [Required(ErrorMessage = "Ingrese el nombre del Cliente")]
        public string clientName { get; set; }

        [Required(ErrorMessage = "Ingrese el apellido del cliente")]
        public string clientLastName { get; set; }

        public int clientAge { get; set; }

        [EmailAddress(ErrorMessage = "Ingrese un correo eléctronico válido.")]
        public string clientEmail { get; set; }

        [RegularExpression(@"^\d{4}-\d{4}$", ErrorMessage = "El formato del teléfono debe ser ####-####.")]
        public string clientPhone { get; set; }

    }
}
