using System;

namespace TechnicalTest.Core.Model
{
    public class tUserPeliculaSell : Entity
    {
        public int cod_userPeliculaSell { get; set; }
        public string observaciones { get; set; }
        public decimal precio_venta { get; set; }
        public DateTime fecha_venta { get; set; }
        public int cod_usuario { get; set; }
        public int cod_pelicula { get; set; }
    }
}
