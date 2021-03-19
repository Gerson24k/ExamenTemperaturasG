using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ExamenTemperaturasG
{
    public partial class Form3 : Form
    {
        List<DEPARTAMENTO> DepartamentoR = new List<DEPARTAMENTO>();
        List<REGISTRO> RegistroT = new List<REGISTRO>();
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = RegistroT;
            dataGridView1.Refresh();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            {
                FileStream stream = new FileStream(@"..\..\departamentos.txt", FileMode.OpenOrCreate, FileAccess.Read);
                StreamReader reader = new StreamReader(stream);

                //Un ciclo para leer el archivo hasta el final del archivo
                //Lo leído se va guardando en un control richTextBox
                while (reader.Peek() > -1)
                //Esta linea envía el texto leído a un control richTextBox, se puede cambiar para que
                //lo muestre en otro control por ejemplo un combobox
                {
                    DEPARTAMENTO reg = new DEPARTAMENTO();
                    reg.Codigo = reader.ReadLine();
                    reg.Nombre = reader.ReadLine();          
                    DepartamentoR.Add(reg);
                }
                //Cerrar el archivo, esta linea es importante porque sino despues de correr varias veces el programa daría error de que el archivo quedó abierto muchas veces. Entonces es necesario cerrarlo despues de terminar de leerlo.
                reader.Close();
            }
            {
                FileStream stream = new FileStream(@"..\..\temperaturas.txt", FileMode.OpenOrCreate, FileAccess.Read);
                StreamReader reader = new StreamReader(stream);

                //Un ciclo para leer el archivo hasta el final del archivo
                //Lo leído se va guardando en un control richTextBox
                while (reader.Peek() > -1)
                //Esta linea envía el texto leído a un control richTextBox, se puede cambiar para que
                //lo muestre en otro control por ejemplo un combobox
                {
                    REGISTRO reg = new REGISTRO();
                    reg.FechaT = Convert.ToDateTime(reader.ReadLine());
                    reg.Codigo = reader.ReadLine();
                    reg.Temperatura = Convert.ToInt32(reader.ReadLine());
                    RegistroT.Add(reg);
                }
                //Cerrar el archivo, esta linea es importante porque sino despues de correr varias veces el programa daría error de que el archivo quedó abierto muchas veces. Entonces es necesario cerrarlo despues de terminar de leerlo.
                reader.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<REGISTRO> sorted = RegistroT.OrderBy(x => x.Temperatura).ToList();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = sorted;
            dataGridView1.Refresh();

        }
    }
}
