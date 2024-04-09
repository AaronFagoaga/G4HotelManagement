using System.ComponentModel.DataAnnotations;

namespace G4_HotelManagerDEMO.Models
{
    public class RoomModel
    {
		[Required(ErrorMessage = "Ingrese un nombre para la habitación")]
		public int IdRoom { get; set; }

		[Required(ErrorMessage = "Ingrese un nombre para la habitación")]
		[Display(Name = "Nombre de la habitación")]
		public string roomName { get; set; }

		[Required(ErrorMessage = "Ingrese una breve descripción de la habitación")]
		[Display(Name = "Descripción de la habitación")]
		public string roomInfo { get; set; }

		[Required(ErrorMessage = "Seleccione un tipo de habitación válido")]
		[Display(Name = "Tipo de habitación")]
		public int IdType { get; set; }

		[Required(ErrorMessage = "Ingrese un precio válido para la habitación")]
        [RegularExpression(@"^\d+(\.\d+)?$", ErrorMessage = "El precio debe ser un número válido")]
        [Display(Name = "Precio de la habitación")]
		public decimal roomPrice { get; set; }

		[Required(ErrorMessage = "Ingrese el estado de la habitación (disponible/no disponible)")]
		[Display(Name = "Estado de la habitación")]
		public string roomStatus { get; set; }

		[Required(ErrorMessage = "Seleccione un hotel válido")]
		[Display(Name = "Hotel")]
		public int IdHotel { get; set; }

		public RoomTypeModel? RoomType { get; set; }

		public HotelModel? Hotel { get; set; }
	}
}
