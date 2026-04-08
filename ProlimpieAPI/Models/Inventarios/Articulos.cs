using ProlimpieAPI.Models.SysAdmin;

namespace ProlimpieAPI.Models.Inventarios
{
    public class Articulos
    {
        public int Id { get; set;  }
        public required string ClaveProducto { get; set;  }
        public required string Descripcion { get; set; }
        public required int PresentacionesId { get; set; }
        public required int UindadesMedidasId { get; set;  }
        public required bool Activo { get; set; }
        public int? CreatedById { get; set;  }
        public required DateTime CreatedAt { get; set; }
        public int? UpdatedById { get; set;  }
        public required DateTime UpdatedAt { get; set; }

        // Relaciones de navegación
        public required Presentaciones Presentacion { get; set; }
        public required UnidadesMedidas UnidadMedida { get; set; }
        public ApplicationUser? CreatedBy { get; set; }
        public ApplicationUser? UpdatedBy { get; set; }
    }
}
