using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp14
{
    public partial class Form1 : Form
    {
        int selected;
        public Form1()
        {
            InitializeComponent();
            LoadGrid();
            comboBox1.Items.Add("Imię");
            comboBox1.Items.Add("Nazwisko");
            comboBox1.Items.Add("Miasto");

        }
        public void LoadGrid()
        {
            using (var db = new obsluga())
            {
                var uczniowie = db.Users.ToList();
                var klasa = db.Miasta.ToList();
                var wynik = from u in db.Users
                            join m in db.Miasta on u.IdMiasto equals m.IdM
                            select new
                            {
                                u.IdUser,
                                u.Imie,
                                u.Nazwisko,
                                m.Miasto
                            };
                dataGridView1.DataSource = wynik.ToList();
            }





        }

        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0) { selected = 0; };
            if (comboBox1.SelectedIndex == 1) { selected = 1; };
            if (comboBox1.SelectedIndex == 2) { selected = 2; };
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var db = new obsluga())
            {
                string ID = textBox1.Text;
                string wartosc = textBox2.Text;
                if (selected == 0)
                {
                    var uczniowie = db.Users.Where(u => u.IdUser == int.Parse(ID)).FirstOrDefault();
                    uczniowie.Imie = wartosc;
                    db.SaveChanges();
                    LoadGrid();
                }
                if (selected == 1)
                {
                    var uczniowie = db.Users.Where(u => u.IdUser == int.Parse(ID)).FirstOrDefault();
                    uczniowie.Nazwisko = wartosc;
                    db.SaveChanges();
                    LoadGrid();
                }
                if (selected == 2)
                {
                    MessageBox.Show("Nie można zmieniać miasta zamieszkania!");
                }

            }
        }
    }
}
