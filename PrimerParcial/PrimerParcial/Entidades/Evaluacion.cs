using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerParcial.Entidades
{
    public class Evaluacion
    {
        [Key]

        public int EstudianteId { get; set; }
        public string Nombres { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Valor { get; set; }
        public decimal Logro { get; set; }
        public decimal Perdido { get; set; }
        public int Pronostico { get; set; }
        public Evaluacion()
        {
            EstudianteId = 0;
            Nombres = string.Empty;
            Fecha = DateTime.Now;
            Valor = 0;
            Logro = 0;
            Perdido = 0;
            Pronostico = 0;
        }

    }
}
