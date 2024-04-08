using System.ComponentModel.DataAnnotations;

namespace G4_HotelManagerDEMO.Models
{
    public class ReservationModel
    {
		public int IdReservation { get; set; }

		[Required(ErrorMessage = "No se ha seleccionado una habitación")]
		[Display(Name = "Habitación")]
		public int IdRoom { get; set; }

		[Required(ErrorMessage = "No se ha seleccionado huésped")]
		public int IdClient { get; set; }

		[Required(ErrorMessage = "Seleccione una fecha válida")]
		[Display(Name = "Fecha de llegada")]
		public DateTime arrivalDate { get; set; }

		[Display(Name = "Fecha de salida")]
		[Required(ErrorMessage = "Seleccione una fecha válida")]
		public DateTime exitDate { get; set; }

		[Required(ErrorMessage = "Ingrese un número válido para el precio de reserva")]
		[RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "El precio debe ser un número válido")]
		public decimal reservationPrice { get; set; }
		
        [Required(ErrorMessage = "No se ha seleccionado empleado")]
		[Display(Name = "Emplado")]
		public int IdEmployee { get; set; }

        public RoomModel? Room { get; set; }

        public ClientModel? Client { get; set; }

        public EmployeeModel? Employee { get; set; }
    }
}
