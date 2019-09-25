using PrimerParcial.DAL;
using PrimerParcial.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace PrimerParcial.BLL
{
  public   class EvaluacionBLL
    {
        public static bool Guardar(Evaluacion evaluacion)
        {
            bool paso = true;
            Contexto db = new Contexto();
            try
            {
if (db.evaluacions.Add(evaluacion) != null)
                {
                    paso = (db.SaveChanges() > 0);
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }
        public static bool Modificar (Evaluacion evaluacion)
        {
            bool paso = true;
            Contexto db = new Contexto();
            try
            {
                db.Entry(evaluacion).State = EntityState.Modified;
                    paso = (db.SaveChanges() > 0);
                
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }
        public static bool Eliminar(int id)
        {
            bool paso = true;

            Contexto db = new Contexto();
            try
            {
                var eliminar = db.evaluacions.Find(id);
                db.Entry(eliminar).State = EntityState.Deleted;
                paso = (db.SaveChanges() > 0);

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }
        public static Evaluacion Buscar(int id)
        {
            Evaluacion evaluacion = new Evaluacion(); 

            Contexto db = new Contexto();
            try
            {
                evaluacion = db.evaluacions.Find(id);

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }
            return evaluacion  ;
        }
        public static decimal calcular (decimal valor ,decimal logrado)
        {
            return valor - logrado;
        }
    }
}
