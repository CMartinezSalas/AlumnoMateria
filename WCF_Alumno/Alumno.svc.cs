using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_Alumno
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Alumno" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Alumno.svc or Alumno.svc.cs at the Solution Explorer and start debugging.
    public class Alumno : IAlumno
    {
        public WCF_Alumno.Result GetAll()
        {
            ML.Result result = BL.Alumno.GetAll();

            return new WCF_Alumno.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                //Ex = result.Ex,
                Object = result.Object,
                Objects = result.Objects
            };
        }
        public WCF_Alumno.Result Add(ML.Alumno alumno)
        {
            ML.Result result = BL.Alumno.Add(alumno);

            return new WCF_Alumno.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                //Ex = result.Ex,
                Object = result.Object,
                Objects = result.Objects
            };
        }
        public WCF_Alumno.Result Update(ML.Alumno alumno)
        {
            ML.Result result = BL.Alumno.Update(alumno);

            return new WCF_Alumno.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                //Ex = result.Ex,
                Object = result.Object,
                Objects = result.Objects
            };
        }
        public WCF_Alumno.Result Delete(int IdAlumno)
        {
            ML.Result result = BL.Alumno.Delete(IdAlumno);

            return new WCF_Alumno.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                //Ex = result.Ex,
                Object = result.Object,
                Objects = result.Objects
            };
        }
        public WCF_Alumno.Result GetById(int IdAlumno)
        {
            ML.Result result = BL.Alumno.GetById(IdAlumno);

            return new WCF_Alumno.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                //Ex = result.Ex,
                Object = result.Object,
                Objects = result.Objects
            };

        }
    }
}
