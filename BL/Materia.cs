using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
  public class Materia
    {
      public static ML.Result GetAll()
      {
          ML.Result result = new ML.Result();

          try
          {
              using (DL.ControlEscolarEntities context = new DL.ControlEscolarEntities())
              {
                  var materias = context.MateriaGetAll();
                  result.Objects = new List<object>();

                  if (materias != null)
                  {
                      foreach (var obj in materias)
                      {
                          ML.Materia materia = new ML.Materia();
                          materia.IdMateria = obj.IdMateria;
                          materia.Nombre = obj.Nombre;
                          materia.Costo = obj.Costo.Value;

                          result.Objects.Add(materia);

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
      public static ML.Result GetById(int IdMateria)
      {
          ML.Result result = new ML.Result();
          try
          {
              using (DL.ControlEscolarEntities context = new DL.ControlEscolarEntities())
              {
                  var obj = context.MateriaGetById(IdMateria).FirstOrDefault();
                  result.Objects = new List<object>();
                  if (obj != null)
                  {
                      ML.Materia materia = new ML.Materia();
                      materia.IdMateria = obj.IdMateria;
                      materia.Nombre = obj.Nombre;
                      materia.Costo = obj.Costo.Value;

                      result.Object = materia;

                      result.Correct = true;
                  }
                  else
                  {
                      result.Correct = false;
                      result.ErrorMessage = "No se encontraron registros.";
                  }
              }

          }
          catch (Exception ex)
          {

              result.Correct = false;
              result.ErrorMessage = ex.Message;
              result.Ex = ex;
          }
          return result;
      }
      public static ML.Result Add(ML.Materia materia)
      {

          ML.Result result = new ML.Result();


          try
          {
              using (DL.ControlEscolarEntities context = new DL.ControlEscolarEntities())
              {
                  result.Objects = new List<object>();

                  var query = context.MateriaAdd(materia.Nombre, materia.Costo);

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
      public static ML.Result Update(ML.Materia materia)
      {
          ML.Result result = new ML.Result();
          try
          {
              using (DL.ControlEscolarEntities context = new DL.ControlEscolarEntities())
              {

                  result.Objects = new List<object>();

                  var query = context.MateriaUpdate(materia.IdMateria, materia.Nombre, materia.Costo);

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
              result.Ex = ex;
          }
          return result;
      }
      public static ML.Result Delete(int IdMateria)
      {
          ML.Result result = new ML.Result();
          try
          {
              using (DL.ControlEscolarEntities context = new DL.ControlEscolarEntities())
              {
                  var query = context.MateriaDelete(IdMateria);

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
    }
}
