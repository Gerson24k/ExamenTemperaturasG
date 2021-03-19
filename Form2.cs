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
    public partial class Form2 : Form
    {
        List<DEPARTAMENTO> DepartamentoR = new List<DEPARTAMENTO>();
        List<REGISTRO> RegistroT = new List<REGISTRO>();
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
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
                    comboBox1.Items.Add(reg.Nombre);
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un carro primero");

            }
            else
            {
                string deptem = comboBox1.SelectedItem.ToString();
                DEPARTAMENTO cocos = DepartamentoR.Find(carmelo => carmelo.Nombre == deptem);
                REGISTRO temT = new REGISTRO();
                temT.FechaT = monthCalendar1.SelectionStart;
                temT.Codigo = cocos.Codigo;
                temT.Temperatura = Convert.ToInt32(textBox1.Text);
                RegistroT.Add(temT);

                FileStream stream = new FileStream(@"..\..\temperaturas.txt", FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter writer = new StreamWriter(stream);
                //El ciclo foreach, va recorriendo automáticamente cada elemento de la lista
                //y lo va copiando a la variable p, luego esa variable ya la podemos
                //guardar al archivo de texto, como la variable p representa cada persona
                //de la lista, es necesario indicar cada propiedad de la persona que vamos
                //a guardar en el archivo
                foreach (var p in RegistroT)
                {
                    writer.WriteLine(p.FechaT);
                    writer.WriteLine(p.Codigo);
                    writer.WriteLine(p.Temperatura);
                    
                }
                //Cerrar el archivo
                writer.Close();
                MessageBox.Show("Datos almacenados exitosamente");
            }

        }
    }
}
