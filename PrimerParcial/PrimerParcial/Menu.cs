﻿using PrimerParcial.UI.Registro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimerParcial
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void EvaluacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rEvaluacion r = new rEvaluacion();
            r.Show();
        }
    }
}
