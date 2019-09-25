using PrimerParcial.BLL;
using PrimerParcial.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimerParcial.UI.Registro
{
    public partial class rEvaluacion : Form
    {
        public rEvaluacion()
        {
            InitializeComponent();
        }
        public void Limpiar()
        {
            IdNumericUpDown.Value = 0;
            FecahadateTimePicker.Value = DateTime.Now;
            EstudiantetextBox.Text = string.Empty;
            ValortextBox.Text = string.Empty;
            LogradotextBox.Text = string.Empty;
            PerdidotextBox.Text = string.Empty;
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        public Evaluacion LlenaClase()
        {
            Evaluacion evaluacion = new Evaluacion();
            evaluacion.EstudianteId = Convert.ToInt32(IdNumericUpDown.Value);
            evaluacion.Nombres = EstudiantetextBox.Text;
            evaluacion.Fecha = FecahadateTimePicker.Value;
            evaluacion.Valor = Convert.ToDecimal(ValortextBox.Text);
            evaluacion.Logro = Convert.ToDecimal(LogradotextBox.Text);
            evaluacion.Perdido = EvaluacionBLL.calcular(evaluacion.Valor, evaluacion.Logro);
            return evaluacion;

        }
        public void LlenaCampo(Evaluacion evaluacion)
        {

            IdNumericUpDown.Value = evaluacion.EstudianteId;
            EstudiantetextBox.Text = evaluacion.Nombres;
            FecahadateTimePicker.Value = evaluacion.Fecha; 
            ValortextBox.Text= evaluacion.Valor.ToString();
            LogradotextBox.Text = evaluacion.Logro.ToString();
            PerdidotextBox.Text = Convert.ToString(EvaluacionBLL.calcular(evaluacion.Valor, evaluacion.Logro));

        }
        private bool ExisteEnLaBase()
        {
            Evaluacion evaluacion = EvaluacionBLL.Buscar((int)IdNumericUpDown.Value);
            return (evaluacion != null);
        }
        private bool validar()
        {
            bool paso = true;
            if (EstudiantetextBox.Text == string.Empty)
            {
                MyerrorProvider1.SetError(EstudiantetextBox, "Llenar espacio en blanco ");
                EstudiantetextBox.Focus();
                paso = false;
            }
            if (ValortextBox.Text == string.Empty)
            {
                MyerrorProvider1.SetError(ValortextBox, "Llenar espacio en blanco ");
                ValortextBox.Focus();
                paso = false;
            }
            if (LogradotextBox.Text == string.Empty)
            {
                MyerrorProvider1.SetError(LogradotextBox, "Llenar espacio en blanco ");
                LogradotextBox.Focus();
                paso = false;
            }
            if (ValortextBox.Text == string.Empty)
            {
                MyerrorProvider1.SetError(ValortextBox, "Llenar espacio en blanco ");
                ValortextBox.Focus();
                paso = false;
            }
            return paso;

        }
        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            bool paso = false;
            Evaluacion evaluacion = new Evaluacion();
            if (!validar())
                return;
            evaluacion = LlenaClase();
            if (IdNumericUpDown.TextAlign == 0)
            {
                paso =EvaluacionBLL.Guardar(evaluacion);

            }
            else
                if (!ExisteEnLaBase())
            {
                MessageBox.Show("no existe en la base de datos");

            }
            else {
                paso = EvaluacionBLL.Modificar(evaluacion);
            MessageBox.Show("modificado"); }
           

          
                  if (paso){
                MessageBox.Show("guardado");
                Limpiar();
            }
            else
            {
                MessageBox.Show("no guardado");
            }
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            int id;
            int.TryParse(IdNumericUpDown.Text, out id);
            if (EvaluacionBLL.Eliminar(id))
            {
                MessageBox.Show("Eliminado");
                Limpiar();
            }
            else
            {
                MessageBox.Show("no eliminado");
            }
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            int id;
            Evaluacion evaluacion = new Evaluacion();
            int.TryParse(IdNumericUpDown.Text, out id);
            evaluacion = EvaluacionBLL.Buscar(id);
            if (evaluacion!=null)
            
            {
                LlenaCampo(evaluacion);
                MessageBox.Show("encontrado");

            }
            else
            {
                MessageBox.Show("no encontrado");
            }
        }

        private void LogradotextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
