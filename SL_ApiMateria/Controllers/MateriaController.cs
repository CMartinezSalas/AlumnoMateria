using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL_ApiMateria.Controllers
{
    public class MateriaController : ApiController
    {
        [HttpGet]
        [Route("api/Materia/GetAll")]
        public IHttpActionResult GetAll()
        {

            ML.Result result = BL.Materia.GetAll();

            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }


        }
        [HttpGet]
        [Route("api/Materia/GetById/{IdMateria}")]
        public IHttpActionResult GetById(int IdMateria)
        {

            ML.Result result = BL.Materia.GetById(IdMateria);

            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }

        // POST: api/Materia
        [HttpPost]
        [Route("api/Materia/Add")]
        public IHttpActionResult Add([FromBody] ML.Materia materia)
        {

            ML.Result result = BL.Materia.Add(materia);

            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }

        [HttpPut]
        [Route("api/Materia/Update/{IdMateria}")]
        public IHttpActionResult Update(ML.Materia materia)
        {

            ML.Result result = BL.Materia.Update(materia);

            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }

        [HttpDelete]
        [Route("api/Materia/Delete/{IdMateria}")]
        public IHttpActionResult Delete(int IdAlumno)
        {

            ML.Result result = BL.Materia.Delete(IdAlumno);

            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }
    }
}
