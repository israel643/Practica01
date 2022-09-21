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

        //Arreglo de datos
        int[] datos = new int[] { 5, 10, 3 };

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            for(int i = 0; i< datos.Length; i++)
            {
                listBox1.Items.Add(datos[i]);
            }
        }
    }
}
