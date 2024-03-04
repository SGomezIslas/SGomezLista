using DL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Usuario
    {
        public static Dictionary<string, object> Add(ML.Usuario usuario)
        {
            string exepcion = "";
            Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Exepcion", exepcion }, { "Resultado", false } };

            try
            {
                using (DL.SgomezListaContext context = new DL.SgomezListaContext())
                {
                    int filasAfectadas = context.Database.ExecuteSqlRaw($"UsuarioAdd '{usuario.Nombre}','{usuario.Email}',{usuario.Password}");

                    if (filasAfectadas > 0)
                    {
                        diccionario["Resultado"] = true;
                        diccionario["Usuario"] = usuario;
                    }
                    else
                    {
                    }
                }
            }
            catch (Exception ex)
            {
                diccionario["Resultado"] = false;
                diccionario["Exepcion"] = ex.Message;
            }
            return diccionario;
        }
        public static Dictionary<string, object> GetAll()
        {
            ML.Usuario usuario = new ML.Usuario();
            string excepcion = "";
            Dictionary<string, object> diccionario = new Dictionary<string, object> { { "Usuario", usuario }, { "Excepcion", excepcion }, { "Resultado", false } };
            try
            {
                using (DL.SgomezListaContext context = new DL.SgomezListaContext())
                {
                    var Usuarios = (from user in context.Usuarios
                                    join tTarea in context.Tareas on user.IdTarea equals tTarea.IdTarea
                                    join tStatus in context.Statuses on tTarea.IdStatus equals tStatus.IdStatus
                                    select new
                                    {

                                        IdUsuario = user.IdUsuario,
                                        Nombre = user.Nombre,
                                        Titulo = tTarea.Titulo,
                                        Descripcion = tTarea.Descripcion,
                                        FechaVencimiento = tTarea.FechaVencimiento,
                                        Estado = tStatus.Estado,
                                    }).ToList();
                    if (Usuarios.Count > 0)
                    {
                        usuario.Usuarios = new List<ML.Usuario>();
                        foreach (var registro in Usuarios)
                        {
                            ML.Usuario usuario1 = new ML.Usuario();
                            usuario1.IdUsuario = registro.IdUsuario;
                            usuario1.Nombre = registro.Nombre;
                            usuario1.Tarea = new ML.Tarea();
                            usuario1.Tarea.Titulo = registro.Titulo;
                            usuario1.Tarea.Descripcion = registro.Descripcion;
                            usuario1.Tarea.FechaVencimiento = (DateTime)registro.FechaVencimiento;
                            usuario1.Status = new ML.Status();
                            usuario1.Status.Estado = registro.Estado;
                        }
                        diccionario["Resultado"] = true;
                        diccionario["Usuario"] = usuario;
                    }
                    else
                    {
                        diccionario["Resultado"] = false;
                    }
                }
            }
            catch (Exception ex)
            {
                diccionario["Resultado"] = false;
                diccionario["Excepcion"] = ex.Message;
            }
            return diccionario;
        }
    }
}
