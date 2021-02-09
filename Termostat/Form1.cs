using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Termostat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int czas = 0;
        TermostatSamochodowy t1 = new TermostatSamochodowy();

        private void button1_Click(object sender, EventArgs e)
        {
            t1 = new TermostatSamochodowy(numericUpDown4.Value, czas);
            button1.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            numericUpDown1.Enabled = true;
            numericUpDown2.Enabled = true;
            numericUpDown3.Enabled = true;
            numericUpDown4.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (t1.pobierzObroty() + Convert.ToDouble(numericUpDown1.Value) <= 8000)
            {
                t1.zwiekszObroty(Convert.ToDouble(numericUpDown1.Value), czas);
                label4.Text = Convert.ToString(Convert.ToDecimal(label4.Text) + numericUpDown1.Value);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (t1.pobierzObroty() - Convert.ToDouble(numericUpDown1.Value) >= 0)
            {
                t1.zmniejszObroty(Convert.ToDouble(numericUpDown1.Value), czas);
                label4.Text = Convert.ToString(Convert.ToDecimal(label4.Text) - numericUpDown1.Value);
            }
            else
            {
                t1.zmniejszObroty(t1.pobierzObroty(), czas);
                label4.Text = "0";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            t1.nastawTemperatureOtoczenia(numericUpDown2.Value, czas);
            label2.Text = Convert.ToString(numericUpDown2.Value);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            t1.info();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            t1.nastawTemperatureOtoczenia(numericUpDown3.Value, czas);
            label10.Text = Convert.ToString(numericUpDown3.Value);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            timer1.Start();
        } 

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (button1.Enabled == false) //warunek startu aplikacji
            {
                czas++;
                czasEtykieta.Text = Convert.ToString(czas);
                t1.dodajTemperature();
                t1.RysujPrzebiegTemperatury(chart1);
            }
        }
    }
}
