using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Seiton
{
    public partial class Ambulancia : Form
    {
        NpgsqlConnection cn;
        public Ambulancia()
        {
            InitializeComponent();
           
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            string sv_data = "Server=127.0.0.1;Port=5432;Database=seiton;User Id=postgres;Password=12345";
            cn = new NpgsqlConnection();
            cn.ConnectionString = sv_data;
            cn.Open();

            Hora.Text =DateTime.Now.ToShortTimeString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool fill_texbox = false;
            foreach (Control item in Limpieza.Controls)
            {

                if (item.GetType() == typeof(TextBox))
                {
                    if (string.IsNullOrEmpty(((TextBox)item).Text) && item.Visible == true)
                    {
                        fill_texbox = false;
                        
                        break;
                    }
                    else
                        fill_texbox = true;
                }
            }
            foreach (Control item in groupBox2.Controls)
            {

                if (item.GetType() == typeof(TextBox))
                {
                    if (string.IsNullOrEmpty(((TextBox)item).Text))
                    {
                        fill_texbox = false;
                  
                        break;
                    }
                    else
                        fill_texbox = true;
                }
            }
            foreach (Control item in groupBox3.Controls)
            {

                if (item.GetType() == typeof(TextBox))
                {
                    if (string.IsNullOrEmpty(((TextBox)item).Text) && item.Visible == true)
                    {
                        fill_texbox = false;
                        
                        break;
                    }
                    else
                        fill_texbox = true;
                }
            }
            foreach (Control item in groupBox4.Controls)
            {

                if (item.GetType() == typeof(TextBox))
                {
                    if (string.IsNullOrEmpty(((TextBox)item).Text))
                    {
                        fill_texbox = false;
                   
                        break;
                    }
                    else
                        fill_texbox = true;
                }
            }
            if (fill_texbox) 
            {
                    try 
                    {
                        List<ComboBox> combolist = new List<ComboBox>()
                        {
                        comboBox1, comboBox2, comboBox3, comboBox4,
                        comboBox5, comboBox6, comboBox7, comboBox8,
                        comboBox9, comboBox10, comboBox11, comboBox12,
                        comboBox13, comboBox14, comboBox15, comboBox16,
                        comboBox17, comboBox18, comboBox19, comboBox20,
                        comboBox21, comboBox22, comboBox23, comboBox24,
                        comboBox25, comboBox26, comboBox27, comboBox28,
                        comboBox29, comboBox30, comboBox31, comboBox32,
                        comboBox33, comboBox34, comboBox35, comboBox36,
                        comboBox37, comboBox38, comboBox39, comboBox40,
                        comboBox41, comboBox42
                    };
                        List<TextBox> textlist = new List<TextBox>()
                    {
                        textBox1,textBox2, textBox3, textBox4,
                        textBox5,textBox6, textBox7, textBox8,
                        textBox9,textBox10, textBox11, textBox12,
                        textBox13,textBox14, textBox15, textBox16,
                        textBox17,textBox18, textBox19, textBox20,
                        textBox21,textBox22, textBox23, textBox24,
                        textBox25,textBox26, textBox27, textBox28,
                        textBox29,textBox30, textBox31, textBox32,
                        textBox33,textBox34, textBox35, textBox36,
                        textBox37,textBox38, textBox39, textBox40,
                        textBox41,textBox42
                    };
                        string strsql = "INSERT into datos_form_ambulancia (no_reporte, nombre_entrega, nombre_recibe, coor_zonal, provincia, unidad_operativa, alfa, hora, fecha, combustible, temperatura, kilometraje, observacion) values(";
                        strsql += "'" + Noregistro.Value + "','" + conductorEntrega.Text + "','" + conductorRecibe.Text + "','" + coor_zonal.Text + "','" + Provincia.Text + "', '" + Unidad_operativa.Text + "','" + Alfa.Value + "','" + Hora.Text + "','" + Fecha.Value + "','" + combustible.Value + "','" + temperatura.Value + "','" + kilometraje.Value + "','" + observaciones_generales.Text + "');";
                        string strsql2 = "INSERT INTO RESPUESTAS (id_form,id_pregunta,valor,observacion) VALUES";
                        bool valor = new Boolean();
                        string insert_valor = "";
                        string obs = "";
                        for (int i = 0; i < 2; i++)
                        {
                            valor = (combolist[i].Text.Equals("Si")) ? true : false;
                            obs = (valor) ? "sin observaciones" : textlist[i].Text;
                            insert_valor = "('" + Noregistro.Text + "','" + i + 1 + "','" + valor + "','" + obs + "'),";
                            strsql2 += insert_valor;
                        }
                        for (int i = 2; i < combolist.Count; i++)
                        {

                            valor = (combolist[i].Text.Equals("Bueno")) ? true : false;
                            obs = (valor) ? "sin observaciones" : textlist[i].Text;
                            insert_valor = (i == 41) ? "('" + Noregistro.Text + "','" + i + 1 + "','" + valor + "','" + obs + "');" : "('" + Noregistro.Text + "','" + i + "','" + valor + "','" + obs + "'),";
                            strsql2 += insert_valor;
                        }

                        NpgsqlCommand cmd = new NpgsqlCommand(strsql, cn);
                        cmd.ExecuteNonQuery();

                        NpgsqlCommand cmd2 = new NpgsqlCommand(strsql2, cn);
                        cmd2.ExecuteNonQuery();
                    }
                    catch(NpgsqlException ex)
                    {
                    string error = "Postgresql error code : " + ex.ErrorCode;
                    MessageBox.Show(error);
                    {

                    }
                    }
                    finally
                    {
                        MessageBox.Show("Insertando a la BD");
                    }
            }
            else
            {
                MessageBox.Show("Llenar todos los campos");
            }
        }

        private void Noregistro_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Visible = (comboBox1.SelectedIndex == 0) ? false : true;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2.Visible = (comboBox2.SelectedIndex == 0) ? false : true;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox3.Visible = (comboBox3.SelectedIndex == 0) ? false : true;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox4.Visible = (comboBox4.SelectedIndex == 0) ? false : true;
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox5.Visible = (comboBox5.SelectedIndex == 0) ? false : true;
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox6.Visible = (comboBox6.SelectedIndex == 0) ? false : true;
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox7.Visible = (comboBox7.SelectedIndex == 0) ? false : true;
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox8.Visible = (comboBox8.SelectedIndex == 0) ? false : true;
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox9.Visible = (comboBox9.SelectedIndex == 0) ? false : true;
        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox10.Visible = (comboBox10.SelectedIndex == 0) ? false : true;
        }

        private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox11.Visible = (comboBox11.SelectedIndex == 0) ? false : true;
        }

        private void comboBox12_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox12.Visible = (comboBox12.SelectedIndex == 0) ? false : true;
        }

        private void comboBox13_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox13.Visible = (comboBox13.SelectedIndex == 0) ? false : true;
        }

        private void comboBox14_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox14.Visible = (comboBox14.SelectedIndex == 0) ? false : true;
        }

        private void comboBox15_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox15.Visible = (comboBox15.SelectedIndex == 0) ? false : true;
        }

        private void comboBox16_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox16.Visible = (comboBox16.SelectedIndex == 0) ? false : true;
        }

        private void comboBox17_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox17.Visible = (comboBox17.SelectedIndex == 0) ? false : true;
        }

        private void comboBox18_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox18.Visible = (comboBox18.SelectedIndex == 0) ? false : true;
        }

        private void comboBox19_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox19.Visible = (comboBox19.SelectedIndex == 0) ? false : true;
        }

        private void comboBox20_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox20.Visible = (comboBox20.SelectedIndex == 0) ? false : true;
        }

        private void comboBox21_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox21.Visible = (comboBox21.SelectedIndex == 0) ? false : true;
        }

        private void comboBox22_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox22.Visible = (comboBox22.SelectedIndex == 0) ? false : true;
        }

        private void comboBox23_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox23.Visible = (comboBox23.SelectedIndex == 0) ? false : true;
        }

        private void comboBox24_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox24.Visible = (comboBox24.SelectedIndex == 0) ? false : true;
        }

        private void comboBox25_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox25.Visible = (comboBox25.SelectedIndex == 0) ? false : true;
        }

        private void comboBox26_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox26.Visible = (comboBox26.SelectedIndex == 0) ? false : true;
        }

        private void comboBox27_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox27.Visible = (comboBox27.SelectedIndex == 0) ? false : true;
        }

        private void comboBox28_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox28.Visible = (comboBox28.SelectedIndex == 0) ? false : true;
        }

        private void comboBox29_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox29.Visible = (comboBox29.SelectedIndex == 0) ? false : true;
        }

        private void comboBox30_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox30.Visible = (comboBox30.SelectedIndex == 0) ? false : true;
        }

        private void comboBox31_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox31.Visible = (comboBox31.SelectedIndex == 0) ? false : true;
        }

        private void comboBox32_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox32.Visible = (comboBox32.SelectedIndex == 0) ? false : true;
        }

        private void comboBox33_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox33.Visible = (comboBox33.SelectedIndex == 0) ? false : true;
        }

        private void comboBox34_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox34.Visible = (comboBox34.SelectedIndex == 0) ? false : true;
        }

        private void comboBox35_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox35.Visible = (comboBox35.SelectedIndex == 0) ? false : true;
        }

        private void comboBox36_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox36.Visible = (comboBox36.SelectedIndex == 0) ? false : true;
        }

        private void comboBox37_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox37.Visible = (comboBox37.SelectedIndex == 0) ? false : true;
        }

        private void comboBox38_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox38.Visible = (comboBox38.SelectedIndex == 0) ? false : true;
        }

        private void comboBox39_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox39.Visible = (comboBox39.SelectedIndex == 0) ? false : true;
        }

        private void comboBox40_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox40.Visible = (comboBox40.SelectedIndex == 0) ? false : true;
        }

        private void comboBox41_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox41.Visible = (comboBox41.SelectedIndex == 0) ? false : true;
        }

        private void comboBox42_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox42.Visible = (comboBox42.SelectedIndex == 0) ? false : true;
        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void label52_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void label65_Click(object sender, EventArgs e)
        {

        }
    }
}
