using PrimerParcial.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerParcial.DAL
{
   public class Contexto:DbContext
    {
     public DbSet<Evaluacion> evaluacions { set; get; }
            public Contexto() : base("conStr")
            {

            }
        }
    }

