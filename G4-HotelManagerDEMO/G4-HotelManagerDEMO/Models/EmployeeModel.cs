using System.ComponentModel.DataAnnotations;

namespace G4_HotelManagerDEMO.Models
{
    public class EmployeeModel
    {
        public int IdEmployee { get; set; }

        [Required(ErrorMessage = "Ingrese el nombre del empleado")]
		[Display(Name = "Nombre")]
		[RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El nombre no debe contener números")]
		public string emploName { get; set; }

        [Required(ErrorMessage = "Ingrese el apellido del empleado")]
		[Display(Name = "Apellido")]
		[RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El apellido no debe contener números")]
		public string emploLastName { get; set; }

        [Required(ErrorMessage = "Ingrese el trabajo del empleado")]
		[Display(Name = "Cargo")]
		public string emploJob {  get; set; }

		[RegularExpression(@"^(?:[1-9][0-9]?|100)$", ErrorMessage = "Ingrese una edad real.")]
		[Display(Name = "Edad")]
		public int emploAge { get; set; }

        [EmailAddress(ErrorMessage = "Ingrese un correo eléctronico válido.")]
		[Display(Name = "Correo eléctronico")]
		public string emploEmail { get; set; }

        [RegularExpression(@"^\d{4}-\d{4}$", ErrorMessage = "El formato del teléfono debe ser ####-####.")]
		[Display(Name = "Teléfono")]
		public string emploPhone { get; set; }
    }
}
