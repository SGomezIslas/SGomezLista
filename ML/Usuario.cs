using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Usuario
    {
        public int IdUsuario { get; set; }  
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Password {  get; set; }
        public int IdTarea { get; set; }
        public List<Usuario> Usuarios { get; set; }
        public ML.Status Status { get; set; }
        public ML.Tarea Tarea { get; set; }
    }
}
