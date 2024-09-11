namespace MedPortal.Models
{
    public class Personal
    {
        public int IdPersonal { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string CodigoMinsa { get; set; }
        public string Especialidad { get; set; }
        public int Rol { get; set; }

        public Personal()
        {
   
        }

        public Personal(int idPersonal, string nombres, string apellidos, string username, string password, string codigoMinsa, string especialidad, int rol)
        {
            IdPersonal = idPersonal;
            Nombres = nombres;
            Apellidos = apellidos;
            Username = username;
            Password = password;
            CodigoMinsa = codigoMinsa;
            Especialidad = especialidad;
            Rol = rol;
        }


    }
}
