using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termostat
{
    abstract class Termostat
    {
        protected decimal temperaturaOtoczenia;
        protected decimal temperaturaNastawy;
        protected double[] tablicaZmianTemperatury = new double[0];
        protected Termostat()
        {
            temperaturaOtoczenia = 20;
            temperaturaNastawy = 90;
        }
        protected Termostat(decimal temperaturaOtoczenia = 20, decimal temperaturaNastawy = 90)
        {
            this.temperaturaOtoczenia = temperaturaOtoczenia;
            this.temperaturaNastawy = temperaturaNastawy;
        }
        public decimal TemperaturaOtoczenia { get { return temperaturaOtoczenia; } }
        public decimal TemperaturaNastawy { get { return temperaturaNastawy; } }
        virtual public void info() { System.Windows.Forms.MessageBox.Show("Temperatura otoczenia wynosi: " + temperaturaOtoczenia); }
    }
}
