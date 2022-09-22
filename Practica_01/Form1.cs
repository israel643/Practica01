using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica_01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //DataSet
        DataSet ds = new DataSet();
        public void load()
        {
            ds.ReadXml(@"D:\ASP\01\Practica_01\XML\datos.xml");
            MessageBox.Show("El XML se ha optenido con exito");
            dataGridView1.DataSource = ds.Tables[0];
            button3.Enabled = false;
        }

        int[] datos = new int[] {10,8,2,7,4,1,9,5,3,6 }; 
        public void numbers()
        {
            listBox1.Items.Clear();

            for (int i = 0; i < datos.Length; i++)
            {
                for (int j = 0; j < datos.Length - 1; j++)
                {
                    if (datos[j] > datos[j + 1])
                    {
                        int aux = 0;
                        aux = datos[j];
                        datos[j] = datos[j + 1];
                        datos[j + 1] = aux;
                    }
                }
            }
            for (int i = 0; i < datos.Length; i++)
            {
                listBox1.Items.Add(datos[i]);
            }
        }

        //QuickSort
        
        public void Quick(int[] array, int inicio, int final)
        {
            /*
            int x, y, centro;
            int pivote;
            centro = (inicio + final)/2;
            x = inicio;
            y = final;

            do
            {
                while()
            }
            */
        }

                    /*                       Buttons                 */
        private void button1_Click(object sender, EventArgs e)
        {
            numbers();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            load();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }
    }
}
