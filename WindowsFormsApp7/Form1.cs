using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            chart1.Series.Add("y");
            chart1.Series.Add("f");
            chart1.Series["y"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series["f"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = 10;
            int[] mass = new int[n];
            Random rand = new Random();
            listBox1.Items.Clear();
            for (int i = 0; i < n; i++)
            {
                mass[i] = rand.Next(-10, 20);
                listBox1.Items.Add("y[" + i.ToString() + "] = " + mass[i].ToString());
            }

            chart1.Series["y"].Points.Clear();

            for (int i = 0; i < n; i++)
                chart1.Series["y"].Points.Add(mass[i]);

            int sumx = 0;
            int sumy = 0;
            int sumxy = 0;
            int sumxx = 0;

            for (int i = 0; i < n; i++)
            {
                sumx += i;
                sumy += mass[i];
                sumxy += i * mass[i];
                sumxx += i * i;
            }

            double a = (n * sumxy - sumx * sumy) / (n * sumxx - sumx * sumx);
            double b = (sumy - a * sumx) / n;
            chart1.Series["f"].Points.Clear();

            for (int i = 0; i < n; i++)
            {
                double f = a * i + b;
                chart1.Series["f"].Points.Add(f);
            }
            textBox2.Text += "f =" + a + "*" + sumx + "+" + b.ToString();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
