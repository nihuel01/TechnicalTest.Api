using System;

namespace TechnicalTest.Core.Model
{
    public class tUserPeliculaRent : Entity
    {
        public int cod_userPeliculaRent { get; set; }
        public string observaciones { get; set; }
        public decimal precio_alquiler { get; set; }
        public DateTime fecha_alquiler { get; set; }
        public DateTime? fecha_devolucion { get; set; }
        public bool devuelta { get; set; }
        public int cod_usuario { get; set; }
        public int cod_pelicula { get; set; }
        public DateTime fecha_limite { get; set; }
    }
}
