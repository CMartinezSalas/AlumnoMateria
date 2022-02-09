using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_Alumno
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAlumno" in both code and config file together.
    [ServiceContract]
    public interface IAlumno
    {
        [OperationContract]
        [ServiceKnownType(typeof(ML.Alumno))]
        WCF_Alumno.Result GetAll();
        [OperationContract]
        WCF_Alumno.Result Add(ML.Alumno alumno);
        [OperationContract]
        WCF_Alumno.Result Update(ML.Alumno alumno);
        [OperationContract]
        WCF_Alumno.Result Delete(int IdAlumno);

        [OperationContract]
        [ServiceKnownType(typeof(ML.Alumno))]
        WCF_Alumno.Result GetById(int IdAlumno);
    }
}
