namespace TechnicalTest.Core.Model
{
    public class tPelicula : Entity
    {
        public int cod_pelicula { get; set; }
        public string txt_desc { get; set; }
        public string cant_disponibles_alquiler { get; set; }
        public string cant_disponibles_venta { get; set; }
        public string precio_alquiler { get; set; }
        public string precio_venta { get; set; }
    }
}
