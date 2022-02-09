using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class AlumnoController : Controller
    {
        // GET: Alumno
        public ActionResult GetAll()
        {
            ML.Result result = BL.Alumno.GetAll();
            ML.Alumno alumno = new ML.Alumno();

            alumno.Alumnos = result.Objects;

            return View(alumno);
        }
        [HttpGet]
        public ActionResult Form(int? IdAlumno)
        {
            ML.Alumno alumno = new ML.Alumno();

            if (IdAlumno == null) //Add
            {
                return View(alumno);
            }
            else //Update
            {
                ML.Result result = new ML.Result();

                result = BL.Alumno.GetById(IdAlumno.Value);

                if (result.Correct)
                {
                    alumno = ((ML.Alumno)result.Object);
                    return View(alumno);
                }
                else
                {

                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult Form(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();

            if (ModelState.IsValid)
            {

                if (alumno.IdAlumno == 0)
                {
                    result = BL.Alumno.Add(alumno);
                    if (result.Correct)
                    {
                        ViewBag.Mensaje = "Se ha registrado con éxito.";
                    }
                    else
                    {
                        ViewBag.Mensaje = "La alumno no se ha registrado con éxito." + result.ErrorMessage;
                    }
                }
                else
                {
                    result = BL.Alumno.Update(alumno);

                    if (result.Correct)
                    {
                        ViewBag.Mensaje = "El Alumno se ha actualizado correctamente.";
                    }
                    else
                    {
                        ViewBag.Mensaje = "El Alumno no se ha actualizado correctamente." + result.ErrorMessage;

                    }

                }
            }
            else
            {
                return View(alumno);
            }
            return PartialView("ModalPV");
        }
        public ActionResult Delete(int IdAlumno)
        {
            ML.Result result = BL.Alumno.Delete(IdAlumno);

            if (result.Correct)
            {
                ViewBag.Mensaje = "El Alumno se ha eliminado correctamente";
            }
            else
            {
                ViewBag.Mensaje = "El Alumno no se ha eliminado correctamente " + result.ErrorMessage;
            }

            return PartialView("ModalPV");
        }
    }
}