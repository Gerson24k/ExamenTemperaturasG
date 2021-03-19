using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamenTemperaturasG
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 formularioautos = new Form2();
            formularioautos.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 formularioautos = new Form3();
            formularioautos.Show();
        }
    }
}
