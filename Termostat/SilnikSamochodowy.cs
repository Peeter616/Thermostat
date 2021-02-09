using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termostat
{
    class SilnikSamochodowy
    {
        double obrotySilnika;
        decimal pojemnośćSilnika;
        decimal temperaturaSilnika;
        public SilnikSamochodowy()
        {
            obrotySilnika = 0;
            pojemnośćSilnika = 1800;
        }
        public SilnikSamochodowy(decimal pojemnośćSilnika = 1800, double obrotySilnika = 0)
        {
            this.obrotySilnika = obrotySilnika;
            this.pojemnośćSilnika = pojemnośćSilnika;
        }
        public double ObrotySilnika { get { return obrotySilnika; } set { obrotySilnika = value; } }
        public decimal PojemnośćSilnika { get { return pojemnośćSilnika; } }
        public decimal TemperaturaSilnika { get { return temperaturaSilnika; } }
        public void aktualnaTemperatura(decimal temperaturaOtoczenia, int czas)
        {
            if (czas == 0)
                czas = 1;
            if (pojemnośćSilnika / 100 > czas)
                temperaturaSilnika = temperaturaOtoczenia + Convert.ToDecimal(obrotySilnika * 0.025) * (pojemnośćSilnika / 1000 / czas);//dla temperatury nieustalonej - silnik jeszcze rozgrzewa się po włączeniu
            else
                temperaturaSilnika = (temperaturaOtoczenia + Convert.ToDecimal(obrotySilnika * 0.025));//dla stanu ustalonego - silnik nagrzany
        }
        public void parametrySilnika()
        {
            System.Windows.Forms.MessageBox.Show("Obroty silnika to: " + ObrotySilnika + "\r\n" +
                                                 "Pojemność silnika wynosi: " + Convert.ToDouble(PojemnośćSilnika) * 0.01 + "\r\n" +
                                                 "Temperatura silnika wynosi: " + TemperaturaSilnika + "\r\n");
        }
    }
}
