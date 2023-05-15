using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace tprecorridos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        MySqlConnection conexion = new MySqlConnection("server=db4free.net; port=3306; user id=tprecorridos; password=1123431629; database=bdrecorridos; ");
      

        private void button4_Click(object sender, EventArgs e)
        {
            Form formulario = new Form2();
            formulario.Show();
            this.Hide();

        }
        string origen;
        string buscar;
        public void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int lista= comboBox1.SelectedIndex;
            
          

        
                    try
                    {

                        conexion.Open();
                        
                   

                        buscar = "SELECT * from ciudadv where id=" + lista;

                        MySqlCommand comando = new MySqlCommand(buscar, conexion);
                        MySqlDataReader registro = comando.ExecuteReader();
                        


                        while (registro.Read())
                        {
                            origen = registro["origen"].ToString();
                            
                        }

                   
                        conexion.Close();

                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show(ex.Message);

                        conexion.Close();

                    }
        }

        public void button3_Click(object sender, EventArgs e)
        {

            int lista = comboBox1.SelectedIndex;
            int cant = Convert.ToInt32(textBox2.Text);


            conexion.Open();
            MySqlCommand comando = new MySqlCommand("SELECT * from ciudadh where id >= " + 1 + " limit " + cant +"; select * from ciudadv where id = "+ lista, conexion);
            MySqlDataAdapter adaptador = new MySqlDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dataGridView1.DataSource = tabla;

            conexion.Close();

            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int lista = comboBox1.SelectedIndex;
            int cant = Convert.ToInt32(textBox2.Text);


            conexion.Open();
            MySqlCommand comando = new MySqlCommand("SELECT * from ciudadv where id >= " + lista + " limit " + cant, conexion);
            MySqlDataAdapter adaptador = new MySqlDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dataGridView1.DataSource = tabla;

            conexion.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int ida = comboBox3.SelectedIndex;
            int llegada = comboBox4.SelectedIndex;

            conexion.Open();



            buscar = "SELECT km from distancia join ciudadv on ciudadv.id = (distancia.origenId ="+ ida+" ) join ciudadh on ciudadh.id = (distancia.destinoId = "+llegada+");";

            MySqlCommand comando = new MySqlCommand(buscar, conexion);
            MySqlDataReader registro = comando.ExecuteReader();



            if (registro.Read())
            {
                int km = 0; 
                
                km = registro.GetInt32("km");

                if (km != 0)
                {
                        textBox1.Text= km.ToString();
                } 
                else
                {
                    MessageBox.Show("se deben elegir dos ciudades distintas");
                }
            }
            else
            {
                MessageBox.Show("No se encontró la distancia entre las ciudades seleccionadas.");
            }

            conexion.Close();

        }
    }
}
