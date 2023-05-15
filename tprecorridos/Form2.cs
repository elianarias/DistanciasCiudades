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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        MySqlConnection conexion = new MySqlConnection("server=db4free.net; port=3306; user id=tprecorridos; password=1123431629; database=bdrecorridos; ");


        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int origen = comboBox1.SelectedIndex;
            int ciudadUno = comboBox2.SelectedIndex;
            int ciudadDos = comboBox3.SelectedIndex;
            int ciudadTres = comboBox4.SelectedIndex;
            int ciudadCuatro = comboBox5.SelectedIndex;
            int destino = comboBox6.SelectedIndex;
            int distanciaTotal = 0;

            if (origen != ciudadDos & origen != ciudadCuatro & ciudadDos != ciudadCuatro & ciudadUno != ciudadTres & ciudadTres != destino & destino != ciudadUno)
            {
                conexion.Open();
                string distanciaUno = "SELECT km from distancia join ciudadv on ciudadv.id = (distancia.origenId =" + origen + " ) join ciudadh on ciudadh.id = (distancia.destinoId = " + ciudadUno + ");";

                MySqlCommand comando = new MySqlCommand(distanciaUno, conexion);
                MySqlDataReader registro = comando.ExecuteReader();


                if (registro.Read())
                {
                    int km = 0;
                    km = registro.GetInt32("km");

                    if (km != 0)
                    {
                        distanciaTotal = distanciaTotal + km;
                       
                    }
                }
                else
                {
                    MessageBox.Show("No se encontró la distancia entre la ciudad de origen y la ciudad 1 ");
                }

                conexion.Close();

                /*-----------------------------------------------------------------------------------*/

                conexion.Open();
                string distanciaDos = "SELECT km from distancia join ciudadv on ciudadv.id = (distancia.origenId =" + ciudadDos + " ) join ciudadh on ciudadh.id = (distancia.destinoId = " + ciudadUno + ");";

                MySqlCommand comandoD = new MySqlCommand(distanciaDos, conexion);
                MySqlDataReader registroD = comandoD.ExecuteReader();


                if (registroD.Read())
                {
                    int kmD = 0;
                    kmD = registroD.GetInt32("km");

                    if (kmD != 0)
                    {
                        distanciaTotal = distanciaTotal + kmD;
                    }
            
                }
                else
                {
                    MessageBox.Show("No se encontró la distancia entre la ciudad 1 y la ciudad 2 ");
                }

                conexion.Close();

                /*-----------------------------------------------------------------------------------*/

                conexion.Open();
                string distanciaTres = "SELECT km from distancia join ciudadv on ciudadv.id = (distancia.origenId =" + ciudadDos + " ) join ciudadh on ciudadh.id = (distancia.destinoId = " + ciudadTres + ");";

                MySqlCommand comandot = new MySqlCommand(distanciaTres, conexion);
                MySqlDataReader registroT = comandot.ExecuteReader();

                if (registroT.Read())
                {
                    int kmT = 0;
                    kmT = registroT.GetInt32("km");

                    if (kmT != 0)
                    {
                        distanciaTotal = distanciaTotal + kmT;
                    }

                }
                else
                {
                    MessageBox.Show("No se encontró la distancia entre la ciudad 2 y la ciudad 3 ");
                }

                conexion.Close();
                

                /*-----------------------------------------------------------------------------------*/


                conexion.Open();
                string distanciaCuatro = "SELECT km from distancia join ciudadv on ciudadv.id = (distancia.origenId =" + ciudadCuatro + " ) join ciudadh on ciudadh.id = (distancia.destinoId = " + ciudadTres + ");";

                MySqlCommand comandoC = new MySqlCommand(distanciaCuatro, conexion);
                MySqlDataReader registroC = comandoC.ExecuteReader();

                if (registroC.Read())
                {
                    int kmC = 0;
                    kmC = registroC.GetInt32("km");

                    if (kmC != 0)
                    {
                        distanciaTotal= distanciaTotal + kmC;
                    }

                }
                else
                {
                    MessageBox.Show("No se encontró la distancia entre la ciudad 3 y la ciudad 4 ");
                }

                conexion.Close();


                /*-----------------------------------------------------------------------------------*/


                conexion.Open();
                string distanciaCinco = "SELECT km from distancia join ciudadv on ciudadv.id = (distancia.origenId =" + ciudadCuatro + " ) join ciudadh on ciudadh.id = (distancia.destinoId = " + destino + ");";

                MySqlCommand comandoF = new MySqlCommand(distanciaCinco, conexion);
                MySqlDataReader registroF = comandoF.ExecuteReader();

                if (registroF.Read())
                {
                    int kmF = 0;
                    kmF = registroF.GetInt32("km");

                    if (kmF != 0)
                    {
                        distanciaTotal = distanciaTotal + kmF;
                    }

                }
                else
                {
                    MessageBox.Show("No se encontró la distancia entre la ciudad 4 y el destino ");
                }

                conexion.Close();


                /*-----------------------------------------------------------------------------------*/


                MessageBox.Show("La distancia total es de :  " + distanciaTotal.ToString());

               


            }
            else
            {
                MessageBox.Show("Debes elegir ciudades distintas");
            }
        }

    }
}
