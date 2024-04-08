using System.ComponentModel.DataAnnotations;

namespace G4_HotelManagerDEMO.Models
{
    public class ClientModel
    {
        public int IdClient { get; set; }

        [Required(ErrorMessage = "Ingrese el nombre del Cliente")]
		[Display(Name = "Nombre")]
		[RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El nombre no debe contener números")]
		public string clientName { get; set; }

        [Required(ErrorMessage = "Ingrese el apellido del cliente")]
		[Display(Name = "Apellido")]
		[RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El apellido no debe contener números")]
		public string clientLastName { get; set; }

		[RegularExpression(@"^(?:[1-9][0-9]?|100)$", ErrorMessage = "Ingrese una edad real.")]
		[Display(Name = "Edad")]
		public int clientAge { get; set; }

        [EmailAddress(ErrorMessage = "Ingrese un correo eléctronico válido.")]
		[Display(Name = "Correo")]
		public string clientEmail { get; set; }

        [RegularExpression(@"^\d{4}-\d{4}$", ErrorMessage = "El formato del teléfono debe ser ####-####.")]
		[Display(Name = "Telefono")]
		public string clientPhone { get; set; }

    }
}
