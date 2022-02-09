using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace BL
{
    public class AlumnoMateria
    {
        //public static ML.Result MateriasGetAsignadas(int IdAlumno)
        //{
        //    ML.Result result = new ML.Result();

        //    try
        //    {
        //        using (SqlConnection context = new SqlConnection(DL.Connection.GetConnectionString()))
        //        {
        //            string query = "MateriasGetAsignadas";

        //            using (SqlCommand cmd = new SqlCommand())
        //            {
        //                cmd.Connection = context;
        //                cmd.CommandText = query;
        //                cmd.CommandType = CommandType.StoredProcedure;

        //                SqlParameter[] collection = new SqlParameter[1];

        //                collection[0] = new SqlParameter("IdAlumno", SqlDbType.VarChar);
        //                collection[0].Value = IdAlumno;
        //                cmd.Parameters.AddRange(collection);
        //                DataTable tableAlumnoMateria = new DataTable();

        //                SqlDataAdapter da = new SqlDataAdapter(cmd);

        //                da.Fill(tableAlumnoMateria);

        //                if (tableAlumnoMateria.Rows.Count > 0)
        //                {
        //                    DataRow row = tableAlumnoMateria.Rows[0];

        //                    ML.AlumnoMateria alumnoMateria = new ML.AlumnoMateria();
        //                    alumnoMateria.IdAlumnoMateria = int.Parse(row[0].ToString());
        //                    ML.Alumno alumno = new ML.Alumno();
        //                    alumno.IdAlumno = int.Parse(row[1].ToString());
        //                    ML.Materia materia = new ML.Materia();
        //                    materia.IdMateria = int.Parse(row[2].ToString());
        //                    materia.Nombre = row[3].ToString();

        //                    result.Object = alumnoMateria; //boxing

        //                    result.Correct = true;
        //                }
        //                else
        //                {
        //                    result.Correct = false;
        //                    result.ErrorMessage = "No existen registros en la tabla Materia";
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Correct = false;
        //        result.ErrorMessage = ex.Message;
        //        result.Ex = ex;
        //    }

        //    return result;
        //}

       
        
        public static ML.Result MateriasGetAsignadas(int IdAlumno)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.ControlEscolarEntities context = new DL.ControlEscolarEntities())
                {
                    var materias = context.MateriasGetAsignadas(IdAlumno);
                    result.Objects = new List<object>();

                    if (materias != null)
                    {
                        foreach (var obj in materias)
                        {
                            ML.AlumnoMateria alumnoMateria = new ML.AlumnoMateria();

                            alumnoMateria.IdAlumnoMateria = obj.IdAlumnoMateria;
                            alumnoMateria.Materia = new ML.Materia();
                            alumnoMateria.Materia.IdMateria = obj.IdMateria;
                            alumnoMateria.Materia.Nombre = obj.Nombre;

                            result.Objects.Add(alumnoMateria);

                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public static ML.Result MateriasGetNoAsignadas(int IdAlumno)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.ControlEscolarEntities context = new DL.ControlEscolarEntities())
                {
                    var materias = context.MateriasGetNoAsignadas(IdAlumno);
                    result.Objects = new List<object>();

                    if (materias != null)
                    {
                        foreach (var obj in materias)
                        {
                            ML.Materia Materia = new ML.Materia();

    
                            Materia.IdMateria = obj.IdMateria;
                            Materia.Nombre = obj.Nombre;
                            Materia.Costo = obj.costo.Value;

                            result.Objects.Add(Materia);

                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public static ML.Result AlumnoMateriaDelete(int IdAlumnoMateria)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.ControlEscolarEntities context = new DL.ControlEscolarEntities())
                {
                    var query = context.AlumnoMateriaDelete(IdAlumnoMateria);

                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al eliminar el registro";
                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static ML.Result AlumnoMateriaAdd(int IdAlumno,int IdMateria)
        {

            ML.Result result = new ML.Result();


            try
            {
                using (DL.ControlEscolarEntities context = new DL.ControlEscolarEntities())
                {
               

                    var query = context.AlumnoMateriaAdd(IdAlumno, IdMateria);

                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se insertó el registro";
                    }
                    result.Correct = true;

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;

        }
    }
}
