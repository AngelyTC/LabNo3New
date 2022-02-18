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

namespace LabNo3New
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnIr_Click(object sender, EventArgs e)
        {

            String uri = cmbBuscar.Text;

            //Angely Esmeralda Thomas Cortéz -  202108047 - Ingeniería en Sistemas 
            //Tercer Semestre Universidad Mesoamericana, Programación

            //condicion para url
            if (uri.Contains("."))
            {
                if (uri.Contains("https://"))
                {
                    //Buscar lo seleccionado en el combobox
                    webBrowser1.Navigate(new Uri(cmbBuscar.Text));
                    Guardar(@"C:\ArchivoLab3.txt", cmbBuscar.Text);
                    cmbBuscar.Items.Add(uri);
                }
                else
                {
                    webBrowser1.Navigate(new Uri("https://" + cmbBuscar.Text));
                    cmbBuscar.Text = "https://" + cmbBuscar.Text;
                    Guardar(@"C:\ArchivoLab3.txt", cmbBuscar.Text);
                    cmbBuscar.Items.Add(uri);
                }
            }
            else
            {
                uri = "http://www.google.com/search?q=" + uri;
                webBrowser1.Navigate(new Uri(uri));
            }
           

        }

        private void Guardar(string nombreArchivo, string texto)
        {
            FileStream stream = new FileStream(nombreArchivo, FileMode.Append, FileAccess.Write);

            StreamWriter writer = new StreamWriter(stream);

            writer.WriteLine(texto);

            writer.Close();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            string nombreArchivo = @"C:\ArchivoLab3.txt";

            FileStream stream = new FileStream(nombreArchivo, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1)
            {
                string texto = reader.ReadLine();
               cmbBuscar.Items.Add(texto);
            }
            reader.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
