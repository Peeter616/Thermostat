using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termostat
{

    class TermostatSamochodowy : Termostat
    {
        SilnikSamochodowy s1;
        decimal temperaturaChlodzenia;
        public TermostatSamochodowy(int czas = 0) : base()
        {
            s1 = new SilnikSamochodowy();
            this.chlodzenie(czas);
        }
        public TermostatSamochodowy(decimal pojemnośćSilnika, int czas) : base()
        {
            s1 = new SilnikSamochodowy(pojemnośćSilnika);
            this.chlodzenie(czas);
        }
        public TermostatSamochodowy(double obrotySilnika, decimal pojemnośćSilnika, int czas) : base()
        {
            s1 = new SilnikSamochodowy(pojemnośćSilnika, obrotySilnika);
            this.chlodzenie(czas);
        }
        public TermostatSamochodowy(decimal temperaturaOtoczenia, decimal temperaturaNastawy, decimal pojemnośćSilnika, double obrotySilnika, int czas) : base(temperaturaOtoczenia, temperaturaNastawy)
        {
            s1 = new SilnikSamochodowy(pojemnośćSilnika, obrotySilnika);
            this.chlodzenie(czas);
        }
        public decimal TemperaturaChlodzenia { get { return temperaturaChlodzenia; } }
        override public void info()
        {
            System.Windows.Forms.MessageBox.Show("Temperatura nastawy wynosi: " + TemperaturaNastawy + "\r\n" +
                                                 "Temperatura chlodzenia wynosi: " + TemperaturaChlodzenia + "\r\n" +
                                                 "Temperatura silnika wynosi: " + s1.TemperaturaSilnika);
        }
        public void chlodzenie(int czas)
        {
            s1.aktualnaTemperatura(temperaturaOtoczenia, czas);
            if (s1.TemperaturaSilnika > temperaturaNastawy)
                temperaturaChlodzenia = s1.TemperaturaSilnika - temperaturaNastawy;
            else
                temperaturaChlodzenia = 0;
        }
        public void zwiekszObroty(double x, int czas)
        {
            s1.ObrotySilnika += x;
            chlodzenie(czas);
        }
        public void dodajTemperature()
        {
            Array.Resize(ref tablicaZmianTemperatury, tablicaZmianTemperatury.Length + 1);
            tablicaZmianTemperatury[tablicaZmianTemperatury.Length - 1] = Convert.ToDouble(s1.TemperaturaSilnika - temperaturaChlodzenia);
        }
        public void nastawTemperatureOtoczenia(decimal t, int czas)
        {
            temperaturaOtoczenia = t;
            chlodzenie(czas);
        }
        public void nastawTemperatureNastawy(decimal t, int czas)
        {
            temperaturaNastawy = t;
            chlodzenie(czas);
        }
        public void zmniejszObroty(double x, int czas)
        {
            s1.ObrotySilnika -= x;
            chlodzenie(czas);
        }
        public double pobierzObroty() { return s1.ObrotySilnika; }
        public void RysujPrzebiegTemperatury(System.Windows.Forms.DataVisualization.Charting.Chart wykres)
        {
            //zmiana typu wykresu na liniowy
            wykres.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            //czyszczenie punktow wykresu przed ponownym narysowaniem
            wykres.Series[0].Points.Clear();
            wykres.Series[0].Points.AddXY(0, 0);
            //rysowanie przebiegu
            for (int i = 0; i < tablicaZmianTemperatury.Length; i++)
                wykres.Series[0].Points.AddY(tablicaZmianTemperatury[i]); //addY - rysuje wykres od 0 
        }
    }
}
