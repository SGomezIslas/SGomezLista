using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Tarea
    {
        public int IdTarea {  get; set; }
        public string Titulo {  get; set; }
        public string Descripcion {  get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string Estado {  get; set; }
        public List<Tarea> Tareas { get; set; }
        public ML.Status Status { get; set; }
    }
}
