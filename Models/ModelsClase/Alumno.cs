using APS_Eq_TeamAltF4_U3.Exceptions;
namespace APS_Eq_TeamAltF4_U3.Models.ModelsClase
{
    public class Alumno : IComparable<Alumno>
    {
        //Atributos
        private long matricula;
        private string nombre;
        private double calificacion;


        //Propiedades
        public long Matricula
        {
            //Regla de negocio es que la matricula tiene que tener 
            //obligatoriamente 4 digitos

            get => matricula;
            set
            {
                if (value < 1000 || value > 9999)
                {
                    //throw new ArgumentException("Matricula debe tener 4 digitos");
                    throw new MatriculaException("La matricula no debe tener más de 4 digitos");
                }

                matricula = value;

            }
        }
        public string Nombre
        {
            get => nombre;
            set
            {
                if (value.Length > 100)
                {
                    throw new NameFormatException("Longitud del nombre excedida");
                }

                if (value.Contains("@"))
                {
                    throw new ArgumentException("Caracter especial encontrado");
                }

                nombre = value;

            }
        }

        public double Calificacion
        {
            get => calificacion;
            set => calificacion = value;
        }
        //Constructor
        public Alumno(long matricula, string nombre)
        {
            Matricula = matricula;
            Nombre = nombre;
        }

        public Alumno(long matricula)
        {
            Matricula = matricula;
        }

        public Alumno(long matricula, string nombre, double calificacion)
        {
            Matricula = matricula;
            Nombre = nombre;
            Calificacion = calificacion;
        }

        public Alumno()
        {
        }

        //ToString
        public int CompareTo(Alumno? other)
        {
            return //this.Matricula-other.Matricula;
                Matricula.CompareTo(other.Matricula);
        }

        public override string ToString()
        {
            return "(" + Matricula.ToString() + ") - " + Nombre;
        }

    }
}
