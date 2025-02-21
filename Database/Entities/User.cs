using System.Collections.Generic;

namespace Database.Entities
{
    public class User
    {
        public int Id { get; set; } // Primary Key
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int TipoUsuario { get; set; }

        public ICollection<Consultorio> Consultorios { get; set; }
    }
}
