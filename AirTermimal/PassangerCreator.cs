using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirTermimal
{
    public partial class PassangerCreator : Form
    {
        public string GetName()
        {
            return textBox1.Text;
        }
        public string GetRace()
        {
            return textBox5.Text;
        }
        public string GetDestinatiom()
        {
            return textBox4.Text;
        }
        public string GetDate()
        {
            return textBox6.Text;
        }
        public int GetItemsCount()
        {
            return (int)numericUpDown1.Value;
        }
        public double GetItemsWeight()
        {
            return (double)numericUpDown2.Value;
        }
        public int GetFlyHours()
        {
            return (int)numericUpDown3.Value;
        }



        public PassangerCreator()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox5.Clear();
            textBox4.Clear();
            textBox6.Clear();
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            numericUpDown3.Value = 0;
        }
    }
}
