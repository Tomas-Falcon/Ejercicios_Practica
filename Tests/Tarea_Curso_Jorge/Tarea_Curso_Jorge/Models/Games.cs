namespace Tarea_Curso_Jorge.Models
{
   public class Games
    {
        public Games(int id, string titulo, int puntuacion, float precio)
        {
            Id = id;
            Titulo = titulo;
            Puntuacion = puntuacion;
            Precio = precio;
        }


        public Games(string titulo, int puntuacion, float precio)
        {
            Titulo = titulo;
            Puntuacion = puntuacion;
            Precio = precio;
        }

        public Games()
        {
        }

        public int Id { get; set; }
        public string Titulo { get; set; }
        public int Puntuacion { get; set; }
        public float Precio { get; set; }
    }
}
