using System.ComponentModel.DataAnnotations;

namespace G4_HotelManagerDEMO.Models
{
    public class RoomTypeModel
    {
        public int IdType { get; set; }

		[Required(ErrorMessage = "Ingrese el nombre")]
		[Display(Name = "Nombre")]
		public string typeName { get; set; }

		[Required(ErrorMessage = "Ingrese una breve descripción del tipo de habitación")]
		[Display(Name = "Información")]
		public string typeInfo { get; set; }

		[Required(ErrorMessage = "Ingrese una breve descripción de la capacidad")]
		[Display(Name = "Capacidad")]
		public string typeCapacity { get; set; }
    }
}
