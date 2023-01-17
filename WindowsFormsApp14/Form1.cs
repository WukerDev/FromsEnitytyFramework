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
            LoadGrid();  //ładujemy gridview
            comboBox1.Items.Add("Imię");  //dodajemy wartości do comboBox1
            comboBox1.Items.Add("Nazwisko");
            comboBox1.Items.Add("Miasto");

        }
        public void LoadGrid() //ładowanie grid view
        {
            using (var db = new obsluga())  //tworzymy nową obsługę
            {
                var uczniowie = db.Users.ToList();  //przypisujemy do zmiennej uczniowie wartość tabeli users w bazie danych, przerobionej na listę
                var klasa = db.Miasta.ToList();  //jak wyżej
                var wynik = from u in db.Users // wynikiem operacji będzie oznaczenie wartości z tabeli Users jako u
                            join m in db.Miasta on u.IdMiasto equals m.IdM  //oraz dodanie wartości z tabeli Miasta jako m i przypisanie kluczowi obcemu w tabeli Users tego samego co IdM w tabeli miasta
                            select new
                            {
                                u.IdUser,  // tabela Users, kolumna IdUser
                                u.Imie,  // tabela Users, kolumna Imie
                                u.Nazwisko,  // tabela Users, kolumna Nazwisko
                                m.Miasto //tabela miasta, kolumna Miasto
                            };
                dataGridView1.DataSource = wynik.ToList(); // ustala że wartościami pobieranymi do wyświetlenia gridView jest zmienna wynik zamieniona na Listę funkcją .ToList()
            }





        }

        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) //ustalamy co jest czym w combo boxie
        {
            if (comboBox1.SelectedIndex == 0) { selected = 1; };  //pierwsza opcja w combo boxie to zero zaś w bazie danych to 1
            if (comboBox1.SelectedIndex == 1) { selected = 2; };
            if (comboBox1.SelectedIndex == 2) { selected = 3; };
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var db = new obsluga()) // tworzymy nową instancję obsługi bazy
            {
                string ID = textBox1.Text;  //zmienna id jest równa wartości textbox1
                string wartosc = textBox2.Text; //zmienna wartosc jest równa wartości textbox2
                if (selected == 0) //jeśli wybrano 0
                {
                    var uczniowie = db.Users.Where(u => u.IdUser == int.Parse(ID)).FirstOrDefault();  //tutaj kod decyduje po ID(wartości wyżej) ktorego ucznia zmieniamy
                    uczniowie.Imie = wartosc; //tutaj program mówi że zmieniamy imie i nadajemy mu wartość z drugiego textboxa
                    db.SaveChanges();  //zapisujemy zmiany
                    LoadGrid(); //ładujemy gridview
                }
                if (selected == 1)
                {
                    var uczniowie = db.Users.Where(u => u.IdUser == int.Parse(ID)).FirstOrDefault();  //tutaj kod decyduje po ID(wartości wyżej) ktorego ucznia zmieniamy
                    uczniowie.Nazwisko = wartosc; //tutaj program mówi że zmieniamy nazwisko i nadajemy mu wartość z drugiego textboxa
                    db.SaveChanges(); //zapisujemy zmiany
                    LoadGrid(); //ładujemy gridview
                }
                if (selected == 2)
                {
                    MessageBox.Show("Nie można zmieniać miasta zamieszkania!");  //w wypadku gdy ktoś chciałby zmienić miasto zamieszkania, nie pozwalamy na to więc kończymy program
                }

            }
        }
    }
}
