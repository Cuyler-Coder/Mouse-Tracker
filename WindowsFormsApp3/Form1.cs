using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Linq;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        ListViewItem lv;
        int a, b;
        double distX = 0;
        private SoundPlayer _blip;
        private SoundPlayer _blip2;
        private SoundPlayer _blip3;



        public Form1()
        {
            InitializeComponent();
            _blip = new SoundPlayer("Blip.wav");
            _blip2 = new SoundPlayer("Blip2.wav");
            _blip3 = new SoundPlayer("Blip3.wav");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Stop();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            a = 0;
            b = 0;
            chart2.ChartAreas[0].AxisY.IsReversed = true;
            chart1.ChartAreas[0].AxisY.Maximum = 300;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lv = new ListViewItem(b.ToString());
            lv.SubItems.Add(Cursor.Position.X.ToString());
            lv.SubItems.Add(Cursor.Position.Y.ToString());
            listView1.Items.Add(lv);

            chart2.Series[0].Points.AddXY(double.Parse(listView1.Items[b].SubItems[1].Text), double.Parse(listView1.Items[b].SubItems[2].Text));
            b++;
            if (b > 2)
            {
                distX = Math.Sqrt(  Math.Pow(double.Parse(listView1.Items[b - 2].SubItems[1].Text) - double.Parse(listView1.Items[b - 1].SubItems[1].Text),2) +
                                    Math.Pow(double.Parse(listView1.Items[b - 2].SubItems[2].Text) - double.Parse(listView1.Items[b - 1].SubItems[2].Text),2)); //+ int.Parse(listView1.Items[b - 1].SubItems[1].Text);
                chart1.Series[0].Points.AddXY(b, distX);
                lv.SubItems.Add(distX.ToString());
            }
            if(distX > 50)
            {
                _blip3.Play();
            }
            else if (distX > 25)
            {
                _blip2.Play();
            }
            else if (distX > 12)
            {
                _blip.Play();
            }
            chart1.ChartAreas[0].AxisX.Minimum = b - hScrollBar1.Value;
            chart1.ChartAreas[0].AxisX.Maximum = b;
            chart1.ChartAreas[0].AxisY.Maximum = vScrollBar1.Value;

           
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (a != b)
            {
                Cursor.Position = new Point(int.Parse(listView1.Items[a].SubItems[1].Text), int.Parse(listView1.Items[a].SubItems[2].Text));
                a++;
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            a = 0;
            b = 0;
            listView1.Items.Clear();
            timer1.Stop();
            timer2.Stop();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            StringBuilder sb;
            var sw = new StreamWriter("Text.txt");

            if (listView1.Items.Count > 0)
            {
                // the actual data
                foreach (ListViewItem lvi in listView1.Items)
                {
                    sb = new StringBuilder();

                    foreach (ListViewItem.ListViewSubItem listViewSubItem in lvi.SubItems)
                    {
                        sb.Append(string.Format("{0}\t", listViewSubItem.Text));
                    }
                    sw.WriteLine(sb.ToString());
                }
                sw.WriteLine();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer2.Start();

        }
    }
}
