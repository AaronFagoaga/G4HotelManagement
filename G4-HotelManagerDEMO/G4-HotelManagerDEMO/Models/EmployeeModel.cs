using System.ComponentModel.DataAnnotations;

namespace G4_HotelManagerDEMO.Models
{
    public class EmployeeModel
    {
        public int IdEmployee { get; set; }

        [Required(ErrorMessage = "Ingrese el nombre del empleado")]
        public string emploName { get; set; }

        [Required(ErrorMessage = "Ingrese el apellido del empleado")]
        public string emploLastName { get; set; }

        [Required(ErrorMessage = "Ingrese el trabajo del empleado")]
        public string emploJob {  get; set; }

        public int emploAge { get; set; }

        [EmailAddress(ErrorMessage = "Ingrese un correo eléctronico válido.")]
        public string emploEmail { get; set; }

        [RegularExpression(@"^\d{4}-\d{4}$", ErrorMessage = "El formato del teléfono debe ser ####-####.")]
        public string emploPhone { get; set; }
    }
}
