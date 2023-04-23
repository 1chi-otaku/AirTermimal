using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirTermimal
{
    public partial class Form1 : Form
    {
        public List<Passanger> passenger_list { get; set; }
        public PassangerCreator creator { get; set; }
        public Form1()
        {
            InitializeComponent();
            creator = new PassangerCreator();
            passenger_list= new List<Passanger>();
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            passenger_list.RemoveAt(listBox1.SelectedIndex);
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }

        private void addPassangerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = creator.ShowDialog();
            if (result == DialogResult.OK)
            {
                Passanger passanger = new Passanger(creator.GetName(), creator.GetItemsCount(), creator.GetItemsWeight(), creator.GetRace(), creator.GetDate(), creator.GetFlyHours(), creator.GetDestinatiom());
                passenger_list.Add(passanger);
                Thread updatepassangerlist = new Thread(UpdatePassangerList);
                updatepassangerlist.Start();
            }
        }
        private void UpdatePassangerList()
        {
            listBox1.Items.Clear();
            foreach (var item in passenger_list)
            {
                listBox1.Items.Add(item.full_name + " - " + item.race_number);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread searchpassangersbyrace = new Thread(SearchPassangersByRace);
            searchpassangersbyrace.Start();
        }
        private void SearchPassangersByRace()
        {
            foreach (var item in passenger_list)
            {
                if (item.race_number == textBox1.Text)
                {
                    ListViewItem list_item = new ListViewItem(item.full_name);
                    list_item.SubItems.Add(item.items_weight.ToString());
                    list_item.SubItems.Add(item.departure_date.ToString());
                    list_item.SubItems.Add(item.destination);
                    listView1.Items.Add(list_item);
                }
            }
        }
    }
    public class Passanger
    {
        public string full_name { get; set; }
        public int items_count { get; set; }
        public double items_weight { get; set; }
        public string race_number { get; set; }
        public string departure_date { get; set; }
        public int departure_hours { get; set; }
        public string destination { get; set; }
        
        public Passanger() { }
        public Passanger(string full_name, int items_count, double items_weight, string race_number, string departure_date, int departure_hours, string destination)
        {
            this.full_name= full_name;
            this.items_count= items_count;
            this.items_weight= items_weight;
            this.race_number= race_number;
            this.departure_date = departure_date;
            this.departure_hours = departure_hours;
            this.destination = destination;
        }


        public override string ToString()
        {
            return "Name - " + full_name + "\nItems count - " + items_count + "\nItems weight - " + items_weight + "\nRace number - " + race_number + "\nDeparture date - " + departure_date + "\nDeparture hours - " + departure_hours + "Destination - " + destination + "\n" ;
        }

    }
}
