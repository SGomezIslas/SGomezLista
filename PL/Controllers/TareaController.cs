using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class TareaController : Controller
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            Dictionary<string, object> objeto = BL.Usuario.GetAll();
            bool resultado = (bool)objeto["Resultado"];
            if (resultado)
            {
                ML.Usuario usuario = new ML.Usuario();
                usuario = (ML.Usuario)objeto["Usuario"];
                return View(usuario);
            }
            else
            {
                string excepcion = (string)objeto["Excepcion"];
                ViewBag.Mensaje = $"Ocurrio un error {excepcion}";
                return View(excepcion);
            }
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
