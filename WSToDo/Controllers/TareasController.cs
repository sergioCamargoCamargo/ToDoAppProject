using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WSToDo.Models;
using WSToDo.Request;
using WSToDo.Response;

namespace WSToDo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareasController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            TareaResponse oRespuesta = new TareaResponse();
            try
            {
                using (ToDoContext db = new ToDoContext())
                {
                    var lst = db.Tareas.OrderByDescending(d => d.IdTarea).ToList();
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = lst;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpPost]
        public IActionResult Add(TareaDtoRequest oModel)
        {
            TareaResponse oRespuesta = new TareaResponse();
            try
            {
                using (ToDoContext db = new ToDoContext())
                {


                    Tarea oTarea = new Tarea();

                    oTarea.TituloTarea = oModel.TituloTarea;
                    oTarea.Descripcion = oModel.Descripcion;
                    oTarea.Estado = oModel.Estado;
                    db.Tareas.Add(oTarea);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }

            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }

            return Ok(oRespuesta);
        }

        [HttpPut]
        public IActionResult Edit(TareaDtoRequest oModel)
        {
            TareaResponse oRespuesta = new TareaResponse();
            try
            {
                using (ToDoContext db = new ToDoContext())
                {
                    Tarea oTarea = db.Tareas.Find(oModel.IdTarea);
                    oTarea.TituloTarea = oModel.TituloTarea;
                    oTarea.Descripcion = oModel.Descripcion;
                    oTarea.Estado = oModel.Estado;
                    db.Entry(oTarea).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }

            return Ok(oRespuesta);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            TareaResponse oRespuesta = new TareaResponse();
            try
            {
                using (ToDoContext db = new ToDoContext())
                {
                    Tarea oTarea = db.Tareas.Find(Id);
                    db.Remove(oTarea);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }

            return Ok(oRespuesta);
        }

    }
}
