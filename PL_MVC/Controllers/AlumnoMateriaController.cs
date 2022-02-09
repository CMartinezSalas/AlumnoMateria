using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class AlumnoMateriaController : Controller
    {
        // GET: AlumnoMateria
        public ActionResult GetAll()
        {
            ML.Result result = BL.Alumno.GetAll();
            ML.Alumno alumno = new ML.Alumno();

            alumno.Alumnos = result.Objects;

            return View(alumno);
        }

        public ActionResult Asignadas(int IdAlumno)
        {
            ML.Result result = BL.AlumnoMateria.MateriasGetAsignadas(IdAlumno);
            ML.AlumnoMateria alumnoMateria = new ML.AlumnoMateria();

            ML.Result resultAlumno = BL.Alumno.GetById(IdAlumno);

            alumnoMateria.alumnoMaterias = result.Objects;
            alumnoMateria.Alumno = ((ML.Alumno)resultAlumno.Object);

            return View(alumnoMateria);
        }

        public ActionResult NoAsignadas(int IdAlumno)
        {
            ML.Result result = BL.AlumnoMateria.MateriasGetNoAsignadas(IdAlumno);
            ML.Result resultAlumno = BL.Alumno.GetById(IdAlumno);
            ML.Materia materia = new ML.Materia();
            ML.AlumnoMateria alumnoMateria = new ML.AlumnoMateria();

            //ML.Result resultAlumno = BL.Alumno.GetById(IdAlumno);

            alumnoMateria.alumnoMaterias = result.Objects;
            alumnoMateria.Alumno = ((ML.Alumno)resultAlumno.Object);

            return View(alumnoMateria);
        }

        [HttpPost]
        public ActionResult AlumnoMateriaAdd(ML.AlumnoMateria alumnoMateria)
        {
            ML.Result result = new ML.Result();

             foreach (string alumnoMaterias in alumnoMateria.alumnoMaterias){
                 int idMateria = int.Parse(alumnoMaterias);

            result = BL.AlumnoMateria.AlumnoMateriaAdd(alumnoMateria.Alumno.IdAlumno,idMateria);
                if (result.Correct)
                {
                    ViewBag.Mensaje = "Se ha registrado con éxito.";
                }
                else
                {
                    ViewBag.Mensaje = "La materia no se ha registrado con éxito." + result.ErrorMessage;
                }
                 }

            return PartialView("ModalPV");
        }

        [HttpGet]
        public ActionResult AlumnoMateriaDelete(int IdAlumnoMateria)
        {
            ML.Result result = BL.AlumnoMateria.AlumnoMateriaDelete(IdAlumnoMateria);

            if (result.Correct)
            {
                ViewBag.Mensaje = "La materia se ha retirado correctamente";
            }
            else
            {
                ViewBag.Mensaje = "La materia no se ha eliminado correctamente " + result.ErrorMessage;
            }

            return PartialView("ModalPV");
        }
    }
}