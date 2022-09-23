using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;


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
            button5.Enabled = false;
            button6.Enabled = false;

        }

        //conexion
        string conexion = @"D:\ASP\01\Practica_01\XML\datos.xml";
        List<Import> SAT = new List<Import>();
        
        public void load()
        {
            DataSet ds = new DataSet();
            ds.ReadXml(conexion);
            MessageBox.Show("El XML se ha optenido con exito");
            dataGridView1.DataSource = ds.Tables[0];
            button3.Enabled = false;
            button5.Enabled = true;
            button6.Enabled = true;
        }

        //Burbuja con datos numericos
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

        //QuickSort con datos numericos
        
        public void Quick(int[] array, int inicio, int final)
        {
            listBox1.Items.Clear();
            int i, j, central;
            double pivote;
            central = (inicio + final) / 2;
            pivote = array[central];
            i = inicio;
            j = final;
            /*do
            {
                while (array[i] < pivote) i++;
                while (array[j] > pivote) j--;
                if (i <= j)
                {
                    int temp;
                    temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    i++;
                    j--;
                }
            } while (i <= j);*/
            for(int x = 0; x < array.Length; x++)
            {
                if(array[i] < pivote) { i++; }
            }
            for(int y = 0; y < array.Length; y++)
            {
                if (array[j] > pivote) { j--;}
            }
            if (i <= j)
            {
                int temp;
                temp = array[i];
                array[i] = array[j];
                array[j] = temp;
                i++;
                j--;
            }

            if (inicio < j)
            {
                Quick(array, inicio, j);
            }
            if (i < final)
            {
                Quick(array, i, final);
            }
        }

        //Conversor de Tablas
        static DataTable ConvertToTable(List<Import> list,int colums)
        {
            DataTable dt = new DataTable();
            for(int i =0; i < colums; i++) {
                dt.Columns.Add();
            }
            foreach(var item in list)
            {
                DataRow wRow = dt.NewRow();
                wRow[0] = item.id;
                dt.Rows.Add(wRow);
            }
            return dt;

        }

        //Conversor de listas 
        static List<Import> Listas(DataSet d)
        {
            DataSet Datasorce = d;
            List<Import> listItems = new List<Import>();
            for (int i = 0; i < Datasorce.Tables[0].Rows.Count; i++)
            {
                Import item = new Import(
                    Datasorce.Tables[0].Rows[i]["sat_unimed"].ToString()
                );
                listItems.Add(item);
            };

            return listItems;
        }
        static List<Import> BublelList(List<Import> list)
        {
            int Leng = 0;
            List<Import> listb = list;
            Leng = listb.Count;
            for (int i = 1; i < Leng; i++)
            {
                for (int j = 0; j < (Leng - 1); j++)
                {
                    if (listb[j].id.CompareTo(listb[j + 1].id) > 0)
                    {
                        Import aux;
                        aux = listb[j];
                        listb[j] = listb[j + 1];
                        listb[j + 1] = aux;
                    }
                }
            }
            return listb;
        }

        static List<Import> QuicksortsList(List<Import> quick, int inicio, int final)
        {
            int leng = 0;
            List<Import> listq = quick;
            leng = quick.Count;
            int i, j, central;
            Import pivote;
            central = (inicio + final) / 2;
            pivote = listq[central];
            i = inicio;
            j = final;

            do
            {
                while (listq[i].id.CompareTo(pivote.id)>0) i++;
                while (listq[j].id.CompareTo(pivote.id)<0) j--;
                if (i <= j)
                {
                    Import temp;
                    temp = listq[i];
                    listq[i] = listq[j];
                    listq[j] = temp;
                    i++;
                    j--;
                }
            } while (i <= j) ;
            if (inicio < j)
            {
                QuicksortsList(listq, inicio, j);
            }
            if (i < final)
            {
                QuicksortsList(listq, i, final);
            }
            return listq;
        }


        /*                       Buttons                 */
        private void button1_Click(object sender, EventArgs e)
        {
            numbers();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            int[] array = new int[]{ 21, 12, 1, 4, 75, 3, 2, 6 };
            Quick(array, 0,array.Length-1);
            for(int i =0; i < array.Length; i++)
            {
                listBox1.Items.Add(array[i]);
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            load();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView2.Columns.Clear();
            button5.Enabled = false;
            Thread nucleo = new Thread(
                delegate (){
                    DataSet ds = new DataSet();
                    ds.ReadXml(conexion);
                    List<Import> list = Listas(ds);
                    List<Import> listburbuja = BublelList(list);   
                    if (dataGridView2.InvokeRequired)
                    {
                        dataGridView2.Invoke(new MethodInvoker(delegate {
                            DataTable TD = ConvertToTable(listburbuja, 1);
                            dataGridView2.DataSource = TD;
                            
                        }));
                    }
                    if (button5.InvokeRequired)
                    {
                        button5.Invoke(new MethodInvoker(delegate
                        {
                            button5.Enabled = true;
                        }));
                        
                    }
                });
            nucleo.Start();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView2.Columns.Clear();
            button6.Enabled = false;
            Thread core = new Thread(
                delegate ()
                {
                    DataSet dataSet = new DataSet();
                    dataSet.ReadXml(conexion);
                    List<Import> list = Listas(dataSet);
                    List<Import> Quick = QuicksortsList(list, 0, list.Count -1);
                    if (dataGridView2.InvokeRequired)
                    {
                        dataGridView2.Invoke(new MethodInvoker(delegate {
                            DataTable Table = ConvertToTable(Quick, 1);
                            dataGridView2.DataSource=Table;
                        }));
                    }
                    if (button6.InvokeRequired)
                    {
                        button6.Invoke(new MethodInvoker(delegate
                        {
                            button6.Enabled = true;
                        }));
                    }
                }); 
            core.Start();
        }
    }
}
